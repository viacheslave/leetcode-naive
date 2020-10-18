using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-number/
  ///    Submission: https://leetcode.com/submissions/detail/240951061/
  /// </summary>
  internal class P0179
  {
    public class Solution
    {
      public string LargestNumber(int[] nums)
      {
        var maxLength = nums.Select(n => n.ToString().Length).Max();

        var numbers = new List<(int, int, int)>();

        foreach (var num in nums)
        {
          var numStr = num.ToString();
          var length = numStr.Length;
          var power = maxLength - length;

          var sb = new StringBuilder(numStr);

          if (power > 0)
          {
            var firstDigit = int.Parse(numStr[0].ToString());
            var lastDigit = int.Parse(numStr[numStr.Length - 1].ToString());

            for (int i = 0; i < power; i++)
              sb.Append(lastDigit > firstDigit ? lastDigit.ToString() : firstDigit.ToString());
          }

          numbers.Add((int.Parse(sb.ToString()), num, power));
        }

        var str = string.Concat(numbers.OrderByDescending(_ => _.Item1)
            .ThenBy(_ => _.Item3)
            .Select(_ => _.Item2.ToString()));

        str = str.TrimStart('0');
        return str == "" ? "0" : str;
      }

    }
  }
}
