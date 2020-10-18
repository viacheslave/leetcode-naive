using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/linked-list-in-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/308311313/
  /// </summary>
  internal class P1367
  {
    /**
    * Definition for singly-linked list.
    * public class ListNode {
    *     public int val;
    *     public ListNode next;
    *     public ListNode(int x) { val = x;   }
    *   }
    */
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x;   }
     *   }
     */
    public class Solution
    {
      public bool IsSubPath(ListNode head, TreeNode root)
      {
        var map = new Dictionary<int, List<TreeNode>>();
        Traverse(root, map);

        map.TryGetValue(head.val, out var nodes);

        foreach (var node in nodes)
        {
          var result = Check(node, head);
          if (result)
            return true;
          }

        return false;
        }

      private bool Check(TreeNode node, ListNode ll)
      {
        if (ll == null)
          return true;

        if (node == null)
          return false;

        if (node.val == ll.val)
        {
          return Check(node.left, ll.next) || Check(node.right, ll.next);
          }

        return false;
        }

      private void Traverse(TreeNode node, Dictionary<int, List<TreeNode>> map)
      {
        if (node == null) return;

        if (!map.ContainsKey(node.val))
          map[node.val] = new List<TreeNode>();

        map[node.val].Add(node);
        Traverse(node.left, map);
        Traverse(node.right, map);
      }
    }
  }
}
