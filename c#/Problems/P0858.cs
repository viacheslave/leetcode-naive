using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/mirror-reflection/
  ///    Submission: https://leetcode.com/submissions/detail/239719676/
  /// </summary>
  internal class P0858
  {
    public class Solution
    {
      public int MirrorReflection(int p, int q)
      {
        if (q == 0)
          return 0;

        var qpos = 0;
        for (var i = 0; ; i++)
        {
          qpos += q;
          if (qpos % p == 0)
          {
            if (i % 2 == 1)
              return 2;
            else
            {
              var div = qpos / p;
              if (div % 2 == 0)
                return 0;
              return 1;
            }
          }
        }

        return -1;
      }
    }
  }
}
