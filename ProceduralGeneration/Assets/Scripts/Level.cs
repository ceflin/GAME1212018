using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject leftPart;
    public GameObject rightPart;
    public GameObject rightRoom;
    public GameObject leftRoom;
    public GameObject corridor;

    public int height = 20;
    public int width = 20;

    private int[,] twoDimArray;

    private int[,] leftPartArray;
    private int[,] rightPartArray;

    private int[,] leftRoomArray;
    private int[,] rightRoomArray;

    private int roomBottom;
    private int roomLeft;
    private int roomWidth;
    private int roomHeight;

    //private int[,] rightRoom;
    //private int[,] leftRoom;

    // Use this for initialization
    void Start()
    {
        StringBuilder sb = new StringBuilder();

        twoDimArray = new int[height, width];

        for (int i = 0; i < twoDimArray.GetLength(0); ++i)
        {
            for (int j = 0; j < twoDimArray.GetLength(1); ++j)
            {
                print("Tile created at " + i + ", " + j + ".");
            }
        }
        Split();
        CreateRooms();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Divides the space into 2 parts
    private void Split()
    {
        for (int i = 0; i < twoDimArray.GetLength(0); ++ i)
        {
            for (int j = 0; j < twoDimArray.GetLength(1); ++ j)
            {
                if (i < twoDimArray.GetLength(0) / 2)
                {
                    leftPartArray = new int[j, i];
                    print("Tile added to left partition at " + j + ", " + i + ".");
                    Instantiate(leftPart, new Vector3(i, 0, j), Quaternion.identity);
                }
                if (i >= twoDimArray.GetLength(0) / 2)
                {
                    rightPartArray = new int[j, i];
                    print("Tile added to right partition at " + j + ", " + i + ".");
                    Instantiate(rightPart, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
        print(leftPartArray.GetLength(0));
        print(rightPartArray.GetLength(0));
    }

    private void CreateRooms()
    {
        roomWidth = leftPartArray.GetLength(0) - 2;
        roomHeight = leftPartArray.GetLength(1) - 2;
        roomBottom = 1;
        //roomLeft = 


        //for (int i = 0; i < twoDimArray.GetLength(0); ++i)
        //{
        //    for (int j = 0; j < twoDimArray.GetLength(1); ++j)
        //    {
        //        if (i < (twoDimArray.GetLength(0) / 2)-1 && i > 0)
        //        {
        //            leftRoomArray = new int[j, i];
        //            print("Tile added to left room at " + j + ", " + i + ".");
        //            Instantiate(leftRoom, new Vector3(i, 0.1f, j), Quaternion.identity);
        //        }
        //        if (i >= (twoDimArray.GetLength(0) / 2)+1 && 1 < twoDimArray.GetLength(0)-1)
        //        {
        //            rightRoomArray = new int[j, i];
        //            print("Tile added to right room at " + j + ", " + i + ".");
        //            Instantiate(rightRoom, new Vector3(i, 0.1f, j), Quaternion.identity);
        //        }
        //    }
        //}

        for (int i = 0; i < leftPartArray.GetLength(0); ++i)
        {
            for (int j = 0; j < leftPartArray.GetLength(0); ++j)
            {
                if (i < leftPartArray.GetLength(0) - 1 && i > 0)
                {
                    Instantiate(leftRoom, new Vector3(i, 0.1f, j), Quaternion.identity);
                    
                }
            }
        }
    }
    
}
