using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{

    public Vector2 moveValue;
    // Movement variables
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float moveSpeed = 5f;
    public float crouchModifier = 0.5f;
    public float sprintModifier = 1.5f;

    //Movement Bools
    public bool isCrouching = false;
    public bool isSprinting = false;

    // Camera Look variables
    public float mouseSensitivity = 10f;
    public Transform playerCamera;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    private float xRotation = 0f;

    private Vector2 moveInput;
    private Vector2 lookInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GetComponent<CharacterController>() != null)
        {
            characterController = GetComponent<CharacterController>();
        }        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Ground Check
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep player grounded
        }
        
        // Apply Movement
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        float finalMoveSpeed = moveSpeed;
        if (isSprinting) 
        {
            finalMoveSpeed = moveSpeed * sprintModifier;
        }
        if (isCrouching) 
        { 
            finalMoveSpeed = moveSpeed * crouchModifier; 
        }
        characterController.Move(move * finalMoveSpeed * Time.deltaTime);

        // Apply Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // Camera Look
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40f, 40f); // Clamp vertical rotation

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void OnCrouch(InputValue value)
    {
        isCrouching = !isCrouching;
        //do crouching change
    }

    public void OnSprint(InputValue value)
    {
        isSprinting = !isSprinting;
        //set this to only on hold
    }
}
