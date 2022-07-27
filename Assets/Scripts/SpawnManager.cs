using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public List<GameObject> enemyPrefabs;
    public List<GameObject> powerUpPrefabs;

    private float spawnRange = 20;

    public int enemyCount = 0;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        SpawnEnemyWave(waveNumber);

        //AGGIUNGERE POWERUPS
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0 && !playerControllerScript.isGameOver)
        {
            waveNumber++;
            
            //QUI AGGIUNGI EVENTUALE BOSS OGNI TOT ROUNDS
            SpawnEnemyWave(waveNumber);

            //AGGIUNGI ANCHE QUI I POWERUPS
        }
    }

    Vector3 GenerateSpawnPosition(int index)
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        float halfEnemyHeight = enemyPrefabs[index].transform.localScale.y / 2;

        Vector3 randomPos = new Vector3(spawnPosX, halfEnemyHeight, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemyToSpawn)
    {
        Debug.Log("Spawned");

        for (int i = 0; i < enemyToSpawn; i++)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPosition(randomIndex), enemyPrefabs[randomIndex].transform.rotation);
        }
    }
}
