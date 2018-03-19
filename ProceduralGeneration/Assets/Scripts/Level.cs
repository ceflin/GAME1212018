using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int height = 20;
    public int width = 20;

    private int[,] twoDimArray;

    private int[,] leftPart;
    private int[,] rightPart;

    private int roomTop;
    private int roomLeft;
    private int roomWidth;
    private int roomHeight;

    private int[,] rightRoom;
    private int[,] leftRoom;

    // Use this for initialization
    void Start()
    {
        twoDimArray = new int[height, width];

        for (int i = 0; i < twoDimArray.GetLength(0); ++i)
        {
            for (int j = 0; j < twoDimArray.GetLength(1); ++j)
            {
                print("Tile created at " + i + ", " + j + ".");
            }
        }
        Split();
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
                    leftPart = new int[i, j];
                    print("Tile added to left partition at " + i + ", " + j + ".");
                }
                if (i >= twoDimArray.GetLength(0) / 2)
                {
                    rightPart = new int[i, j];
                    print("Tile added to right partition at " + i + ", " + j + ".");
                }
            }
        }
    }

    private void CreateRooms()
    {

    }
    
}
