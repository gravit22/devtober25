using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
   
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool lerpCrouch = false;
    private bool crouching = false;
    private bool sprinting = false;
    private float speed; // floating verable for setting the speed of the player.

    // Fields to be modify in the Inspecter
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float jumpHight = 3f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float crouchTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Sets the controller componet.
        controller = GetComponent<CharacterController>();
        // sets the player speed to baseSpeed.
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks to see if the object is touching Ground.
        isGrounded = controller.isGrounded;
        // If the controler is crouching.
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        // Creates a new Vector3 Varable for the X and y movement of the player.
        Vector3 moveDirection = Vector3.zero;
        // Assigns the X of the new Vector3 Verable moveDirection.
        moveDirection.x = input.x;
        // Assigns the Z of the new Vector3 Varable moveDirection.
        moveDirection.z = input.y;
        // Sers the direction and speed of the Charter Coltroller Componet (X,Z Values).
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        // Adds Gravity to the charter.
        playerVelocity.y -= gravity * Time.deltaTime;
        // Checks to see if the player is tuching "Ground" or not if so sets the downword force to 2. Preventing overflow.
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }
        // Sets the gravity force of the player.
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHight * -3f * -(gravity));
        }
    }
    public void Crouch()
    {
        //Toggles the value of crouching to true.
        crouching = !crouching;
        crouchTimer = 0; // Not sure what this is for it was in the totural.
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = sprintSpeed;
        else
            speed = baseSpeed;
    }

}
