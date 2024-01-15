using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const float LANE_DISTANCE = 2.0f;
    private const float ROTATION_SPEED = 0.05f;

    private CharacterController characterController;
    private Animator animator;
    private float gravity = 15f;
    private float verticalVelocity;
    private float jumpForce = 4.5f;
    private float speed = 7.0f;
    private int lane = 0; // 0 = left, 1 = right


    private void Start()
    {
        // Get references to the CharacterController and Animator components attached to the GameObject
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check left, right inputs (mobil, editorswipe, keyboard)
        if (SwipeDetection.Instance.SwipeLeft || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            SwitchLane(false);
        }
        if (SwipeDetection.Instance.SwipeRight || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            SwitchLane(true);
        }

        // Calculate the target position based on the current lane
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (lane == 1)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }

        // Calculate the movement vector to smoothly move the character towards the target position
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed; // Where we should be - where we are

        // Check if the character is grounded
        bool isGrounded = IsGrounded();
        animator.SetBool("Grounded", isGrounded);

        // Handle jumping logic if the character is grounded
        if (isGrounded)
        {
            verticalVelocity = -0.1f;
            // Check jump input (mobil, editorswipe, keyboard)
            if (SwipeDetection.Instance.SwipeUp || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                animator.SetTrigger("JumpWhileRunning");
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            // Apply gravity if the character is in the air
            verticalVelocity -= (gravity * Time.deltaTime);

            // Check fast falling input (mobil, editorswipe, keyboard)
            if (SwipeDetection.Instance.SwipeDown || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                verticalVelocity = -jumpForce;
            }
        }
        moveVector.y = verticalVelocity;

        // Move the character using the CharacterController
        characterController.Move(moveVector * Time.deltaTime);

        // Update the character's forward direction to face the movement direction
        Vector3 direction = characterController.velocity;
        direction.z = speed; // Imitates movement forward, aligns with starting position
        direction.y = 0;
        transform.forward = Vector3.Lerp(transform.forward, direction, ROTATION_SPEED);
        direction.z = speed; // Imitates movement forward, aligns with starting position
    }

    // Method to switch lanes
    private void SwitchLane(bool goingRight)
    {
        if (goingRight == true)
        {
            lane++;
            if (lane == 2)
            {
                lane = 1;
            }
        }
        else
        {
            lane--;
            if (lane == -1)
            {
                lane = 0;
            }
        }
    }

    // Method to check if the character is grounded
    private bool IsGrounded()
    {
        // Check if the character's y position is above a certain threshold to determine if it's grounded
        if (transform.position.y > 0.65f)
        {
            return false;
        }
        else
        {
            return true;
        }          
    }
}