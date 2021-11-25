using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;

    public CharacterController characterController; // for the character
    //Gravity
    private float gravity = -50f;
    // Vector3
    private Vector3 velocity;
    //GroundCheck
    private bool isGrounded;
    // Movement (Only Horizontal)
    private float horizontalInput; //


    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // Calls the Character.
    }

    void Update()    // Update is called once per frame.
    {
        horizontalInput = 1;

        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        // IsGrounded
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0) // Applies gravity if Character is NOT grounded.
        {
            velocity.y = 0;
        }
        else
        {
        //Gravity added.
        velocity.y += gravity * Time.deltaTime; // Delta time for framerate indipendent. 
        }

        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);

        // JUMP
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //Velocity.
        characterController.Move(velocity * Time.deltaTime);

    }
}
