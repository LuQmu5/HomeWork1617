using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private IdleBehavior _idleBehavior;
    [SerializeField] private ReactionBehavior _reactionBehavior;
    [SerializeField] private EnemyBehaviour _enemyPrefab;

    public void SpawnEnemy(Transform playerTransform, Transform[] patrolPoints)
    {
        EnemyBehaviour enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        enemy.Init(_idleBehavior, _reactionBehavior, playerTransform, patrolPoints);
    }
}