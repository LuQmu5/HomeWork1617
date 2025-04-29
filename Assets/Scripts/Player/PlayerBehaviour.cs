using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerBehaviour : MonoBehaviour
{
    private const string VerticalAxis = "Vertical";
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private CharacterController _controller;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 input = GetInput();
        _moveDirection = CalculateMoveDirection(input);
        RotateTowardsMoveDirection(_moveDirection);
        Move(_moveDirection);
    }

    private Vector2 GetInput()
    {
        float horizontal = Input.GetAxisRaw(HorizontalAxis);
        float vertical = Input.GetAxisRaw(VerticalAxis);
        return new Vector2(horizontal, vertical).normalized;
    }

    private Vector3 CalculateMoveDirection(Vector2 input)
    {
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        return (right * input.x + forward * input.y).normalized;
    }

    private void RotateTowardsMoveDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Move(Vector3 direction)
    {
        _controller.Move(direction * _moveSpeed * Time.deltaTime);
    }
}
