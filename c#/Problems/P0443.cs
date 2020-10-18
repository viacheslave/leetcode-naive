using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/string-compression/
  ///    Submission: https://leetcode.com/submissions/detail/228428605/
  /// </summary>
  internal class P0443
  {
    public class Solution
    {
      public int Compress(char[] chars)
      {
        if (chars.Length == 0)
          return 0;

        if (chars.Length == 1)
          return 1;

        var ch = chars[0];
        var startIndex = 0;
        var endIndex = 0;
        var lastWrittenIndex = -1;
        var i = 0;

        while (i <= chars.Length)
        {
          if (i != chars.Length && chars[i] == ch)
          {
            endIndex = i;
          }

          if (i == chars.Length || chars[i] != ch)
          {
            //if (i == chars.Length - 1)
            //	endIndex = i;

            var count = endIndex - startIndex + 1;
            var start = lastWrittenIndex + 1;

            // char
            chars[start] = ch;

            if (count > 1)
            {
              // digits
              var digits = GetDigits(count);

              for (var j = 0; j < digits.Length; j++)
                chars[start + 1 + j] = digits[j];

              lastWrittenIndex = start + digits.Length;
            }
            else
            {
              lastWrittenIndex = start;
            }

            startIndex = endIndex = (i);

            if (i != chars.Length)
              ch = chars[i];
          }

          i++;
        }

        return lastWrittenIndex + 1;
      }

      private char[] GetDigits(int count)
      {
        var power = 1;
        while (count / power >= 10)
        {
          power = power * 10;
        }

        var ret = new List<char>();

        while (power != 0)
        {
          var digit = count / power;
          count = count - digit * power;

          power = power / 10;
          ret.Add(Char.Parse(digit.ToString()));
        }

        return ret.ToArray();
      }
    }
  }
}
