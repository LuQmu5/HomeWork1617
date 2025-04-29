using System;
using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private float _reactToPlayerRange = 10;

    private IIdleBehaviour _idleBehaviour;
    private IReactToPlayerBehaviour _reactToPlayerBehaviour;

    public void Init(IIdleBehaviour idleBehaviour, IReactToPlayerBehaviour reactToPlayerBehaviour)
    {
        if (idleBehaviour == null || reactToPlayerBehaviour == null)
            throw new NullReferenceException("не определен тип поведения для врага");

        _idleBehaviour = idleBehaviour;
        _reactToPlayerBehaviour = reactToPlayerBehaviour;
    }

    private void Start()
    {
        _idleBehaviour.Enter();
    }

    private void FixedUpdate()
    {
        if (IsPlayerInReactRange())
        {
            _reactToPlayerBehaviour.React();
        }
    }

    private bool IsPlayerInReactRange()
    {
        return Physics.OverlapSphere(transform.position, _reactToPlayerRange, _playerMask).Length != 0;
    }
}
