using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //public variables
    public float minimumX = -60f;
    public float maximumX = 60f;
    public float minimumY = -360f;
    public float maximumY = 360;

    public float sensitivityX = 15f;
    public float sensitivityY = 15f;

    public Camera cam;

    public GameObject player;

    //private variables
    float rotationX = 0f;
    float rotationY = 0f;

    Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rotationX += Input.GetAxis("Mouse Y") * sensitivityX;
        rotationY += Input.GetAxis("Mouse X") * sensitivityY;

        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);

    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
