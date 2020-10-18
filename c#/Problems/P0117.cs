using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/
  ///    Submission: https://leetcode.com/submissions/detail/252376293/
  /// </summary>
  internal class P0117
  {
    public class Solution
    {
      public Node Connect(Node root)
      {
        if (root == null)
          return null;

        Process(root, new Stack<Node>());

        return root;
      }

      private void Process(Node node, Stack<Node> stack)
      {
        if (stack.Count > 0)
        {
          node.next = stack.Pop();
        }

        if (node.right != null)
          Process(node.right, stack);

        if (node.left != null)
          Process(node.left, stack);

        stack.Push(node);
      }
    }
  }
}
