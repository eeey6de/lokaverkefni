using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9f;

    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private float lookXLimit = 80f;


    private float rotationX = 0f;
    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;
    private Vector2 lookInput;
    private Camera playerCamera;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = Camera.main;
        // Cursor.lockState = CursorLockMode.Locked;  // uncomment later
        // Cursor.visible = false; // uncomment later
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // færa input
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // hoppa
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        // hreyfingar
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y; // vektor af færa input
        controller.Move(move * speed * Time.deltaTime); // færa af leikmann
        velocity.y += gravity * Time.deltaTime; // detta
        controller.Move(velocity * Time.deltaTime); // færa af umhverfi
        // snúningur
        transform.Rotate(Vector3.up * lookInput.x * lookSpeed * Time.deltaTime); // snúningur líkama
        rotationX -= lookInput.y * lookSpeed * Time.deltaTime; // myndavélasnúningur
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); // ekki brjóta háls spilara

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); // snúa myndavél

    }
}
