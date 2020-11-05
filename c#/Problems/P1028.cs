using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/recover-a-tree-from-preorder-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/417171533/
  /// </summary>
  internal class P1028
  {
    public class Solution
    {
      public TreeNode RecoverFromPreorder(string S)
      {
        var markers = new List<int>();
        markers.Add(0);

        for (var i = 1; i < S.Length; i++)
          if (S[i - 1] != '-' && S[i] == '-')
            markers.Add(i);

        var parts = new List<string>();

        for (var i = 0; i < markers.Count; i++)
        {
          var start = markers[i];
          int end;

          if (i == markers.Count - 1)
            end = S.Length;
          else
            end = markers[i + 1];

          var part = S.Substring(start, end - start);
          parts.Add(part);
        }

        var nds = new List<(int value, int depth)>();

        foreach (var part in parts)
        {
          var valueS = part.TrimStart(new char[] { '-' });
          var depth = part.Length - valueS.Length;
          var value = int.Parse(valueS);

          nds.Add((value, depth));
        }

        var root = new TreeNode(nds[0].value);
        var stack = new Stack<(TreeNode node, int depth)>();
        var current = (node: root, depth: 0);

        stack.Push(current);

        for (var i = 1; i < nds.Count; i++)
        {
          var (value, depth) = nds[i];
          var node = (node: new TreeNode(value), depth);

          if (depth == current.depth + 1)
          {
            if (current.node.left == null)
              current.node.left = node.node;
            else
              current.node.right = node.node;
          }
          else
          {
            while (stack.Count > 0)
            {
              var pop = stack.Pop();
              if (depth == pop.depth + 1)
              {
                current = pop;
                break;
              }
            }

            if (current.node.left == null)
              current.node.left = node.node;
            else
              current.node.right = node.node;
          }

          stack.Push(node);
          current = node;
        }

        return root;
      }
    }
  }
}
