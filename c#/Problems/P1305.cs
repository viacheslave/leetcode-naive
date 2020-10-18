using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/all-elements-in-two-binary-search-trees/
  ///    Submission: https://leetcode.com/submissions/detail/289438262/
  /// </summary>
  internal class P1305
  {
    public class Solution
    {
      public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
      {
        var list1 = new List<int>();
        var list2 = new List<int>();

        Traverse(list1, root1);
        Traverse(list2, root2);

        list1.AddRange(list2);
        list1.Sort();
        return list1;
      }

      private void Traverse(List<int> list1, TreeNode root1)
      {
        if (root1 == null)
          return;

        list1.Add(root1.val);
        Traverse(list1, root1.left);
        Traverse(list1, root1.right);
      }
    }
  }
}
