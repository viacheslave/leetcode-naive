using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/validate-binary-tree-nodes/
	///		Submission: https://leetcode.com/submissions/detail/308034430/
	/// </summary>
	internal class P1361
	{
    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
    {
      var nodes = new Node[n];

      try
      {
        for (int i = 0; i < n; i++)
        {
          Traverse(nodes, i, leftChild, rightChild);
        }

        var root = nodes.Single(r => r.parent == null);
        return true;
      }
      catch
      {
        return false;
      }
    }

    private Node Traverse(Node[] nodes, int i, int[] leftChild, int[] rightChild)
    {
      if (nodes[i] != null)
        return nodes[i];

      nodes[i] = new Node();

      if (leftChild[i] != -1)
      {
        var left = Traverse(nodes, leftChild[i], leftChild, rightChild);
        if (left.parent != null)
          throw new ApplicationException();

        left.parent = nodes[i];
        nodes[i].left = left;
      }

      if (rightChild[i] != -1)
      {
        var right = Traverse(nodes, rightChild[i], leftChild, rightChild);
        if (right.parent != null)
          throw new ApplicationException();

        right.parent = nodes[i];
        nodes[i].right = right;
      }

      return nodes[i];
    }

    public class Node
    {
      public Node left;
      public Node right;
      public Node parent;
    }
  }
}
