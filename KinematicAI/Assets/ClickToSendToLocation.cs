using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToSendToLocation : MonoBehaviour {
    public KinematicCore controlledAI;
    public LayerMask floorOnlyMask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hitInfo, 1000, floorOnlyMask.value))
            {
                if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
                {
                    controlledAI.Flee(hitInfo.point);
                    print(hitInfo.point);
                }
                else
                {
                    controlledAI.Seek(hitInfo.point);
                    print(hitInfo.point);
                }
            }
        }
		
	}
}
