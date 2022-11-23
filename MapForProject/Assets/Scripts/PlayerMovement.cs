
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 8.5f;

    //Velocity to store our speed going down
    Vector3 velocity;
    //Gravity variable
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Ground Check Variable
    public Transform groundCheck;
    public float groundDistance = 1.48f;
    public LayerMask groundMask; // <-- What objects the sphere we create should check for
    bool isGrounded; //Boolean for if the player is on the ground

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        //Physics of free fall
        controller.Move(velocity * Time.deltaTime);
    }
}