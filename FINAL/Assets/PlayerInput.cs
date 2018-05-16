using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    public float moveSpeed = 5.0f;
    public float raycastDistance = 100.0f;

    [SerializeField] Vector3 targetPos;
    [SerializeField] bool isWalking;

    private RaycastHit hit;
    #endregion

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, raycastDistance))
            {
                object ob = hit.collider.gameObject;
                Debug.Log(ob + " hit @ " + hit.point);

                if (hit.collider.gameObject.layer.Equals(8))
                {
                    Debug.Log("clickable.");
                    targetPos = hit.point;
                    this.transform.LookAt(targetPos);
                    isWalking = true;
                    MoveToPosition(isWalking);
                    //if (this.transform.position != targetPos)
                    //{
                    //    this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
                    //}
                }
            }
        }
    }

    void MoveToPosition(bool isWalking)
    {
        if (isWalking)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}
