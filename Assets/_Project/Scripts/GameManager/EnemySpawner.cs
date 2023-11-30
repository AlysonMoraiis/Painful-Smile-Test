using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private Camera _camera;
    [SerializeField] private PoolData _poolData;
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
        }
    }
    
    private void SpawnChaserEnemy()
    {
        Vector3 localToSpawn = GetRandomCornerPosition();   
        PoolManager.Instance.SpawnFromPool(_poolData.Tag, localToSpawn, Quaternion.identity);
    }
    
    private void SpawnShooterEnemy()
    {
        
    }
    
    private Vector3 GetRandomCornerPosition()
    {
        float randomNum = Random.Range(0f, 100f);
        Vector3 edgePosition;

        if (randomNum <= 25)
        {
            // Lado esquerdo
            edgePosition = new Vector3(-30f, Random.Range(0f, Screen.height), 0f);
        }
        else if (randomNum <= 50)
        {
            // Lado superior
            edgePosition = new Vector3(Random.Range(0f, Screen.width), Screen.height +30f, 0f);
        }
        else if (randomNum <= 75)
        {
            // Lado direito
            edgePosition = new Vector3(Screen.width +30f, Random.Range(0f, Screen.height), 0f);
        }
        else
        {
            // Lado inferior
            edgePosition = new Vector3(Random.Range(0f, Screen.width), -30f, 0f);
        }

        Vector3 worldPosition = _camera.ScreenToWorldPoint(edgePosition);
        worldPosition.z = 0f;

        return worldPosition;
    }

}
