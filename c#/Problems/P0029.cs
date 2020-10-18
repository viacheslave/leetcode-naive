using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/divide-two-integers/
  ///    Submission: https://leetcode.com/submissions/detail/295566487/
  /// </summary>
  internal class P0029
  {
    public class Solution
    {
      public int Divide(int dividend, int divisor)
      {
        if (dividend == 0)
          return 0;

        if (dividend == int.MinValue && divisor == -1)
          return int.MaxValue;

        if (dividend == int.MinValue && divisor == 1)
          return int.MinValue;

        if (divisor == int.MinValue)
        {
          if (dividend == int.MinValue)
            return 1;
          return 0;
        }

        var pos = (dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0);

        var div1 = dividend.ToString().TrimStart('-').ToList();
        divisor = Math.Abs(divisor);

        var ans = "";
        long curDiv = 0;

        while (div1.Count > 0)
        {
          while (curDiv < divisor)
          {
            if (div1.Count == 0)
              return Ret(pos, ans);

            curDiv = Mult10(curDiv) + int.Parse(div1[0].ToString());
            div1.RemoveAt(0);

            if (curDiv < divisor)
              ans += "0";
          }

          var digit = 1;
          long subsum = divisor;
          while (subsum <= curDiv)
          {
            digit++;
            subsum += divisor;
          }

          curDiv -= (subsum - divisor);

          ans += (digit - 1).ToString();
        }

        return Ret(pos, ans);
      }

      private static int Ret(bool pos, string ans)
      {
        var a = int.Parse(ans);
        if (!pos)
          a = -a;

        return a;
      }

      private static long Mult10(long value)
      {
        var ans = 0L;
        for (int i = 0; i < 10; i++)
          ans += value;
        return ans;
      }
    }
  }
}
