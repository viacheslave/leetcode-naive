using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/increasing-order-search-tree/
  ///    Submission: https://leetcode.com/submissions/detail/238007896/
  /// </summary>
  internal class P0897
  {
    public class Solution
    {
      public TreeNode IncreasingBST(TreeNode root)
      {
        List<int> list = new List<int>();

        Traverse(root, list);

        var newRoot = new TreeNode(list[0]);
        var current = newRoot;

        for (var i = 1; i < list.Count; i++)
        {
          var newNode = new TreeNode(list[i]);
          current.right = newNode;
          current = current.right;
        }

        return newRoot;
      }

      private void Traverse(TreeNode node, List<int> list)
      {
        if (node == null)
          return;

        if (node.left != null)
          Traverse(node.left, list);

        list.Add(node.val);

        if (node.right != null)
          Traverse(node.right, list);
      }
    }
  }
}
