using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flip-binary-tree-to-match-preorder-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/419577679/
  /// </summary>
  internal class P0971
  {
    public class Solution
    {
      private int _index;

      public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
      {
        try
        {
          var ans = new List<int>();
          Traverse(root, voyage, ans);

          return ans;
        }
        catch
        {
          return new[] { -1 }.ToList();
        }
      }

      private void Traverse(TreeNode node, int[] voyage, List<int> ans)
      {
        if (node == null)
          return;

        if (node.val != voyage[_index])
          throw new Exception();

        _index++;

        if (node.left == null && node.right == null)
          return;

        if (node.left != null && node.left.val == voyage[_index])
        {
          Traverse(node.left, voyage, ans);
          Traverse(node.right, voyage, ans);
          return;
        }

        if (node.left != null && node.left.val != voyage[_index])
        {
          // swap
          if (node.right != null && node.right.val == voyage[_index])
          {
            var tmp = node.left;
            node.left = node.right;
            node.right = tmp;

            ans.Add(node.val);

            Traverse(node.left, voyage, ans);
            Traverse(node.right, voyage, ans);
            return;
          }

          throw new Exception();
        }

        if (node.right != null && node.right.val == voyage[_index])
        {
          Traverse(node.left, voyage, ans);
          Traverse(node.right, voyage, ans);
          return;
        }

        throw new Exception();
      }
    }
  }
}
