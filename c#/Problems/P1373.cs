using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-sum-bst-in-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/417077859/
  /// </summary>
  internal class P1373
  {
    public class Solution
    {
      public int MaxSumBST(TreeNode root)
      {
        var dp = new List<(bool bst, int sum, int min, int max)>();
        Recursive(root, dp);

        var bst = dp.Where(d => d.bst).ToList();
        if (bst.Count == 0)
          return 0;

        var max = bst.Max(_ => _.sum);
        if (max < 0)
          return 0;

        return max;
      }

      private (bool bst, int sum, int min, int max) Recursive(TreeNode node, List<(bool bst, int sum, int min, int max)> dp)
      {
        if (node == null)
          return default;

        var left = Recursive(node.left, dp);
        var right = Recursive(node.right, dp);

        bool bst;
        int sum;
        int min;
        int max;

        if (node.left == null && node.right == null)
        {
          bst = true;
          sum = node.val;
          min = node.val;
          max = node.val;
        }
        else if (node.left != null && node.right == null)
        {
          bst = left.max < node.val && left.bst;
          sum = left.sum + node.val;
          min = left.min;
          max = node.val;
        }
        else if (node.left == null && node.right != null)
        {
          bst = right.min > node.val && right.bst;
          sum = right.sum + node.val;
          min = node.val;
          max = right.max;
        }
        else
        {
          bst = left.max < node.val && right.min > node.val && left.bst && right.bst;
          sum = left.sum + right.sum + node.val;
          min = left.min;
          max = right.max;
        }

        dp.Add((bst, sum, min, max));
        return (bst, sum, min, max);
      }
    }
  }
}
