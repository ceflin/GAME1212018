using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour {

    

    private void OnTriggerEnter(Collider Ammo)
    {
        if(Ammo.gameObject.tag == "Enemy")
        {
            Destroy(Ammo.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
