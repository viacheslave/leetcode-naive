using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/delete-nodes-and-return-forest/
  ///    Submission: https://leetcode.com/submissions/detail/241439940/
  /// </summary>
  internal class P1110
  {
    public class Solution
    {
      public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
      {
        if (root == null)
          return new List<TreeNode>();

        var set = new HashSet<int>(to_delete);
        var ans = new List<TreeNode>() { root };

        Traverse(root, null, set, ans, 0);

        return ans;
      }

      private void Traverse(TreeNode node, TreeNode parent, HashSet<int> set, List<TreeNode> ans, int shift)
      {
        if (node == null)
          return;

        Traverse(node.left, node, set, ans, 0);
        Traverse(node.right, node, set, ans, 1);

        if (set.Contains(node.val))
        {
          if (node.left != null)
            ans.Add(node.left);

          if (node.right != null)
            ans.Add(node.right);

          if (parent != null)
          {
            if (shift == 0)
              parent.left = null;
            if (shift == 1)
              parent.right = null;
          }
          else
          {
            ans.Remove(node);
          }
        }
      }
    }
  }
}
