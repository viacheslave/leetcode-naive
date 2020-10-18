using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/kth-smallest-element-in-a-bst/
  ///    Submission: https://leetcode.com/submissions/detail/229999536/
  /// </summary>
  internal class P0230
  {
    public class Solution
    {
      List<int> mins = new List<int>();

      public int KthSmallest(TreeNode root, int k)
      {
        Traverse(root);

        var ar = mins.Distinct().ToArray();
        Array.Sort(ar);

        if (ar.Length < k)
          return -1;

        return ar[k - 1];
      }

      void Traverse(TreeNode node)
      {
        mins.Add(node.val);

        if (node.left != null)
          Traverse(node.left);

        if (node.right != null)
          Traverse(node.right);
      }
    }
  }
}
