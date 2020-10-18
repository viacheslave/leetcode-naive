using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/balanced-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/227823951/
  /// </summary>
  internal class P0110
  {
    public class Solution
    {
      public bool IsBalanced(TreeNode root)
      {
        if (root == null)
          return true;

        try
        {
          GetDepth(root);
        }
        catch (Exception ex)
        {
          return false;
        }

        return true;
      }

      public int GetDepth(TreeNode node)
      {
        int left = 0, right = 0;

        if (node.left != null)
          left = GetDepth(node.left);

        if (node.right != null)
          right = GetDepth(node.right);

        if (Math.Abs(left - right) > 1)
          throw new Exception();

        return Math.Max(left, right) + 1;

      }
    }
  }
}
