using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/symmetric-tree/
  ///    Submission: https://leetcode.com/submissions/detail/229134029/
  /// </summary>
  internal class P0101
  {
    public class Solution
    {
      public bool IsSymmetric(TreeNode root)
      {
        var elem1 = new List<int?>();
        var elem2 = new List<int?>();

        Left(root, elem1, true);
        Left(root, elem2, false);

        for (var i = 0; i < Math.Max(elem1.Count, elem2.Count); i++)
        {
          if (elem1[i] != elem2[i])
            return false;
        }

        return true;
      }

      private void Left(TreeNode node, List<int?> s, bool left)
      {
        if (node == null)
        {
          s.Add(null);
          return;
        }

        Left(left ? node.left : node.right, s, left);
        s.Add(node.val);
        Left(left ? node.right : node.left, s, left);
      }
    }
  }
}
