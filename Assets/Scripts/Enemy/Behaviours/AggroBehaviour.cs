using System.Collections;
using UnityEngine;

public class AggroBehaviour : IBehaviour
{
    private Transform _transform;
    private Transform _playerTransform;
    private float _followSpeed = 5;

    public AggroBehaviour(Transform transform, Transform playerTransform)
    {
        _transform = transform;
        _playerTransform = playerTransform;

    }

    public void Enter()
    {
        Debug.Log("Моя заагрица на кого-то");
    }

    public void Exit()
    {
        Debug.Log("Моя узбагоица");
    }

    public void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _playerTransform.position, _followSpeed * Time.deltaTime);
    }
}
