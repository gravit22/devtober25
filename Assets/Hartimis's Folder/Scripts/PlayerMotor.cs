using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
   
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = 9.8f;
    public float jumpHight = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Sets the controller componet.
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
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
        // Checks to see if the player is tuching "Ground" or not.
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

}
