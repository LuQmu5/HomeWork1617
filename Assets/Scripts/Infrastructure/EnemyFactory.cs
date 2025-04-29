using UnityEngine;

public enum EnemyIdleBehaviours
{
    StandStill,
    Patrol,
    RandomPatrol
}

public enum EnemyReactToPlayerBehaviours
{
    Aggro,
    DieInstantly,
    Flee
}

public class EnemyFactory
{
    private EnemyBehaviour _enemyPrefab;
    private Transform[] _patrolPoints;

    public EnemyFactory(EnemyBehaviour enemyPrefab, Transform[] patrolPoints)
    {
        _enemyPrefab = enemyPrefab;
        _patrolPoints = patrolPoints;
    }

    public EnemyBehaviour Get(EnemyIdleBehaviours idleBehaviour, EnemyReactToPlayerBehaviours reactToPlayerBehaviour)
    {
        EnemyBehaviour enemy = Object.Instantiate(_enemyPrefab);

        IIdleBehaviour idle = GetIdleBehaviour(idleBehaviour, enemy);
        IReactToPlayerBehaviour reactToPlayer = GetReactToPlayerBehaviour(reactToPlayerBehaviour, enemy);

        enemy.Init(idle, reactToPlayer);

        return enemy;
    }

    private IReactToPlayerBehaviour GetReactToPlayerBehaviour(EnemyReactToPlayerBehaviours reactToPlayerBehaviour, EnemyBehaviour enemy)
    {
        IReactToPlayerBehaviour reactToPlayer = null;

        switch (reactToPlayerBehaviour)
        {
            case EnemyReactToPlayerBehaviours.Aggro:
                reactToPlayer = new AggroBehaviour(enemy.transform, enemy);
                break;

            case EnemyReactToPlayerBehaviours.DieInstantly:
                reactToPlayer = new DieInstantlyBehaviour(enemy);
                break;

            case EnemyReactToPlayerBehaviours.Flee:
                reactToPlayer = new FleeBehaviour(enemy.transform, enemy);
                break;
        }

        return reactToPlayer;
    }

    private IIdleBehaviour GetIdleBehaviour(EnemyIdleBehaviours idleBehaviour, EnemyBehaviour enemy)
    {
        IIdleBehaviour idle = null;

        switch (idleBehaviour)
        {
            case EnemyIdleBehaviours.StandStill:
                idle = new StandStillBehaviour(enemy.transform, enemy);
                break;

            case EnemyIdleBehaviours.Patrol:
                idle = new PatrolBehaviour(enemy.transform, enemy, _patrolPoints);
                break;

            case EnemyIdleBehaviours.RandomPatrol:
                idle = new RandomPatrolBehaviour(enemy.transform, enemy);
                break;
        }

        return idle;
    }
}