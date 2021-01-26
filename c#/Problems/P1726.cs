using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/tuple-with-same-product/
  ///    Submission: https://leetcode.com/submissions/detail/444086681/
  /// </summary>
  internal class P1726
  {
    public class Solution
    {
      public int TupleSameProduct(int[] nums)
      {
        var freq = new Dictionary<int, int>();

        nums = nums.Distinct().ToArray();

        // count frequency of each product
        for (var i = 0; i < nums.Length; i++)
        {
          for (var j = i + 1; j < nums.Length; j++)
          {
            var product = nums[i] * nums[j];

            if (!freq.ContainsKey(product))
              freq[product] = 0;

            freq[product]++;
          }
        }

        // we need only > 1
        freq = freq.Where(f => f.Value > 1).ToDictionary(x => x.Key, x => x.Value);

        var ans = 0;

        // calculate permutations
        foreach (var kvp in freq)
        {
          var count = (kvp.Value) * (kvp.Value - 1) / 2;
          ans += count * 8;
        }

        return ans;
      }
    }
  }
}
