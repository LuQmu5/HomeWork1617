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
    private const string EnemyPrefabPath = "Resources/Prefabs";

    private EnemyBehaviour _enemyPrefab;

    public EnemyFactory()
    {
        // _enemyPrefab = Resources.Load<EnemyBehaviour>(EnemyPrefabPath);
    }

    public EnemyFactory(EnemyBehaviour enemyPrefab)
    {
        _enemyPrefab = enemyPrefab;
    }

    public EnemyBehaviour Get(EnemyIdleBehaviours idleBehaviour, EnemyReactToPlayerBehaviours reactToPlayerBehaviour)
    {
        IIdleBehaviour idle = GetIdleBehaviour(idleBehaviour);
        IReactToPlayerBehaviour reactToPlayer = GetReactToPlayerBehaviour(reactToPlayerBehaviour);

        EnemyBehaviour enemy = Object.Instantiate(_enemyPrefab);

        Debug.Log(enemy == null);

        enemy.Init(idle, reactToPlayer);

        return enemy;
    }

    private static IReactToPlayerBehaviour GetReactToPlayerBehaviour(EnemyReactToPlayerBehaviours reactToPlayerBehaviour)
    {
        IReactToPlayerBehaviour reactToPlayer = null;

        switch (reactToPlayerBehaviour)
        {
            case EnemyReactToPlayerBehaviours.Aggro:
                reactToPlayer = new AggroBehaviour();
                break;

            case EnemyReactToPlayerBehaviours.DieInstantly:
                reactToPlayer = new DieInstantlyBehaviour();
                break;

            case EnemyReactToPlayerBehaviours.Flee:
                reactToPlayer = new FleeBehaviour();
                break;
        }

        return reactToPlayer;
    }

    private static IIdleBehaviour GetIdleBehaviour(EnemyIdleBehaviours idleBehaviour)
    {
        IIdleBehaviour idle = null;

        switch (idleBehaviour)
        {
            case EnemyIdleBehaviours.StandStill:
                idle = new StandStillBehaviour();
                break;

            case EnemyIdleBehaviours.Patrol:
                idle = new PatrolBehaviour();
                break;

            case EnemyIdleBehaviours.RandomPatrol:
                idle = new RandomPatrolBehaviour();
                break;
        }

        return idle;
    }
}