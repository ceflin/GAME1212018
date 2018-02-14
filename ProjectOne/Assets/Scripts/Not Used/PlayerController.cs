using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 2.0f;
    public float constraintDistance = 5.0f;
    public float rotationSensitivity = 100f;
    //public float maxSpeed = 10.0f;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 targetDirection = new Vector3(0, 0, 1);
            this.transform.position = this.transform.position + targetDirection * Time.deltaTime * this.moveSpeed;
            moveDirection = moveDirection + targetDirection;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 targetDirection = new Vector3(0, 0, -1);
            this.transform.position = this.transform.position + targetDirection * Time.deltaTime * this.moveSpeed;
            moveDirection = moveDirection + targetDirection;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 x = new Vector3(1, 0, 0);
            Vector3 targetDirection = -x;
            this.transform.position = this.transform.position + targetDirection * Time.deltaTime * this.moveSpeed;
            moveDirection = moveDirection + targetDirection;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 x = new Vector3(1, 0, 0);
            Vector3 targetDirection = x;
            this.transform.position = this.transform.position + targetDirection * Time.deltaTime * this.moveSpeed;
            moveDirection = moveDirection + targetDirection;
        }

        transform.position = transform.position + moveDirection.normalized * Time.deltaTime * this.moveSpeed;

        if (transform.position.x > constraintDistance)
        {
            transform.position = new Vector3(constraintDistance, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -constraintDistance)
        {
            transform.position = new Vector3(-constraintDistance, transform.position.y, transform.position.z);
        }

        if (transform.position.z > constraintDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, constraintDistance);
        }

        if (transform.position.z < -constraintDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -constraintDistance);
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 currentForward = transform.forward;

        Quaternion currentFrameXRotation = Quaternion.AngleAxis(rotationSensitivity * mouseX * Time.deltaTime, Vector3.up);
        transform.forward = currentFrameXRotation * transform.forward;

        Quaternion currentFrameYRotation = Quaternion.AngleAxis(rotationSensitivity * mouseY * Time.deltaTime, transform.right);
        transform.forward = currentFrameYRotation * transform.forward;
    }
}
