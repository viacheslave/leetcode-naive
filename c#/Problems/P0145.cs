using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-tree-postorder-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/252377564/
  /// </summary>
  internal class P0145
  {
    public class Solution
    {
      public IList<int> PostorderTraversal(TreeNode root)
      {
        return Process(root);
      }

      private List<int> Process(TreeNode node)
      {
        if (node == null)
          return new List<int>();

        var list = new List<int>();

        list.AddRange(Process(node.left));
        list.AddRange(Process(node.right));
        list.Add(node.val);

        return list;
      }
    }
  }
}
