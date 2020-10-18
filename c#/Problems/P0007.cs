using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reverse-integer/
  ///    Submission: https://leetcode.com/submissions/detail/223367319/
  /// </summary>
  internal class P0007
  {
    public class Solution
    {
      public int Reverse(int x)
      {

        if (x == 0)
          return 0;


        int[] digits = new int[10];

        for (var i = 9; i >= 0; i--)
        {

          digits[9 - i] = x / (int)Math.Pow(10, i);
          x = x - digits[9 - i] * (int)Math.Pow(10, i);
        }

        int r = 0;
        bool v = false;
        int index = 0;

        try
        {
          for (var i = 0; i < 10; i++)
          {
            if (digits[i] == 0 && !v)
              continue;

            v = true;

            checked
            {
              r = r + digits[i] * (int)Math.Pow(10, index);
            }

            index++;
          }
        }
        catch (OverflowException ex)
        {
          return 0;
        }

        return r;
      }
    }
  }
}
