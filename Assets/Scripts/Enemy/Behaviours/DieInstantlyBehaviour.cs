using UnityEngine;

public class DieInstantlyBehaviour : IReactToPlayerBehaviour
{
    private EnemyBehaviour _behaviour;

    public DieInstantlyBehaviour(EnemyBehaviour behaviour)
    {
        _behaviour = behaviour;
    }

    public void React(PlayerBehaviour player)
    {
        Debug.Log("ОН ИДЕТ! СЛИШКОМ СТРАШНО! БАБАХ");
        _behaviour.Die();
    }
}
