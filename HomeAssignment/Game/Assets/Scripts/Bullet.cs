using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject obstacleLaserPrefab;

    [SerializeField] float obstacleLaserSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        //generates a random number
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    private void Update()
    {
        CountDownAndFire();
    }

    private void CountDownAndFire()
    {
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0f)
        {
            ObstacleFire();
            //reset shotCounter
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void ObstacleFire()
    {
        //spawn an obstacleLaser at Obstacle position
        GameObject obstacleLaser = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.identity) as GameObject;

        //shoots bullet downwards: -obstacleLaserSpeed
        obstacleLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed);
    }
}
