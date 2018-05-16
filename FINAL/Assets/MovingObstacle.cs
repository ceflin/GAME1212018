using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
#region Variables
    public float moveSpeed = 3.0f;

    Vector3 moveDir;

    [SerializeField] private bool movingRight;
    [SerializeField] private bool movingLeft;
#endregion
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movingRight = true;
            MoveObstacle();
        }
    }

    void MoveObstacle()
    {
        if (movingRight)
            moveDir = new Vector3(1, 0, 0);
            transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
