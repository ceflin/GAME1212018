using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Assets;

public class TreeRectDebug : MonoBehaviour
{
    public int levelWidth = 8;
    public int levelHeight = 8;

    // Use this for initialization
    void Start()
    {
        BinaryTree<RectInt> sampleRectTree;
        sampleRectTree = new BinaryTree<RectInt>(new RectInt(0, 0, levelWidth, levelHeight));

        int partitionWidth = levelWidth / 2;
        int partitionHeight = levelHeight;

        RectInt leftPartitionRect = new RectInt(0, 0, partitionWidth, partitionHeight);
        BinaryTreeNode<RectInt> leftPartitionNode = sampleRectTree.Root().AddChild(leftPartitionRect);

        int rightPartitionX = levelWidth / 2;
        int rightPartitionY = 0;

        RectInt rightPartitionRect = new RectInt(rightPartitionX, rightPartitionY, partitionWidth, partitionHeight);
        BinaryTreeNode<RectInt> rightPartitionNode = sampleRectTree.Root().AddChild(rightPartitionRect);

        RectInt leftPartitionWorld = NodeRectWorld(leftPartitionNode);
        RectInt RightPartitionWorld = NodeRectWorld(rightPartitionNode);

        //print("Left: " + leftPartitionWorld);
        //print("Right: " + RightPartitionWorld);

        //split horizontally
        int halfPartHeight = partitionHeight / 2;
        RectInt lowerLeftPartRect = new RectInt(0, 0, partitionWidth, halfPartHeight);
        BinaryTreeNode<RectInt> lowerLeftPartNode = leftPartitionNode.AddChild(lowerLeftPartRect);

        int upperLeftPartX = 0;
        int upperLeftPartY = partitionHeight / 2;
        RectInt UpperLeftPartRect = new RectInt(upperLeftPartX, upperLeftPartY, partitionWidth, halfPartHeight);
        BinaryTreeNode<RectInt> upperLeftPartNode = leftPartitionNode.AddChild(UpperLeftPartRect);

        RectInt lowerRightPartRect = new RectInt(0, 0, partitionWidth, halfPartHeight);
        BinaryTreeNode<RectInt> lowerRightPartNode = rightPartitionNode.AddChild(lowerRightPartRect);

        int upperRightPartX = 0;
        int upperRightPartY = partitionHeight / 2;
        RectInt UpperRightPartRect = new RectInt(upperRightPartX, upperRightPartY, partitionWidth, halfPartHeight);
        BinaryTreeNode<RectInt> upperRightPartNode = rightPartitionNode.AddChild(UpperRightPartRect);

        RectInt lowerLeftPartWorld = NodeRectWorld(lowerLeftPartNode);
        RectInt upperLeftPartWorld = NodeRectWorld(upperLeftPartNode);
        RectInt lowerRightPartWorld = NodeRectWorld(lowerRightPartNode);
        RectInt upperRightPartWorld = NodeRectWorld(upperRightPartNode);

        print("Lower left : " + lowerLeftPartWorld);
        print("Upper left : " + upperLeftPartWorld);
        print("Lower Right : " + lowerRightPartWorld);
        print("Upper Right : " + upperRightPartWorld);

        string[,] levelArray = new string[levelWidth, levelHeight];

        for (int x = lowerLeftPartWorld.x; x < lowerLeftPartWorld.x + lowerLeftPartWorld.width; x++)
        {
            for (int y = lowerLeftPartWorld.y; y < lowerLeftPartWorld.y + lowerLeftPartWorld.height; y++)
            {
                levelArray[x, y] = "1 ";
            }
        }
        for (int x = upperLeftPartWorld.x; x < upperLeftPartWorld.x + upperLeftPartWorld.width; x++)
        {
            for (int y = upperLeftPartWorld.y; y < upperLeftPartWorld.y + upperLeftPartWorld.height; y++)
            {
                levelArray[x, y] = "2 ";
            }
        }
        for (int x = lowerRightPartWorld.x; x < lowerRightPartWorld.x + lowerRightPartWorld.width; x++)
        {
            for (int y = lowerRightPartWorld.y; y < lowerRightPartWorld.y + lowerRightPartWorld.height; y++)
            {
                levelArray[x, y] = "3 ";
            }
        }
        for (int x = upperRightPartWorld.x; x < upperRightPartWorld.x + upperRightPartWorld.width; x++)
        {
            for (int y = upperRightPartWorld.y; y < upperRightPartWorld.y + upperRightPartWorld.height; y++)
            {
                levelArray[x, y] = "4 ";
            }
        }

        StringBuilder contentBuilder = new StringBuilder();
        for (int x = 0; x < levelArray.GetLength(0); x++)
        {
            for (int y = 0; y < levelArray.GetLength(1); y++)
            {
                contentBuilder.Append(levelArray[x, y]);
            }
            contentBuilder.AppendLine("");
        }

        string content = contentBuilder.ToString();
        File.WriteAllText("C:\\Users\\svc-student\\Desktop\\sample.bspd", content);

    }

    private RectInt NodeRectWorld(BinaryTreeNode<RectInt> node)
    {
        BinaryTreeNode<RectInt> current = node;
        RectInt rectWorld = node.Value();
        rectWorld.x = 0;
        rectWorld.y = 0;
        while (current != null)
        {
            rectWorld.x += current.Value().x;
            rectWorld.y += current.Value().y;

            current = current.parent;
        }
        return rectWorld;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
