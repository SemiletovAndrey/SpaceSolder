using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator playerAnimator;

    private Rigidbody _playerRigidbody;
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        Vector3 offset = moveDirection * moveSpeed;
        _playerRigidbody.velocity = offset;
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, rotationSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void RotateCharacterInPlace(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, rotationSpeed / 3, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void PlayerControllerAnimation(bool isMoving)
    {
        int moveForward = 0;
        if (isMoving)
        {
            moveForward = 1;
        }
        playerAnimator.SetInteger("MoveForward", moveForward);
    }
}
