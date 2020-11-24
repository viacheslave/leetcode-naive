using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-tree-cameras/
  ///    Submission: https://leetcode.com/submissions/detail/423634357/
  /// </summary>
  internal class P0968
  {
    public class Solution
    {
      enum Kind
      {
        Camera,
        Covered,
        Uncovered
      }

      public int MinCameraCover(TreeNode root)
      {
        var dp = new Dictionary<TreeNode, Dictionary<Kind, int>>();

        Traverse(dp, root, root);

        var ans = dp[root].Where(_ => _.Key != Kind.Uncovered).Min(c => c.Value);
        return ans;
      }

      private Dictionary<Kind, int> GetOptions(Dictionary<TreeNode, Dictionary<Kind, int>> dp, TreeNode node)
      {
        if (node == null)
          return new Dictionary<Kind, int>();
        return dp[node];
      }

      private void Traverse(Dictionary<TreeNode, Dictionary<Kind, int>> dp, TreeNode node, TreeNode root)
      {
        if (node == null)
          return;

        dp[node] = new Dictionary<Kind, int>();

        Traverse(dp, node.left, root);
        Traverse(dp, node.right, root);

        var left = GetOptions(dp, node.left);
        var right = GetOptions(dp, node.right);

        // 
        dp[node][Kind.Camera] = int.MaxValue;
        dp[node][Kind.Covered] = int.MaxValue;
        dp[node][Kind.Uncovered] = int.MaxValue;

        if (left.Count == 0 && right.Count == 0)
        {
          dp[node][Kind.Camera] = 1;
          dp[node][Kind.Uncovered] = 0;
        }

        if (left.Count > 0 && right.Count == 0)
        {
          foreach (var item in left)
          {
            dp[node][Kind.Camera] = Math.Min(dp[node][Kind.Camera], item.Value + 1);

            if (item.Key == Kind.Camera)
              dp[node][Kind.Covered] = Math.Min(dp[node][Kind.Covered], item.Value);
            else if (item.Key == Kind.Covered)
              dp[node][Kind.Uncovered] = Math.Min(dp[node][Kind.Uncovered], item.Value);
          }
        }

        if (left.Count == 0 && right.Count > 0)
        {
          foreach (var item in right)
          {
            dp[node][Kind.Camera] = Math.Min(dp[node][Kind.Camera], item.Value + 1);

            if (item.Key == Kind.Camera)
              dp[node][Kind.Covered] = Math.Min(dp[node][Kind.Covered], item.Value);
            else if (item.Key == Kind.Covered)
              dp[node][Kind.Uncovered] = Math.Min(dp[node][Kind.Uncovered], item.Value);
          }
        }

        if (left.Count > 0 && right.Count > 0)
        {
          foreach (var l in left)
          {
            foreach (var r in right)
            {
              dp[node][Kind.Camera] = Math.Min(dp[node][Kind.Camera], l.Value + r.Value + 1);

              if (l.Key == Kind.Camera && r.Key == Kind.Camera)
                dp[node][Kind.Covered] = Math.Min(dp[node][Kind.Covered], l.Value + r.Value);

              if (l.Key == Kind.Camera && r.Key == Kind.Covered ||
                  l.Key == Kind.Covered && r.Key == Kind.Camera)
                dp[node][Kind.Covered] = Math.Min(dp[node][Kind.Covered], l.Value + r.Value);

              if (l.Key == Kind.Covered && r.Key == Kind.Covered)
                dp[node][Kind.Uncovered] = Math.Min(dp[node][Kind.Uncovered], l.Value + r.Value);
            }
          }
        }

        var remove = dp[node].Where(_ => _.Value == int.MaxValue).Select(x => x.Key).ToList();
        foreach (var key in remove)
          dp[node].Remove(key);
      }
    }
  }
}
