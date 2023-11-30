using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private Camera _camera;
    [SerializeField] private PoolData _chaserEnemyData;
    [SerializeField] private PoolData _shooterEnemyData;

    private bool _canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner(_gameData.EnemySpawnTime));
    }

    private IEnumerator Spawner(float spawnTime)
    {
        while (_canSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnChaserEnemy();
            yield return new WaitForSeconds(spawnTime);
            SpawnShooterEnemy();
        }
    }
    
    private void SpawnChaserEnemy()
    {
        Vector3 localToSpawn = GetRandomCornerPosition();   
        PoolManager.Instance.SpawnFromPool(_chaserEnemyData.Tag, localToSpawn, Quaternion.identity);
    }
    
    private void SpawnShooterEnemy()
    {
        Vector3 localToSpawn = GetRandomCornerPosition();   
        PoolManager.Instance.SpawnFromPool(_shooterEnemyData.Tag, localToSpawn, Quaternion.identity);
    }
    
    private Vector3 GetRandomCornerPosition()
    {
        float randomNum = Random.Range(0f, 100f);
        Vector3 edgePosition;

        if (randomNum <= 25)
        {
            edgePosition = new Vector3(-60f, Random.Range(0f, Screen.height), 0f);
        }
        else if (randomNum <= 50)
        {
            edgePosition = new Vector3(Random.Range(0f, Screen.width), Screen.height +60f, 0f);
        }
        else if (randomNum <= 75)
        {
            edgePosition = new Vector3(Screen.width +60f, Random.Range(0f, Screen.height), 0f);
        }
        else
        {
            edgePosition = new Vector3(Random.Range(0f, Screen.width), -60f, 0f);
        }

        Vector3 worldPosition = _camera.ScreenToWorldPoint(edgePosition);
        worldPosition.z = 0f;

        return worldPosition;
    }

}
