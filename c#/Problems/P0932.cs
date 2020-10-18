using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/beautiful-array/
  ///    Submission: https://leetcode.com/submissions/detail/401055723/
  /// </summary>
  internal class P0932
  {
    public class Solution
    {
      public int[] BeautifulArray(int N)
      {
        if (N == 1)
          return new int[] { 1 };

        if (N == 2)
          return new int[] { 1, 2 };

        var ans = new List<int>() { 1, 2 };
        var indices = new List<int>() { 0, 1 };

        while (ans.Count != N)
        {
          var other = new int[indices.Count];
          var running = 0;

          for (var i = 0; i < indices.Count; i++)
          {
            other[indices[i]] = ans.Count + running + 1;
            running++;

            if (ans.Count + running == N)
              break;
          }

          var newArr = new List<int>();

          for (var i = 0; i < indices.Count; i++)
          {
            newArr.Add(ans[i]);

            if (other[i] != 0)
              newArr.Add(other[i]);
          }

          ans = newArr;
          if (ans.Count != N)
          {
            indices = indices.Select(i => i * 2).Concat(
                    indices.Select(i => i * 2 + 1))
                .ToList();
          }
        }

        return ans.ToArray();
      }
    }
  }
}
