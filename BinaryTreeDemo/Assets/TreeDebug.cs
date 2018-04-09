using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class TreeDebug : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        BinaryTree<int> sampleTree = new BinaryTree<int>(42);

        BinaryTreeNode<int> left = sampleTree.Root().AddChild(5);
        BinaryTreeNode<int> right = sampleTree.Root().AddChild(17);

        left.AddChild(-6);
        left.AddChild(12);

        right.AddChild(128);
        right.AddChild(1024);

        BinaryTreeNode<int> treeRoot = sampleTree.Root();
        List<BinaryTreeNode<int>> leaves = new List<BinaryTreeNode<int>>();

        CollectLeaves(treeRoot, leaves);

        foreach (BinaryTreeNode<int> leaf in leaves)
        {
            print("Leaf found with value " + leaf.Value() + " and parent value " + leaf.parent.Value());

            int currentLeafSum = CountFromNodeToRoot(leaf);
            print("Sum of root is " + currentLeafSum);
        }
    }

    private void CollectLeaves(BinaryTreeNode<int> currentNode, List<BinaryTreeNode<int>> leaves)
    {
        if (currentNode == null) return;

        //Practical exit case: currentNode is a leaf node.
        if (currentNode.IsLeaf())
        {
            //Is this a leaf or not a leaf?
            leaves.Add(currentNode);
        }
        else
        {
            CollectLeaves(currentNode.leftChild, leaves);
            CollectLeaves(currentNode.rightChild, leaves);
        }
    }

    private int CountFromNodeToRoot(BinaryTreeNode<int> startNode)
    {
        BinaryTreeNode<int> current = startNode;
        int totalValue = 0;

        //while loops are dangerous because they can create inescapable loops.
        while (current != null)
        {
            totalValue += current.Value();
            current = current.parent;
        }

        return totalValue;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
