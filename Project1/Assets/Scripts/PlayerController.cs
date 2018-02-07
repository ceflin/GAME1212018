using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //public variables
    public float walkSpeed;
    public float rotationSensitivity = 100f;

    //private variables
    Rigidbody rb;
    Vector3 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
	
	// Update is called once per frame
	void Update () //Non-phiysics steps
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;

        float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");

        Vector3 currentForward = transform.forward;

        Quaternion currentFrameXRotation = Quaternion.AngleAxis(rotationSensitivity * mouseX * Time.deltaTime, Vector3.up);
        transform.forward = currentFrameXRotation * transform.forward;

        //Quaternion currentFrameYRotation = Quaternion.AngleAxis(rotationSensitivity * mouseY * Time.deltaTime, transform.right);
        //transform.forward = currentFrameYRotation * transform.forward;

    }

    private void FixedUpdate() //Physics steps
    {
        Move();
    }

    void Move()
    {
        Vector3 yVelocityFix = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
        rb.velocity += yVelocityFix;
    }
}
