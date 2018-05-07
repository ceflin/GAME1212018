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
        
        RectInt leftPartitionRect = new RectInt();
        BinaryTreeNode<RectInt> leftPartitionNode = null;
        leftPartitionNode = SplitFromRoot(0, 0, sampleRectTree, leftPartitionNode, leftPartitionRect);

        int partitionWidth = levelWidth / 2;
        int partitionHeight = levelHeight;
        //RectInt leftPartitionRect = new RectInt();
        //BinaryTreeNode<RectInt> leftPartitionNode = null;
        //leftPartitionNode = SplitFromRoot(0, 0, partitionWidth, partitionHeight, sampleRectTree, leftPartitionNode, leftPartitionRect);

        //RectInt leftPartitionRect = new RectInt(0, 0, partitionWidth, partitionHeight);
        //BinaryTreeNode<RectInt> leftPartitionNode = sampleRectTree.Root().AddChild(leftPartitionRect);

        int rightPartitionX = levelWidth / 2;
        RectInt rightPartitionRect = new RectInt();
        BinaryTreeNode<RectInt> rightPartitionNode = null;

        rightPartitionNode = SplitFromRoot(rightPartitionX, 0, sampleRectTree, rightPartitionNode, rightPartitionRect);

        //RectInt rightPartitionRect = new RectInt(rightPartitionX, 0, partitionWidth, partitionHeight);
        //BinaryTreeNode<RectInt> rightPartitionNode = sampleRectTree.Root().AddChild(rightPartitionRect);

        RectInt leftPartitionWorld = NodeRectWorld(leftPartitionNode);
        RectInt RightPartitionWorld = NodeRectWorld(rightPartitionNode);
        
        //split horizontally
        //int halfPartHeight = partitionHeight / 2;

        //RectInt lowerLeftPartRect = new RectInt(0, 0, partitionWidth, halfPartHeight);
        //BinaryTreeNode<RectInt> lowerLeftPartNode = leftPartitionNode.AddChild(lowerLeftPartRect);

        RectInt lowerLeftPartRect = new RectInt();
        BinaryTreeNode<RectInt> lowerLeftPartNode = null;
        lowerLeftPartNode = SplitFromLeaf(0, 0, leftPartitionNode, lowerLeftPartNode, lowerLeftPartRect);


        int partition2Y = partitionHeight / 2;
        RectInt upperLeftPartRect = new RectInt();
        BinaryTreeNode<RectInt> upperLeftPartNode = null;
        upperLeftPartNode = SplitFromLeaf(0, partition2Y, leftPartitionNode, upperLeftPartNode, upperLeftPartRect);

        //RectInt UpperLeftPartRect = new RectInt(upperLeftPartX, upperLeftPartY, partitionWidth, halfPartHeight);
        //BinaryTreeNode<RectInt> upperLeftPartNode = leftPartitionNode.AddChild(UpperLeftPartRect);

        RectInt lowerRightPartRect = new RectInt();
        BinaryTreeNode<RectInt> lowerRightPartNode = null;
        lowerRightPartNode = SplitFromLeaf(0, 0, rightPartitionNode, lowerRightPartNode, lowerRightPartRect);

        //RectInt lowerRightPartRect = new RectInt(0, 0, partitionWidth, halfPartHeight);
        //BinaryTreeNode<RectInt> lowerRightPartNode = rightPartitionNode.AddChild(lowerRightPartRect);

        RectInt upperRightPartRect = new RectInt();
        BinaryTreeNode<RectInt> upperRightPartNode = null;
        upperRightPartNode = SplitFromLeaf(0, partition2Y, rightPartitionNode, upperRightPartNode, upperRightPartRect);

        //RectInt UpperRightPartRect = new RectInt(0, upperRightPartY, partitionWidth, halfPartHeight);
        //BinaryTreeNode<RectInt> upperRightPartNode = rightPartitionNode.AddChild(UpperRightPartRect);

        RectInt lowerLeftPartWorld = NodeRectWorld(lowerLeftPartNode);
        RectInt upperLeftPartWorld = NodeRectWorld(upperLeftPartNode);
        RectInt lowerRightPartWorld = NodeRectWorld(lowerRightPartNode);
        RectInt upperRightPartWorld = NodeRectWorld(upperRightPartNode);

        print("Lower left : " + lowerLeftPartWorld);
        print("Upper left : " + upperLeftPartWorld);
        print("Lower Right : " + lowerRightPartWorld);
        print("Upper Right : " + upperRightPartWorld);

        //Rooms
        int roomHight = (partitionHeight / 2) - 2;
        int roomWidth = (partitionWidth) - 2;

        RectInt room1 = new RectInt();
        BinaryTreeNode<RectInt> room1Node = null;
        MakeRoom(1, 1, lowerLeftPartNode, room1Node, room1);

        //RectInt room1 = new RectInt(1, 1, roomWidth, roomHight);
        //BinaryTreeNode<RectInt> room1Node = lowerLeftPartNode.AddChild(room1);

        //RectInt room2 = new RectInt(1, 1, roomWidth, roomHight);
        //BinaryTreeNode<RectInt> room2Node = upperLeftPartNode.AddChild(room2);
        
        //RectInt room3 = new RectInt(1, 1, roomWidth, roomHight);
        //BinaryTreeNode<RectInt> room3Node = lowerRightPartNode.AddChild(room3);
        
        //RectInt room4 = new RectInt(1, 1, roomWidth, roomHight);
        //BinaryTreeNode<RectInt> room4Node = upperRightPartNode.AddChild(room4);

        RectInt room1World = NodeRectWorld(room1Node);
        //RectInt room2World = NodeRectWorld(room2Node);
        //RectInt room3World = NodeRectWorld(room3Node);
        //RectInt room4World = NodeRectWorld(room4Node);

        print("Room 1 : " + room1World);
        //print("Room 2 : " + room2World);
        //print("Room 3 : " + room3World);
        //print("Room 4 : " + room4World);

        for (int x = room1World.x; x < room1World.x + room1World.width; x++)
        {
            for (int y = room1World.y; y < room1World.y + room1World.height; y++)
            {
                print(x + ", " + y);
            }
        }

        //Corridors

        string[,] levelArray = new string[levelWidth, levelHeight];

        //partitions
        for (int x = lowerLeftPartWorld.x; x < lowerLeftPartWorld.x + lowerLeftPartWorld.width; x++)
        {
            for (int y = lowerLeftPartWorld.y; y < lowerLeftPartWorld.y + lowerLeftPartWorld.height; y++)
            {
                levelArray[x, y] = "E ";
            }
        }
        for (int x = upperLeftPartWorld.x; x < upperLeftPartWorld.x + upperLeftPartWorld.width; x++)
        {
            for (int y = upperLeftPartWorld.y; y < upperLeftPartWorld.y + upperLeftPartWorld.height; y++)
            {
                levelArray[x, y] = "E ";
            }
        }
        for (int x = lowerRightPartWorld.x; x < lowerRightPartWorld.x + lowerRightPartWorld.width; x++)
        {
            for (int y = lowerRightPartWorld.y; y < lowerRightPartWorld.y + lowerRightPartWorld.height; y++)
            {
                levelArray[x, y] = "E ";
            }
        }
        for (int x = upperRightPartWorld.x; x < upperRightPartWorld.x + upperRightPartWorld.width; x++)
        {
            for (int y = upperRightPartWorld.y; y < upperRightPartWorld.y + upperRightPartWorld.height; y++)
            {
                levelArray[x, y] = "E ";
            }
        }

        //rooms
        for (int x = room1World.x; x < room1World.x + room1World.width; x++)
        {
            for (int y = room1World.y; y < room1World.y + room1World.height; y++)
            {
                levelArray[x, y] = "R ";
            }
        }
        //for (int x = room2World.x; x < room2World.x + room2World.width; x++)
        //{
        //    for (int y = room2World.y; y < room2World.y + room2World.height; y++)
        //    {
        //        levelArray[x, y] = "R ";
        //    }
        //}
        //for (int x = room3World.x; x < room3World.x + room3World.width; x++)
        //{
        //    for (int y = room3World.y; y < room3World.y + room3World.height; y++)
        //    {
        //        levelArray[x, y] = "R ";
        //    }
        //}
        //for (int x = room4World.x; x < room4World.x + room4World.width; x++)
        //{
        //    for (int y = room4World.y; y < room4World.y + room4World.height; y++)
        //    {
        //        levelArray[x, y] = "R ";
        //    }
        //}

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

    private BinaryTreeNode<RectInt> SplitFromRoot(int x, int y, BinaryTree<RectInt> rectTree, BinaryTreeNode<RectInt> nodeName, RectInt partName)
    {
        int width = levelWidth / 2;
        int height = levelHeight;
        partName = new RectInt(x, y, width, height);
        nodeName = rectTree.Root().AddChild(partName);
        return nodeName;
    }

    private BinaryTreeNode<RectInt> SplitFromLeaf(int x, int y, BinaryTreeNode<RectInt> parentNode, BinaryTreeNode<RectInt> nodeName, RectInt partName)
    {
        int width = parentNode.Value().width;
        int height = parentNode.Value().height / 2;
        partName = new RectInt(x, y, width, height);
        nodeName = parentNode.AddChild(partName);
        return nodeName;
    }

    private BinaryTreeNode<RectInt> MakeRoom(int x, int y, BinaryTreeNode<RectInt> parentNode, BinaryTreeNode<RectInt> nodeName, RectInt roomName)
    {
        int width = parentNode.Value().width - 2;
        int height = parentNode.Value().height - 2;
        RectInt room1 = new RectInt(1, 1, width, height);
        nodeName = parentNode.AddChild(room1);
        return nodeName;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
