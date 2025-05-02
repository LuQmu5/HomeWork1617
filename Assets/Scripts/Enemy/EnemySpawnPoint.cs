using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyIdleBehaviours _idleBehaviour;
    [SerializeField] private EnemyReactToPlayerBehaviours _reactToPlayerBehaviour;

    private EnemyFactory _enemyFactory;
    private Transform _playerTransform;

    public void Init(EnemyFactory enemyFactory, Transform playerTransform)
    {
        _enemyFactory = enemyFactory;
        _playerTransform = playerTransform;
    } 

    public void Spawn()
    {
        EnemyBehaviour enemy = _enemyFactory.Get(_idleBehaviour, _reactToPlayerBehaviour, _playerTransform);
        enemy.transform.position = transform.position;
    }
}