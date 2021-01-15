using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] float health = 100;

    [SerializeField] GameObject deathEffects;
    [SerializeField] float explosionDuration = 1f;


    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access DamageDealer from otherObject that hit the player
        //and reduce health accordingly
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        if (!dmgDealer)
        {
            return;
        }

        ProcessHit(dmgDealer);

    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        //create an explosion particle
        GameObject explosion = Instantiate(deathEffects, transform.position, Quaternion.identity);
        //destroy the particles after 1 sec
        Destroy(explosion, explosionDuration);


    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
