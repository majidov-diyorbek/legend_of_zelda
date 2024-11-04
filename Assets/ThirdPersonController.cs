using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float runSpeedMultiplier = 2.0f;  // To make it run

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        // Get the CharacterController attached to the player object
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // Get input for horizontal (A/D or left/right) and vertical (W/S or up/down) movement
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            // Check if the player is running (holding Shift)
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= speed * runSpeedMultiplier; // Running
            }
            else
            {
                moveDirection *= speed;  // Normal walking
            }

            // Jumping if the player presses the jump button (space by default)
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character based on calculated movement
        controller.Move(moveDirection * Time.deltaTime);
    }
}