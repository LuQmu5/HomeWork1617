using System;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IDiableActor
{
    private IBehaviour _currentBehaviour;

    private IBehaviour _idleBehaviour;
    private IBehaviour _reactToPlayerBehaviour;

    public void Init(IBehaviour idleBehaviour, IBehaviour reactToPlayerBehaviour)
    {
        if (idleBehaviour == null || reactToPlayerBehaviour == null)
            throw new NullReferenceException("не определен тип поведения для врага");

        _idleBehaviour = idleBehaviour;
        _reactToPlayerBehaviour = reactToPlayerBehaviour;
    }

    private void Start()
    {
        _currentBehaviour = _idleBehaviour;
        _currentBehaviour.Enter();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour player))
        {
            SwitchBehaviour(_reactToPlayerBehaviour);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour player))
        {
            SwitchBehaviour(_idleBehaviour);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void SwitchBehaviour(IBehaviour newBehaviour)
    {
        _currentBehaviour?.Exit();
        _currentBehaviour = newBehaviour;
        _currentBehaviour.Enter();
    }
}