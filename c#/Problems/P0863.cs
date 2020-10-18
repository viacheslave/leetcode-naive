using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/242488961/
  /// </summary>
  internal class P0863
  {
    public class Solution
    {
      public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
      {
        var map = new Dictionary<TreeNode, List<TreeNode>>();

        Traverse(root, null, map);

        var res = new List<int>();
        var visited = new HashSet<TreeNode>();

        var queue = new Queue<(TreeNode node, int dist)>();
        queue.Enqueue((target, 0));

        while (queue.Count > 0)
        {
          var (node, dist) = queue.Dequeue();
          if (visited.Contains(node))
            continue;

          visited.Add(node);

          if (dist == K)
            res.Add(node.val);

          foreach (var child in map[node])
            queue.Enqueue((child, dist + 1));
        }

        return res;
      }

      private void Traverse(TreeNode node, TreeNode parent, Dictionary<TreeNode, List<TreeNode>> map)
      {
        if (node == null)
          return;

        map[node] = new List<TreeNode>();
        if (parent != null)
          map[node].Add(parent);

        if (node.left != null)
          map[node].Add(node.left);

        if (node.right != null)
          map[node].Add(node.right);

        Traverse(node.left, node, map);
        Traverse(node.right, node, map);
      }
    }
  }
}
