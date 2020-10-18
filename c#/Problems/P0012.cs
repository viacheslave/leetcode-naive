using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/integer-to-roman/
  ///    Submission: https://leetcode.com/submissions/detail/228401382/
  /// </summary>
  internal class P0012
  {
    public class Solution
    {
      public string IntToRoman(int num)
      {
        StringBuilder sb = new StringBuilder();


        var power = 1;
        while (num >= power * 10)
        {
          power = power * 10;
        }

        while (true)
        {
          var digit = num / power;

          if (power == 1000)
          {
            ProcessPower(sb, digit, "M", "", "", "");
          }

          if (power == 100)
          {
            ProcessPower(sb, digit, "C", "CD", "D", "CM");
          }

          if (power == 10)
          {
            ProcessPower(sb, digit, "X", "XL", "L", "XC");
          }

          if (power == 1)
          {
            ProcessPower(sb, digit, "I", "IV", "V", "IX");
          }

          num = num - digit * power;

          power = power / 10;
          if (power == 0)
            break;
        }

        return sb.ToString();
      }

      private void ProcessPower(StringBuilder sb, int digit, string one, string four, string five, string nine)
      {
        if (digit <= 3)
          for (var i = 0; i < digit; i++)
            sb.Append(one);

        if (digit == 4)
          sb.Append(four);

        if (digit >= 5 && digit <= 8)
        {
          sb.Append(five);
          for (var i = 5; i < digit; i++)
            sb.Append(one);
        }

        if (digit == 9)
          sb.Append(nine);
      }
    }
  }
}
