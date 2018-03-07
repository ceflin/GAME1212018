using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEnemy : MonoBehaviour {

    int playerHealth = 100;
    int damage = 20;


    private void OnTriggerEnter(Collider Ammo)
    {
        if(Ammo.gameObject.tag == "Player")
        {
            playerHealth -= damage;
            if (playerHealth <= 0)
            {
                Destroy(Ammo.gameObject);

            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
