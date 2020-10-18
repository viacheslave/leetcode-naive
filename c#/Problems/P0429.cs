using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/n-ary-tree-level-order-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/228185917/
  /// </summary>
  internal class P0429
  {
    public class Solution
    {
      public IList<IList<int>> LevelOrder(NodeChildren root)
      {
        var res = new List<IList<int>>();

        CheckNode(res, root, 0);

        return res;
      }

      private void CheckNode(List<IList<int>> res, NodeChildren node, int depth)
      {
        if (node == null)
          return;

        if (res.Count == depth)
          res.Add(new List<int>());

        res[depth].Add(node.val);

        depth++;

        if (node.children != null)
          foreach (var n in node.children)
            CheckNode(res, n, depth);
      }
    }
  }
}
