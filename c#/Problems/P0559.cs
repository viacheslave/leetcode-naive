using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-depth-of-n-ary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/228679750/
  /// </summary>
  internal class P0559
  {
    public class Solution
    {
      public int MaxDepth(NodeChildren root)
      {
        return GetMaxDepth(root);
      }

      private int GetMaxDepth(NodeChildren node)
      {
        if (node == null)
          return 0;

        int depth = 0;
        if (node.children != null)
        {
          foreach (var child in node.children)
          {
            var childDepth = GetMaxDepth(child);
            if (childDepth > depth)
              depth = childDepth;
          }
        }

        return depth + 1;
      }
    }
  }
}
