using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
  ///    Submission: https://leetcode.com/submissions/detail/344558223/
  /// </summary>
  internal class P1457
  {
    public class Solution
    {
      public int PseudoPalindromicPaths(TreeNode root)
      {
        var list = new List<int>();
        return Traverse(root, list);
      }

      private int Traverse(TreeNode node, List<int> list)
      {
        if (node == null)
          return 0;

        list.Add(node.val);

        var val = 0;

        if (node.left == null && node.right == null)
          val = IsPalindrome(list) ? 1 : 0;
        else
          val = Traverse(node.left, list) + Traverse(node.right, list);

        list.RemoveAt(list.Count - 1);

        return val;
      }

      private bool IsPalindrome(List<int> list)
      {
        var odds = list.GroupBy(d => d).ToDictionary(x => x.Key, x => x.Count())
          .Where(x => x.Value % 2 == 1)
          .Count();

        return odds <= 1;
      }
    }
  }
}
