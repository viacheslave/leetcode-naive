using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-common-prefix/
  ///    Submission: https://leetcode.com/submissions/detail/230435803/
  /// </summary>
  internal class P0014
  {
    public class Solution
    {
      public string LongestCommonPrefix(string[] strs)
      {
        if (strs.Length == 0)
          return "";

        var maxIndex = 0;

        while (true)
        {
          var hs = new HashSet<char>();

          var empty = false;

          foreach (var str in strs)
          {
            if (maxIndex >= str.Length)
            {
              empty = true;
              break;
            }

            hs.Add(str[maxIndex]);
          }

          if (empty)
            break;

          if (hs.Count == 0)
            break;

          if (hs.Count > 1)
            break;

          maxIndex++;
        }

        if (maxIndex == 0)
          return "";

        return strs[0].Substring(0, maxIndex);
      }
    }
  }
}
