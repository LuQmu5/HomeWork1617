using System.Collections;
using UnityEngine;

public class FleeBehaviour : IReactToPlayerBehaviour
{
    private Transform _transform;
    private ICoroutineRunner _coroutineRunner;
    private float _fleeSpeed = 10f;

    public FleeBehaviour(Transform transform, ICoroutineRunner coroutineRunner)
    {
        _transform = transform;
        _coroutineRunner = coroutineRunner;
    }

    public void React(PlayerBehaviour playerBehaviour)
    {
        Debug.Log("ААААА БИЖИМ");
        _coroutineRunner.StartCoroutine(Fleeing(playerBehaviour.transform));
    }

    private IEnumerator Fleeing(Transform playerTransform)
    {
        while (true)
        {
            float minTimer = 1f;
            float maxTimer = 3f;
            float timer = Random.Range(minTimer, maxTimer);

            Vector3 directionToPlayer = (_transform.position - playerTransform.position).normalized;
            Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            Vector3 fleeDirection = (directionToPlayer + randomOffset).normalized;

            Vector3 targetPosition = _transform.position + fleeDirection * _fleeSpeed;

            while (timer > 0f)
            {
                timer -= Time.deltaTime;

                _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, Time.deltaTime * _fleeSpeed);

                yield return null;
            }
        }
    }
}
