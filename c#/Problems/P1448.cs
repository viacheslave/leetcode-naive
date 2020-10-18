using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-good-nodes-in-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/344563241/
  /// </summary>
  internal class P1448
  {
    public class Solution
    {
      public int GoodNodes(TreeNode root)
      {
        var list = new List<int>();
        var max = int.MinValue;

        return Traverse(root, list, max);
      }

      private int Traverse(TreeNode node, List<int> list, int max)
      {
        if (node == null)
          return 0;

        //list.Add(node.val);

        var val =
          Traverse(node.left, list, Math.Max(max, node.val)) +
          Traverse(node.right, list, Math.Max(max, node.val));

        if (node.val >= max)
          val++;

        //list.Remove(list.Count - 1);
        return val;
      }
    }
  }
}
