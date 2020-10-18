using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-component-size-by-common-factor/
  ///    Submission: https://leetcode.com/submissions/detail/388454813/
  /// </summary>
  internal class P0952
  {
    public class Solution
    {
      public int LargestComponentSize(int[] A)
      {
        var map = new Dictionary<int, int>();

        foreach (var num in A)
        {
          for (var div = 2; div * div <= num; div++)
          {
            if (num % div == 0)
            {
              Union(num, div, map);
              Union(num, num / div, map);
            }
          }
        }

        var maxMap = new Dictionary<int, int>();

        foreach (var v in A)
        {
          var f = Find(v, map);

          if (maxMap.ContainsKey(f))
            maxMap[f]++;
          else
            maxMap[f] = 1;
        }

        var ans = maxMap.Max(v => v.Value);
        return ans;
      }

      public void Union(int a1, int a2, Dictionary<int, int> p)
      {
        int p1 = Find(a1, p);
        int p2 = Find(a2, p);

        if (p1 < p2)
          p[p2] = p1;
        else
          p[p1] = p2;
      }

      public int Find(int i, Dictionary<int, int> parent)
      {
        if (!parent.ContainsKey(i))
          parent[i] = i;

        while (i != parent[i])
          i = parent[i];

        return i;
      }
    }
  }
}
