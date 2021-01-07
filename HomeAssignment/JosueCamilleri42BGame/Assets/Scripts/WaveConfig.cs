using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]

public class WaveConfig : ScriptableObject
{
    //the obstacle to spawn in this wave
    [SerializeField] GameObject obstaclePrefab;

    //the path the wave will follow
    [SerializeField] GameObject pathPrefab;

    //time between each obstacle spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //number of obstacles in wave
    [SerializeField] int numberOfObstacles = 5;

    //movement speed of obstacle
    [SerializeField] float obstacleMoveSpeed = 2f;


    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypointsList()
    {
        //each wave can have different number of waypoints
        var waveWaypoints = new List<Transform>();

        //access the Path prefab, read each waypoint and add it to the list waveWaypoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

}
