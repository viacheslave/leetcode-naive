using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/range-sum-of-bst/
  ///    Submission: https://leetcode.com/submissions/detail/234787193/
  /// </summary>
  internal class P0938
  {
    public class Solution
    {
      public int RangeSumBST(TreeNode root, int L, int R)
      {
        return Traverse(root, L, R);
      }

      int Traverse(TreeNode node, int L, int R)
      {
        if (node == null)
          return 0;

        var sum = 0;
        if (L <= node.val && node.val <= R)
        {
          sum += node.val;
        }

        sum += Traverse(node.left, L, R);
        sum += Traverse(node.right, L, R);
        return sum;
      }
    }
  }
}
