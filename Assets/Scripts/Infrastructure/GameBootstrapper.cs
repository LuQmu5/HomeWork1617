using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private EnemySpawnPoint[] _spawnPoints;
    [SerializeField] private EnemyBehaviour _enemyPrefab;
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private Transform _playerTransform;

    private void Start()
    {
        EnemyFactory enemyFactory = new EnemyFactory(_enemyPrefab, _patrolPoints);

        foreach (EnemySpawnPoint spawnPoint in _spawnPoints)
        {
            spawnPoint.Init(enemyFactory, _playerTransform);
            spawnPoint.Spawn();
        }
    }
}