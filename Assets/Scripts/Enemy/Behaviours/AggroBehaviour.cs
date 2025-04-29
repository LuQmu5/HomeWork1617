using System.Collections;
using UnityEngine;

public class AggroBehaviour : IReactToPlayerBehaviour
{
    private Transform _transform;
    private ICoroutineRunner _coroutineRunner;
    private float _followSpeed = 5;

    public AggroBehaviour(Transform transform, ICoroutineRunner coroutineRunner)
    {
        _transform = transform;
        _coroutineRunner = coroutineRunner;
    }

    public void React(PlayerBehaviour player)
    {
        Debug.Log("У моя бить");
        _coroutineRunner.StartCoroutine(Following(player.transform));   
    }

    private IEnumerator Following(Transform playerTransform)
    {
        while (true)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, playerTransform.position, _followSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
