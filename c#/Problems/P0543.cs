using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/diameter-of-binary-tree
  ///    Submission: https://leetcode.com/submissions/detail/238323462/
  /// </summary>
  internal class P0543
  {
    public class Solution
    {
      int _maxDiameter;

      public int DiameterOfBinaryTree(TreeNode root)
      {
        Get(root);
        return _maxDiameter;
      }

      private int Get(TreeNode node)
      {
        if (node == null)
          return 0;

        var maxLeft = Get(node.left);
        if (node.left != null) maxLeft++;

        var maxRight = Get(node.right);
        if (node.right != null) maxRight++;

        if (maxLeft + maxRight == 0)
          return 0;

        var diameter = maxLeft + maxRight;
        _maxDiameter = Math.Max(_maxDiameter, diameter);

        return Math.Max(maxLeft, maxRight);
      }
    }
  }
}
