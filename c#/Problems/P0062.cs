using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/unique-paths/
  ///    Submission: https://leetcode.com/submissions/detail/237607003/
  /// </summary>
  internal class P0062
  {
    public class Solution
    {
      public int UniquePaths(int m, int n)
      {
        var map = new Dictionary<(int, int), int>();
        return Count(map, 0, 0, m, n);
      }

      private int Count(Dictionary<(int, int), int> map, int mi, int ni, int m, int n)
      {
        if (mi == m || ni == n)
          return 0;

        if (mi == m - 1 && ni == n - 1)
          return 1;

        map.TryGetValue((mi + 1, ni), out var s1);
        if (s1 == 0)
        {
          s1 = Count(map, mi + 1, ni, m, n);
          map[(mi + 1, ni)] = s1;
        }

        map.TryGetValue((mi, ni + 1), out var s2);
        if (s2 == 0)
        {
          s2 = Count(map, mi, ni + 1, m, n);
          map[(mi, ni + 1)] = s2;
        }

        return s1 + s2;
      }
    }
  }
}
