using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/n-ary-tree-preorder-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/228186453/
  /// </summary>
  internal class P0589
  {
    public class Solution
    {
      public IList<int> Preorder(NodeChildren root)
      {

        var res = new List<int>();

        CheckNode(res, root, 0);

        return res;
      }

      private void CheckNode(List<int> res, NodeChildren node, int depth)
      {
        if (node == null)
          return;

        res.Add(node.val);

        depth++;

        if (node.children != null)
          foreach (var n in node.children)
            CheckNode(res, n, depth);
      }
    }
  }
}
