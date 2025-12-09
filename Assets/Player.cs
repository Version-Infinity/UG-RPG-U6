using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float xInput;
    private bool rotatedLeft = false;

    [SerializeField] private CharacterDirection currentDirection = CharacterDirection.Right;
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private bool instantAcceleration = true;
    [SerializeField] private float jumpForce = 8;

    public Rigidbody2D body;
    public Animator animator;

    private enum CharacterDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    private void Awake()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();
        
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        //Ensure player is facing the correct direction on start
        HandleOrientation();
    }

    private void Update()
    {
        HandleMovement();
        HandleAnimation();
        HandleOrientation();
    }

    [ContextMenu("Flip Player")]
    private void HandleOrientation()
    {
        if ((currentDirection == CharacterDirection.Left && !rotatedLeft) || (currentDirection != CharacterDirection.Left && rotatedLeft))
        {
            transform.Rotate(0, 180, 0);
            rotatedLeft = !rotatedLeft;
        }
    }

    private void HandleAnimation()
    { 
        animator.SetBool("isMoving", xInput != 0);
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
        
        if(xInput != 0)
            currentDirection = xInput < 0 ? CharacterDirection.Left : CharacterDirection.Right;

        //Course directs to create a new Vector2 each frame, but this is more efficient
        body.linearVelocityX = xInput * moveSpeed;
    }
    private static bool JumpInputDetected()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1);
    }


    private void Jump()
    {
        body.linearVelocityY += jumpForce;
    }
}