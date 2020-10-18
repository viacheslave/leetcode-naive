using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sum-of-left-leaves/
  ///    Submission: https://leetcode.com/submissions/detail/227825455/
  /// </summary>
  internal class P0404
  {
    public class Solution
    {
      public int SumOfLeftLeaves(TreeNode root)
      {
        return GetSum(0, root);
      }

      private int GetSum(int sum, TreeNode node)
      {
        if (node == null)
          return 0;

        var s = sum;
        if (node.left != null && node.left.left == null && node.left.right == null)
          s += node.left.val;

        s += GetSum(sum, node.left) + GetSum(sum, node.right);

        return s;
      }
    }
  }
}
