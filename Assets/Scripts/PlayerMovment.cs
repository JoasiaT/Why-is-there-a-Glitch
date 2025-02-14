using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public int points = 0;
    //public float jumpSpeed = 5f;
    //public float jumpHeight = 7f;
    public float gravity = -9.81f;
    //public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    public bool isGrounded;
    private Vector3 velocity;

    //public float spaceBar = 2f;


    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance + 0.1f);

        // float SpaceBar = Input.GetAxis("Jump") * Time.deltaTime;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);//delta  wzor -> (delta - symbol)y=1(pzez)2 * g * t

        //if (Input.GetButtonDown("Jump"))// && isGrounded)
        //{
            //  velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //(Input.GetKey(KeyCode.Space));
            //Sqrt -> pierwiastek
        //}
        //wzor -> v = (pierwiastek 2 stopnia z) h * - 2 * g

    }
}
