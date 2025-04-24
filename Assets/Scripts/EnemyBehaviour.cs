using System.Collections;
using UnityEngine;

public enum IdleBehavior
{
    StandStill,
    Patrol,
    RandomWalk
}

public enum ReactionBehavior
{
    Flee,
    Chase,
    DieInstantly
}

public class EnemyBehaviour : MonoBehaviour
{
    private IdleBehavior _idleBehavior;
    private ReactionBehavior _reactionBehavior;

    private Transform[] _patrolPoints;
    private Transform _playerTransform;

    private float _aggroRadius = 10f;
    private float _moveSpeed = 10f;
    private bool _isAggroed = false;
    private int _currentPatrolIndex = 0;

    public void Init(IdleBehavior idleBehavior, ReactionBehavior reactionBehavior, Transform palyerTransform, Transform[] patrolPoints)
    {
        _idleBehavior = idleBehavior;
        _reactionBehavior = reactionBehavior;
        _playerTransform = palyerTransform;
        _patrolPoints = patrolPoints;
    }

    private void Update()
    {
        if (!_isAggroed && Vector3.Distance(_playerTransform.position, transform.position) < _aggroRadius)
        {
            _isAggroed = true;
            ReactToPlayer();
        }

        if (_isAggroed && Vector3.Distance(_playerTransform.position, transform.position) > _aggroRadius)
        {
            _isAggroed = false;
            StartCoroutine(IdleBehaviorRoutine());
        }
    }

    private void ReactToPlayer()
    {
        switch (_reactionBehavior)
        {
            case ReactionBehavior.Flee:
                FleeFromPlayer();
                break;
            case ReactionBehavior.Chase:
                ChasePlayer();
                break;
            case ReactionBehavior.DieInstantly:
                Die();
                break;
        }
    }

    private void FleeFromPlayer()
    {
        Vector3 fleeDirection = (transform.position - _playerTransform.position).normalized;
        transform.position += fleeDirection * Time.deltaTime * _moveSpeed;
    }

    private void ChasePlayer()
    {
        Vector3 chaseDirection = (_playerTransform.position - transform.position).normalized;
        transform.position += chaseDirection * Time.deltaTime * _moveSpeed;
    }

    private void Die()
    {
        // Эффект смерти (например, частицы)
        Destroy(gameObject);
    }

    private IEnumerator IdleBehaviorRoutine()
    {
        switch (_idleBehavior)
        {
            case IdleBehavior.StandStill:
                yield break;
            case IdleBehavior.Patrol:
                Patrol();
                break;
            case IdleBehavior.RandomWalk:
                RandomWalk();
                break;
        }
    }

    private void Patrol()
    {
        Vector3 targetPosition = _patrolPoints[_currentPatrolIndex].position;
        float step = _moveSpeed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        }
    }

    private void RandomWalk()
    {
        Vector3 randomDirection = Random.insideUnitSphere;
        randomDirection.y = 0f;
        transform.position += randomDirection.normalized * Time.deltaTime * _moveSpeed;
    }
}
