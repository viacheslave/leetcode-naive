using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/frequency-of-the-most-frequent-element/
  ///    Submission: https://leetcode.com/submissions/detail/492236141/
  /// </summary>
  internal class P1838
  {
    public class Solution
    {
      public int MaxFrequency(int[] nums, int k)
      {
        var freqs = nums.GroupBy(c => c).ToDictionary(x => x.Key, x => x.Count());
        var ans = freqs.Max(x => x.Value);

        nums = nums.Distinct().OrderBy(x => x).ToArray();

        for (var i = 1; i < nums.Length; ++i)
        {
          var left = k;
          var count = freqs[nums[i]];

          var j = i - 1;
          while (j >= 0)
          {
            var diff = nums[i] - nums[j];

            var div = left / diff;
            div = Math.Min(div, freqs[nums[j]]);

            if (div == 0)
              break;

            left -= diff * div;
            count += div;

            ans = Math.Max(ans, count);
            j--;
          }
        }

        return ans;
      }
    }
  }
}
