using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-tree-maximum-path-sum/
  ///    Submission: https://leetcode.com/submissions/detail/414286549/
  /// </summary>
  internal class P0124
  {
    public class Solution
    {
      public int MaxPathSum(TreeNode root)
      {
        var dp = new Dictionary<TreeNode, (int left, int right)>();

        DFS(root, dp);

        return dp.Max(s => s.Value.left + s.Value.right - s.Key.val);
      }

      private void DFS(TreeNode node, Dictionary<TreeNode, (int left, int right)> dp)
      {
        if (node == null)
          return;

        var value = node.val;

        DFS(node.left, dp);
        DFS(node.right, dp);

        var left = Math.Max(DP(dp, node.left).left, DP(dp, node.left).right) + node.val;

        var right = Math.Max(DP(dp, node.right).left, DP(dp, node.right).right) + node.val;

        left = Math.Max(left, node.val);
        right = Math.Max(right, node.val);

        dp[node] = (left, right);
      }

      private (int left, int right) DP(
        Dictionary<TreeNode, (int left, int right)> dp, TreeNode node)
      {
        return node == null ? default : dp[node];
      }
    }
  }
}
