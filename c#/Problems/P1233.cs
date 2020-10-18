using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-sub-folders-from-the-filesystem/
  ///    Submission: https://leetcode.com/submissions/detail/289255940/
  /// </summary>
  internal class P1233
  {
    public class Solution
    {
      public IList<string> RemoveSubfolders(string[] folder)
      {
        Array.Sort(folder);

        var ans = new List<string>();

        foreach (var item in folder)
        {
          if (ans.Count == 0)
          {
            ans.Add(item);
            continue;
          }

          var last = ans[ans.Count - 1];
          if (item.IndexOf(last) == 0 && item[last.Length] == '/')
            continue;

          ans.Add(item);
        }

        return ans;
      }
    }
  }
}
