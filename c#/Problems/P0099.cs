using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/recover-binary-search-tree/
  ///    Submission: https://leetcode.com/submissions/detail/415199361/
  /// </summary>
  internal class P0099
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
      public void RecoverTree(TreeNode root)
      {
        var nodes = new Dictionary<int, TreeNode>();
        DFS(nodes, root);

        var currentInOrder = nodes.Select(x => x.Key).ToList();
        var correctInOrder = currentInOrder.OrderBy(x => x).ToList();

        for (var i = 0; i < nodes.Count; i++)
        {
          if (currentInOrder[i] != correctInOrder[i])
          {
            var val1 = currentInOrder[i];
            var val2 = correctInOrder[i];

            nodes[val1].val = val2;
            nodes[val2].val = val1;
            break;
          }
        }
      }

      private void DFS(Dictionary<int, TreeNode> nodes, TreeNode node)
      {
        if (node == null)
          return;

        DFS(nodes, node.left);
        nodes.Add(node.val, node);
        DFS(nodes, node.right);
      }
    }
  }
}
