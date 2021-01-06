using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool looping = false;

    //start from wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            //starts coroutine that spawns all Waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); //== true

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //specifying the wave that need to spawn the obstacle.
    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveToSpawn)
    {
        //looping to spawn all obstacle in wave
        for (int obstacleCount = 1; obstacleCount <= waveToSpawn.GetNumberOfObstacles(); obstacleCount++)
        {
            //spawn the obstacle prefab from waveToSpawn at the position of the first waypoint in Path
            var newObstacle = Instantiate(
                              waveToSpawn.GetObstaclePrefab(),
                              waveToSpawn.GetWaypointsList()[0].transform.position,
                              Quaternion.identity);

            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);

            //wait timeBetweenSpawn before spawning another obstacle
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        //loop all waves
        foreach(WaveConfig currentWave in waveConfigList)
        {
            //wait for all obstacles to spawn before going to the next wave
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }

}
