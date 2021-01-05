using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    [SerializeField] float obstacleMoveSpeed = 2f;

    [SerializeField] WaveConfig waveConfig;

    //shows the next waypoint
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //gets the list waypoints from WaveConfig
        waypoints = waveConfig.GetWaypointsList();

        //set the starting position of the Obstacle to Waypoint(0)
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    //takes care of moving an Obstacle along a path
    private void ObstacleMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            //set the targetPosition to the next waypoint Position
            //targetPosition: where I want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            //makes sure that z-axis = 0
            targetPosition.z = 0f;

            var obstacleMovement = obstacleMoveSpeed * Time.deltaTime;

            //move from current position, to targetPosition, at obstacleMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

            //if targetPosition is reached
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        //if anemy reaches last waypoint
        else
        {
            Destroy(gameObject);
        }
    }
}
