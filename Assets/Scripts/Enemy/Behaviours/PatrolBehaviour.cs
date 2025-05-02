using System.Collections;
using UnityEngine;

public class PatrolBehaviour : IBehaviour
{
    private Transform _transform;
    private Transform[] _patrolPoints;
    private float _patrolSpeed = 5;
    private int _currentPatrolPointIndex = 0;

    public PatrolBehaviour(Transform transform, Transform[] patrolPoints)
    {
        _transform = transform;
        _patrolPoints = patrolPoints;
    }

    public void Enter()
    {
        Debug.Log("начинаю патруль");
    }

    public void Exit()
    {
        Debug.Log("оканчиваю патруль");
    }

    public void Update()
    {
        Vector3 destination = _patrolPoints[_currentPatrolPointIndex].position;

        if (CurrentPatrolPointReached(destination) == false)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, destination, _patrolSpeed * Time.deltaTime);
        }
        else
        {
            SwitchCurrentPatrolPoint();
        }
    }

    private bool CurrentPatrolPointReached(Vector3 destination)
    {
        float minOffset = 1;

        return Vector3.Distance(_transform.position, destination) <= minOffset;
    }

    private void SwitchCurrentPatrolPoint()
    {
        _currentPatrolPointIndex++;

        if (_currentPatrolPointIndex >= _patrolPoints.Length)
            _currentPatrolPointIndex = 0;
    }
}
