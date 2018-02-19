using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCore : MonoBehaviour {

    public float moveSpeed = 5f;
    public float slowingRadius = 2f;
    public float radiusOfSaticfaction = 0.05f;

    private Vector3 target = Vector3.zero;
    private bool isSeekTargetSet = false;
    private bool isFleePositionSet = false;
    private CharacterController characterController;
    private float deceleration;

	// Use this for initialization
	void Start () {

        characterController = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isSeekTargetSet)
        {

            Vector3 moveDirection = target - transform.position;

            transform.LookAt(target);
            characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

            //if (Vector3.Distance(target, transform.position) <= slowingRadius && Vector3.Distance(target, transform.position) > radiusOfSaticfaction)
            //{
            //    deceleration = (0 - (moveSpeed * moveSpeed)) / (2 * slowingRadius);
            //    moveSpeed += deceleration;

            //    characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
            //}

            if (Vector3.Distance(target, transform.position) <= radiusOfSaticfaction)
            {
                isSeekTargetSet = false;
            }
        } else if (isFleePositionSet)
        {
            Vector3 moveDirection = transform.position - target;
            transform.LookAt(target);
            characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

    }

    public void Seek(Vector3 position)
    {
        target = position;
        target.y = transform.position.y;
        isSeekTargetSet = true;
        isFleePositionSet = false;
    }

    public void Flee(Vector3 position)
    {
        target = position;
        target.y = transform.position.y;
        isFleePositionSet = true;
        isSeekTargetSet = false;
    }
}
