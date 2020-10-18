using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-tree-tilt/
  ///    Submission: https://leetcode.com/submissions/detail/228687103/
  /// </summary>
  internal class P0563
  {
    public class Solution
    {
      public int full = 0;

      public int FindTilt(TreeNode root)
      {
        int sum = GetSum(root);
        return full;
      }

      private int GetSum(TreeNode node)
      {
        if (node == null)
          return 0;

        var left = GetSum(node.left);
        var right = GetSum(node.right);

        full += Math.Abs(left - right);

        return left + right + node.val;
      }
    }
  }
}
