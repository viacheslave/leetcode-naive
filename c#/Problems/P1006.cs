using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/clumsy-factorial/
  ///    Submission: https://leetcode.com/submissions/detail/230212619/
  /// </summary>
  internal class P1006
  {
    public class Solution
    {
      public int Clumsy(int N)
      {
        var sum = 0;
        var temp = 0;
        var pos = 1;

        for (var i = 1; i <= N; i++)
        {
          var number = N - i + 1;

          if (i % 4 == 1)
          {
            temp = number;
          }

          if (i % 4 == 2)
          {
            temp = temp * number;
          }

          if (i % 4 == 3)
          {
            temp = (int)Math.Floor(1d * temp / number);

            sum += pos * temp;

            temp = 0;
            pos = -1;
          }

          if (i % 4 == 0)
          {
            sum += number;
          }
        }

        sum += pos * temp;

        return sum;
      }
    }
  }
}
