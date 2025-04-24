using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private EnemySpawnPoint[] _spawnPoints;
    [SerializeField] private Transform[] _patrolPoints;

    private void Start()
    {
        _patrolPoints = new Transform[_spawnPoints.Length];

        for (int i = 0; i < _patrolPoints.Length; i++)
        {
            _patrolPoints[i] = _spawnPoints[i].transform;
        }

        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.SpawnEnemy(_playerTransform, _patrolPoints);
        }
    }
}