using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/cousins-in-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/230898908/
  /// </summary>
  internal class P0993
  {
    public class Solution
    {
      public bool IsCousins(TreeNode root, int x, int y)
      {
        if (root == null) return false;

        var resX = Find(root, null, x, 0);
        var resY = Find(root, null, y, 0);

        return resX.depth == resY.depth &&
            resX.parent != resY.parent;
      }

      Result Find(TreeNode node, TreeNode parent, int val, int depth)
      {
        if (node == null)
          return null;

        if (node.val == val)
          return new Result { depth = depth, parent = parent };

        return Find(node.left, node, val, depth + 1)
            ?? Find(node.right, node, val, depth + 1);
      }

      public class Result
      {
        public int depth;
        public TreeNode parent;
      }
    }
  }
}
