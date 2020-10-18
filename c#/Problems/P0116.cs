using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
  ///    Submission: https://leetcode.com/submissions/detail/241438634/
  /// </summary>
  internal class P0116
  {
    public class Solution
    {
      public Node Connect(Node root)
      {
        var reff = new Dictionary<int, Node>();

        Traverse(root, reff, 0);

        return root;
      }

      private void Traverse(Node node, Dictionary<int, Node> reff, int index)
      {
        if (node == null)
          return;

        Traverse(node.right, reff, index + 1);

        if (reff.ContainsKey(index))
          node.next = reff[index];

        reff[index] = node;

        Traverse(node.left, reff, index + 1);
      }
    }
  }
}
