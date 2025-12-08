using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    private float xInput;
    private float yInput;
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private bool instantAcceleration = true;
    [SerializeField] private float jumpForce = 8;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Move();

        if (JumpInputDetected())
            Jump();
    }

    private void Move()
    {
        //Course directs to use GetAxisRaw for instant input response and GetAxis for smoothed input so we allow both
        xInput = (instantAcceleration ? Input.GetAxisRaw(Constants.HORIZONTAL_INPUT) : Input.GetAxis(Constants.HORIZONTAL_INPUT));

        //Course directs to create a new Vector2 each frame, but this is more efficient
        rb.linearVelocityX = xInput * moveSpeed;
    }
    private static bool JumpInputDetected()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(1);
    }


    private void Jump()
    {
        rb.linearVelocityY += jumpForce;
    }
}