using System.Collections;
using UnityEngine;

public class FleeBehaviour : IBehaviour
{
    private Transform _transform;
    private Transform _playerTransform;
    private float _fleeSpeed = 10f;
    private float _changeFleeDirectionTime = 2;
    private float _timer;
    private Vector3 _currentFleeDirection;

    public FleeBehaviour(Transform transform, Transform playerTransform)
    {
        _transform = transform;
        _playerTransform = playerTransform;
    }

    public void Enter()
    {
        _timer = 0;
        Debug.Log("ААА МОЯ ОТСТУПАТЬ");
    }

    public void Exit()
    {
        Debug.Log("Фух, моя спокойна");
    }

    public void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;

            Vector3 targetPosition = _transform.position + _currentFleeDirection * _fleeSpeed;
            _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, Time.deltaTime * _fleeSpeed);
        }
        else
        {
            _timer = _changeFleeDirectionTime;

            Vector3 directionToPlayer = (_transform.position - _playerTransform.position).normalized;
            Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            _currentFleeDirection = (directionToPlayer + randomOffset).normalized;
        }
    }
}
