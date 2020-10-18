using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-univalue-path/
  ///    Submission: https://leetcode.com/submissions/detail/394247297/
  /// </summary>
  internal class P0687
  {
    public class Solution
    {
      public int LongestUnivaluePath(TreeNode root)
      {
        return GetMax(root);
      }

      private int GetMax(TreeNode root)
      {
        if (root == null)
          return 0;

        var value = 0;

        var left = Traverse(root.left, root.val, 0);
        if (left > 0)
          value += left;

        var right = Traverse(root.right, root.val, 0);
        if (right > 0)
          value += right;

        var valueLeft = GetMax(root.left);
        var valueRight = GetMax(root.right);

        return Math.Max(value, Math.Max(valueRight, valueLeft));
      }

      private int Traverse(TreeNode node, int val, int current)
      {
        if (node == null)
          return current;

        if (node.val != val)
          return current;

        return Math.Max(
            Traverse(node.left, val, current + 1),
            Traverse(node.right, val, current + 1));
      }
    }
  }
}
