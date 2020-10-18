using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sequential-digits/
  ///    Submission: https://leetcode.com/submissions/detail/286120041/
  /// </summary>
  internal class P1291
  {
    public class Solution
    {
      public IList<int> SequentialDigits(int low, int high)
      {
        var ans = new List<int>();

        var lowDigits = (int)Math.Log10(low) + 1;
        var highDigits = (int)Math.Log10(high) + 1;

        for (int d = lowDigits; d <= highDigits; d++)
          ans.AddRange(GetRange(d, low, high));

        ans.Sort();
        return ans;
      }

      private IEnumerable<int> GetRange(int d, int low, int high)
      {
        var range = new List<int>();
        var template = "123456789";

        for (int i = 0; i < template.Length; i++)
        {
          if (i + d > template.Length)
            break;
          var value = int.Parse(template.Substring(i, d));
          if (value >= low && value <= high)
            range.Add(value);
        }

        return range;
      }
    }
  }
}
