using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemyBehaviour : MonoBehaviour, ICoroutineRunner
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour player))
        {
            _reactToPlayerBehaviour.React(player);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}


public interface ICoroutineRunner
{
    public Coroutine StartCoroutine(IEnumerator coroutine);
    public void StopCoroutine(Coroutine coroutine);
}