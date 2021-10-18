using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float robert = -300f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isSprinting = false;
    public float sprintingMultiplier;

    Vector3 velocity;
    bool isGrounded;



    /*private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;
    public float slideForce = 400;
    public float slideCounterMovement = 0.2f;*/

    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = robert;
        }

        velocity.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        Vector3 move = new Vector3();
        move = transform.right * x + transform.forward * z;

        if (isSprinting == true)
        {
            move *= sprintingMultiplier;
        }

        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}