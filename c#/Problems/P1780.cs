using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-if-number-is-a-sum-of-powers-of-three/
  ///    Submission: https://leetcode.com/submissions/detail/467687455/
  /// </summary>
  internal class P1780
  {
    public class Solution
    {
      public bool CheckPowersOfThree(int n)
      {
        var visited = new HashSet<int>();
        var powers = Enumerable.Range(0, 17).Select(x => (int)Math.Pow(3, x)).ToList();
        powers.Add(int.MaxValue);

        return Check(powers, n, visited);
      }

      private bool Check(List<int> powers, int n, HashSet<int> visited)
      {
        if (n == 0)
          return true;

        for (var i = 0; i < powers.Count - 1; i++)
        {
          if (powers[i] <= n && n < powers[i + 1] && !visited.Contains(powers[i]))
          {
            visited.Add(powers[i]);
            return Check(powers, n - powers[i], visited);
          }
        }

        return false;
      }
    }
  }
}
