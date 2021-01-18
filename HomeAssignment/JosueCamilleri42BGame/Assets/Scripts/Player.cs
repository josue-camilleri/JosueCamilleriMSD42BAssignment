﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //how fast the player will move horizontaly
    float moveSpeed = 7f;

    //used for SetUpMoveBoundaries()
    float xMin, xMax, yMin, yMax;

    float padding = 1.5f;

    [SerializeField] int health = 50;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    int valueScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public int GetHealth()
    {
        return health;
    }

    //setting up the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //getting the camera from unity
        Camera gameCamera = Camera.main;

        //xMin = 0, xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        //yMin = 0, yMax = 1
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPosition = current position in x + difference moved in x-axis
        var newXPos = transform.position.x + deltaX;

        //claml the value of newXPos between xMin (0) and xMax(1) in camera view
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //move the player ship on the x- and y-axis
        transform.position = new Vector2(newXPos, -3.5f);
    }

    //reduce player health whenever obstacle collides with a
    //gameobject that has DamageDelaer component
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access DamageDealer from otherObject that hit the player
        //and reduce health accordingly
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();

        if (!dmg)
        {
            return;
        }

        ProcessHit(dmg);

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);


    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();
        //add scoreValue to GameSession score
        valueScore = FindObjectOfType<GameSession>().GetScore();


        if (health <= 0 && valueScore < 100)
        {
            health = 0;
            Die();
            FindObjectOfType<Level>().LoadGameOver();
        }
        else if(health <= 0 && valueScore >= 100)
        {
            health = 0;
            Die();
            FindObjectOfType<Level>().LoadWinnerScene();
        }
        
    }

    private void Die()
    {
        Destroy(gameObject);

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);
    }

}
