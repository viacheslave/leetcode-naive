using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-bottom-left-tree-value/
  ///    Submission: https://leetcode.com/submissions/detail/239042404/
  /// </summary>
  internal class P0513
  {
    public class Solution
    {
      public int FindBottomLeftValue(TreeNode root)
      {
        var d = new Dictionary<int, int>();

        d[0] = root.val;

        Traverse(d, root, 1);

        return d.OrderByDescending(_ => _.Key).First().Value;
      }

      private void Traverse(Dictionary<int, int> d, TreeNode node, int depth)
      {
        if (node == null)
          return;

        if (!d.ContainsKey(depth))
          d[depth] = node.val;

        Traverse(d, node.left, depth + 1);
        Traverse(d, node.right, depth + 1);
      }
    }
  }
}
