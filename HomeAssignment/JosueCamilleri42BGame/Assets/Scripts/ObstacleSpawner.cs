using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    //start from wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        //setting the current wave to wave 1
        var currentWave = waveConfigList[startingWave];

        //starts coroutine that spawn all obstacles in currentWave
        StartCoroutine(SpawnAllObstaclesInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //specifying the wave that need to spawn the obstacle.
    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveConfig)
    {
        //spawn the enemy prefab from waveToSpawn at the position of the first waypoint in Path
        Instantiate(waveConfig.GetObstaclePrefab(),
            waveConfig.GetWaypointsList()[0].transform.position,
            Quaternion.identity);

        //wait timeBetweenSpawn before spawning another obstacle
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
    }
}
