using System.Collections;
using UnityEngine;

public class StandStillBehaviour : IIdleBehaviour
{
    private Transform _transform;
    private ICoroutineRunner _coroutineRunner;
    private float _rotationSpeed = 10;
    private Coroutine _coroutine;

    public StandStillBehaviour(Transform transform, ICoroutineRunner coroutineRunner)
    {
        _transform = transform;
        _coroutineRunner = coroutineRunner;
    }

    public void Enter()
    {
        _coroutine = _coroutineRunner.StartCoroutine(Idling());
    }

    public void Exit()
    {
        _coroutineRunner.StopCoroutine(_coroutine);
    }

    private IEnumerator Idling()
    {
        while (true)
        {
            Debug.Log("Стою");
            Quaternion targetRotation = Quaternion.Euler(_transform.eulerAngles * Random.Range(0.1f, 0.9f));
            float timer = 1;

            while (_transform.rotation != targetRotation && timer > 0)
            {
                _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
                timer -= Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}
