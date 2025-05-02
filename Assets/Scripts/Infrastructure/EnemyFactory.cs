using UnityEngine;

public class EnemyFactory
{
    private EnemyBehaviour _enemyPrefab;
    private Transform[] _patrolPoints;

    public EnemyFactory(EnemyBehaviour enemyPrefab, Transform[] patrolPoints)
    {
        _enemyPrefab = enemyPrefab;
        _patrolPoints = patrolPoints;
    }

    public EnemyBehaviour Get(EnemyIdleBehaviours idleBehaviour, EnemyReactToPlayerBehaviours reactToPlayerBehaviour, Transform playerTransform)
    {
        EnemyBehaviour enemy = Object.Instantiate(_enemyPrefab);

        IBehaviour idle = GetIdleBehaviour(idleBehaviour, enemy.transform);
        IBehaviour reactToPlayer = GetReactToPlayerBehaviour(reactToPlayerBehaviour, enemy.transform, enemy, playerTransform);

        enemy.Init(idle, reactToPlayer);

        return enemy;
    }

    private IBehaviour GetReactToPlayerBehaviour(EnemyReactToPlayerBehaviours reactToPlayerBehaviour, 
        Transform enemyTransform, IDiableActor diableActor, Transform playerTransform)
    {
        IBehaviour reactToPlayer = null;

        switch (reactToPlayerBehaviour)
        {
            case EnemyReactToPlayerBehaviours.Aggro:
                reactToPlayer = new AggroBehaviour(enemyTransform, playerTransform);
                break;

            case EnemyReactToPlayerBehaviours.DieInstantly:
                reactToPlayer = new DieInstantlyBehaviour(diableActor);
                break;

            case EnemyReactToPlayerBehaviours.Flee:
                reactToPlayer = new FleeBehaviour(enemyTransform, playerTransform);
                break;
        }

        return reactToPlayer;
    }

    private IBehaviour GetIdleBehaviour(EnemyIdleBehaviours idleBehaviour, Transform enemyTransform)
    {
        IBehaviour idle = null;

        switch (idleBehaviour)
        {
            case EnemyIdleBehaviours.StandStill:
                idle = new StandStillBehaviour();
                break;

            case EnemyIdleBehaviours.Patrol:
                idle = new PatrolBehaviour(enemyTransform, _patrolPoints);
                break;

            case EnemyIdleBehaviours.RandomPatrol:
                idle = new RandomPatrolBehaviour(enemyTransform);
                break;
        }

        return idle;
    }
}