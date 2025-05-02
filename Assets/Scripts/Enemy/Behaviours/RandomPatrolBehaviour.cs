using System.Collections;
using TMPro;
using UnityEngine;

public class RandomPatrolBehaviour : IBehaviour
{
    private Transform _transform;
    private float _patrolSpeed = 4f;
    private float _switchDirectionTime = 2;
    private float _timer = 2;
    private Vector3 _currentDirection;

    public RandomPatrolBehaviour(Transform transform)
    {
        _transform = transform;
    }

    public void Enter()
    {
        Debug.Log("начинаю и рандомно хожу туда-сюда");
    }

    public void Exit()
    {
        Debug.Log("усталь");
    }

    public void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;

            _transform.position = Vector3.MoveTowards(_transform.position, _currentDirection, Time.deltaTime * _patrolSpeed);
        }
        else
        {
            _timer = _switchDirectionTime;

            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            _currentDirection = _transform.position + randomDirection * _patrolSpeed;
        }
    }
}
