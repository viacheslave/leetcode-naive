using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
  ///    Submission: https://leetcode.com/submissions/detail/237769809/
  /// </summary>
  internal class P0114
  {
    public class Solution
    {
      TreeNode anc;

      public void Flatten(TreeNode root)
      {
        if (root == null)
          return;

        Fl(root);

        var current = root;

        //current.right = current.left;

        while (current.left != null)
        {
          current.right = current.left;
          current.left = null;

          current = current.right;
        }
      }

      private void Fl(TreeNode node)
      {
        if (node == null)
          return;

        anc = node;

        if (node.left == null && node.right == null)
          return;

        Fl(node.left);

        anc.left = node.right;

        Fl(node.right);
      }
    }
  }
}
