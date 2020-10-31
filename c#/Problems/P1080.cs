using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/insufficient-nodes-in-root-to-leaf-paths/
  ///    Submission: https://leetcode.com/submissions/detail/415272115/
  /// </summary>
  internal class P1080
  {
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
      public TreeNode SufficientSubset(TreeNode root, int limit)
      {
        var nodes = new Dictionary<TreeNode, (TreeNode parent, int path, int max)>();

        DFS(nodes, root, null, 0);

        var insufficient = nodes
          .Where(n => n.Value.path < limit)
          .ToDictionary(x => x.Key, x => x.Value);

        if (insufficient.ContainsKey(root))
          return null;

        DFSRemove(insufficient, root);

        return root;
      }

      private void DFS(Dictionary<TreeNode, (TreeNode parent, int path, int max)> nodes, TreeNode node, TreeNode parent, int sum)
      {
        if (node == null)
          return;

        var children = new List<int>();

        if (node.left != null)
        {
          DFS(nodes, node.left, node, sum + node.val);
          children.Add(nodes[node.left].max + node.val);
        }

        if (node.right != null)
        {
          DFS(nodes, node.right, node, sum + node.val);
          children.Add(nodes[node.right].max + node.val);
        }

        var max = node.val;
        if (children.Count > 0)
          max = children.Max();

        nodes[node] = (parent, sum + max, max);
      }

      private void DFSRemove(Dictionary<TreeNode, (TreeNode parent, int path, int max)> insufficient, TreeNode node)
      {
        if (node == null)
          return;

        if (node.left != null && insufficient.ContainsKey(node.left))
          node.left = null;

        if (node.right != null && insufficient.ContainsKey(node.right))
          node.right = null;

        DFSRemove(insufficient, node.left);
        DFSRemove(insufficient, node.right);
      }
    }
  }
}
