using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public int points = 0;
    public float gravity = -9.81f;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    public bool isGrounded;
    private Vector3 velocity;

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance + 0.1f);

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
    }
}
