using System.Collections;
using UnityEngine;

public class PatrolBehaviour : IIdleBehaviour
{
    private Transform _transform;
    private ICoroutineRunner _coroutineRunner;
    private Transform[] _patrolPoints;
    private float _patrolSpeed = 5;
    private int _currentPatrolPointIndex = 0;
    private Coroutine _coroutine;

    public PatrolBehaviour(Transform transform, ICoroutineRunner coroutineRunner, Transform[] patrolPoints)
    {
        _transform = transform;
        _coroutineRunner = coroutineRunner;
        _patrolPoints = patrolPoints;
    }

    public void Enter()
    {
        Debug.Log("начинаю патруль");
        _coroutine = _coroutineRunner.StartCoroutine(Patroling());
    }

    public void Exit()
    {
        _coroutineRunner.StopCoroutine(_coroutine);
    }

    private IEnumerator Patroling()
    {
        while (true)
        {
            Vector3 destination = _patrolPoints[_currentPatrolPointIndex].position;

            while (Vector3.Distance(_transform.position, destination) > 1)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, destination, _patrolSpeed * Time.deltaTime);

                yield return null;
            }

            _currentPatrolPointIndex++;

            if (_currentPatrolPointIndex >= _patrolPoints.Length)
            {
                _currentPatrolPointIndex = 0;
            }
        }
    }
}
