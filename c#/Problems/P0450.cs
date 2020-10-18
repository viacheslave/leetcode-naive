using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/delete-node-in-a-bst/
  ///    Submission: https://leetcode.com/submissions/detail/243001256/
  /// </summary>
  internal class P0450
  {
    public class Solution
    {
      public TreeNode DeleteNode(TreeNode root, int key)
      {
        if (root == null)
          return null;

        if (key < root.val)
          root.left = DeleteNode(root.left, key);

        if (key > root.val)
          root.right = DeleteNode(root.right, key);

        if (key == root.val)
        {
          if (root.left == null)
            return root.right;

          if (root.right == null)
            return root.left;

          TreeNode current = root.right;
          TreeNode previous = null;

          while (current.left != null)
          {
            previous = current;
            current = current.left;
          }

          if (previous == null)
          {
            current.left = root.left;
            return current;
          }

          previous.left = current.right;
          current.right = root.right;
          current.left = root.left;

          return current;
        }

        return root;
      }
    }
  }
}
