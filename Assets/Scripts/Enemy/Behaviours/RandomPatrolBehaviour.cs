using System.Collections;
using UnityEngine;

public class RandomPatrolBehaviour : IIdleBehaviour
{
    private Transform _transform;
    private ICoroutineRunner _coroutineRunner;
    private float _patrolSpeed = 4f;
    private Coroutine _coroutine;

    public RandomPatrolBehaviour(Transform transform, ICoroutineRunner coroutineRunner)
    {
        _transform = transform;
        _coroutineRunner = coroutineRunner;
    }

    public void Enter()
    {
        Debug.Log("рандомно хожу туда-сюда");
        _coroutine = _coroutineRunner.StartCoroutine(RandomPatrolling());
    }

    public void Exit()
    {
        if (_coroutine != null)
            _coroutineRunner.StopCoroutine(_coroutine);
    }

    private IEnumerator RandomPatrolling()
    {
        while (true)
        {
            float minTimer = 1f;
            float maxTimer = 3f;
            float timer = Random.Range(minTimer, maxTimer);

            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            Vector3 targetPosition = _transform.position + randomDirection * _patrolSpeed;

            while (timer > 0f)
            {
                timer -= Time.deltaTime;

                _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, Time.deltaTime * _patrolSpeed);

                yield return null;
            }
        }
    }
}
