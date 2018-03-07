using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public float speed = 5.0f;
    public float constraintDistance = 5.0f;
    public float ammoSpeed = 6.0f;

    float bulletLife = .5f;

    public GameObject ammo;
    public Transform ammoSpawn;

    // Use this for initialization
    void Start () {

        Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        horizontal *= Time.deltaTime;
        vertical *= Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(ammo, ammoSpawn.position, ammoSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ammoSpeed;

        Destroy(bullet, bulletLife);
    }
}
