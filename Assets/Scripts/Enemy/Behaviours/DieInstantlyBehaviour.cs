using UnityEngine;

public class DieInstantlyBehaviour : IBehaviour
{
    private IDiableActor _diableActor;

    public DieInstantlyBehaviour(IDiableActor diableActor)
    {
        _diableActor = diableActor;
    }

    public void Enter()
    {
        Debug.Log("ОН ИДЕТ! СЛИШКОМ СТРАШНО! БАБАХ");
        _diableActor.Die();
    }

    public void Exit()
    {
        Debug.Log("Хвааатит... он уже и так мёртв... ПЛАК");
    }

    public void Update()
    {
        Debug.Log("Если вдруг захочу умереть не моментально");
    }
}
