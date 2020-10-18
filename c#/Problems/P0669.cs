using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/trim-a-binary-search-tree/
  ///    Submission: https://leetcode.com/submissions/detail/238001684/
  /// </summary>
  internal class P0669
  {
    public class Solution
    {
      TreeNode _root;

      public TreeNode TrimBST(TreeNode root, int L, int R)
      {
        if (root == null)
          return null;

        _root = root;
        Trim(root, L, R);

        return _root;
      }

      void Trim(TreeNode node, int L, int R)
      {
        if (node == null)
          return;

        if (node.val < L)
        {
          _root = node.right;
          Trim(node.right, L, R);
          return;
        }

        if (node.val > R)
        {
          _root = node.left;
          Trim(node.left, L, R);
          return;
        }

        if (node.left != null)
        {
          if (node.left.val < L)
          {
            node.left = node.left.right;
            Trim(node, L, R);
          }
          else
            Trim(node.left, L, R);
        }

        if (node.right != null)
        {
          if (node.right.val > R)
          {
            node.right = node.right.left;
            Trim(node, L, R);
          }
          else
            Trim(node.right, L, R);
        }
      }
    }
  }
}
