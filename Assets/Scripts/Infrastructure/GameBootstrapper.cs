using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private EnemySpawnPoint[] _spawnPoints;
    [SerializeField] private EnemyBehaviour _enemyPrefab;

    private void Start()
    {
        EnemyFactory enemyFactory = new EnemyFactory(_enemyPrefab);

        foreach (EnemySpawnPoint spawnPoint in _spawnPoints)
        {
            spawnPoint.Init(enemyFactory);
            spawnPoint.Spawn();
        }
    }
}