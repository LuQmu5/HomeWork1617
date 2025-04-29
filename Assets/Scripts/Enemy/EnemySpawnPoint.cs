using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyIdleBehaviours _idleBehaviour;
    [SerializeField] private EnemyReactToPlayerBehaviours _reactToPlayerBehaviour;

    private EnemyFactory _enemyFactory;

    public void Init(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    } 

    public void Spawn()
    {
        EnemyBehaviour enemy = _enemyFactory.Get(_idleBehaviour, _reactToPlayerBehaviour);
        enemy.transform.position = transform.position;
    }
}