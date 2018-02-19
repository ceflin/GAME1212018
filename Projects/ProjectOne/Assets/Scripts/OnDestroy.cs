using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour {

    //public GameObject bullet;
    //public GameObject enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ammo")
        {
            Destroy(collision.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
