using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    public Transform target;

    public float constraintDistance = 5.0f;
    public float ammoSpeed = 6.0f;
    public float moveSpeed = 2.5f;
    float bulletLife = .5f;

    public GameObject ammo;
    public Transform ammoSpawn;

    public LayerMask raycastLayers;

    public float rayDistance = 10f;

    private Vector3 rayCollisionNormal;
    private Vector3 hitLocationThisFrame = Vector3.zero;
    private bool hitThisFrame = false;
    private float timer = 1f;

    //InvokeRepeating("Fire", 1, 1);

    

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        hitThisFrame = false;

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
            //Fire();
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0,45,0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, -45, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, 35, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, -35, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, 25, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, -25, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, 15, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, -15, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, 5, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }
        if (Physics.Raycast(transform.position, Quaternion.Euler(0, -5, 0) * transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast hit" + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            transform.LookAt(target);
        }

        if (hitThisFrame)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Fire();
                timer += 1;
            }
            
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0,45,0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, -45, 0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 35, 0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, -35, 0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 25, 0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, -25, 0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 15, 0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, -15, 0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 5, 0) * transform.forward * rayDistance);
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, -5, 0) * transform.forward * rayDistance);

        if (hitThisFrame)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(hitLocationThisFrame, hitLocationThisFrame + rayCollisionNormal);
        }
    }
    private void Fire()
    {
        var bullet = (GameObject)Instantiate(ammo, ammoSpawn.position, ammoSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * ammoSpeed;

        Destroy(bullet, bulletLife);
    }
}
