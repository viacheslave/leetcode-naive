using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/deepest-leaves-sum/
  ///    Submission: https://leetcode.com/submissions/detail/289480677/
  /// </summary>
  internal class P1302
  {
    public class Solution
    {
      public int DeepestLeavesSum(TreeNode root)
      {
        var sl = new SortedDictionary<int, List<int>>();
        Traverse(root, 0, sl);

        var key = sl.Keys.Last();
        return sl[key].Sum();
      }

      private void Traverse(TreeNode node, int level, SortedDictionary<int, List<int>> sl)
      {
        if (node == null) return;
        if (!sl.ContainsKey(level)) sl[level] = new List<int>();
        sl[level].Add(node.val);
        Traverse(node.left, level + 1, sl);
        Traverse(node.right, level + 1, sl);
      }
    }
  }
}
