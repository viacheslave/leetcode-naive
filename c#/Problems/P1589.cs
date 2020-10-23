using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-sum-obtained-of-any-permutation/
  ///    Submission: https://leetcode.com/submissions/detail/412226388/
  /// </summary>
  internal class P1589
  {
    public class Solution
    {
      public int MaxSumRangeQuery(int[] nums, int[][] requests)
      {
        var map = new int[100001];

        var or = requests
          .SelectMany(x => new[] { (x[0], 1), (x[1] + 1, -1) })
          .OrderBy(x => x.Item1)
          .ToList();

        var diffs = or.GroupBy(x => x.Item1)
          .ToDictionary(x => x.Key, x => x.Sum(a => a.Item2));

        var sd = new SortedDictionary<int, int>(diffs);

        var keys = sd.Keys.ToArray();
        var current = 0;

        for (var keyIndex = 0; keyIndex < keys.Length - 1; keyIndex++)
        {
          var keyStart = keys[keyIndex];
          var keyEnd = keys[keyIndex + 1];

          current += sd[keyStart];

          for (var key = keyStart; key < keyEnd; key++)
            map[key] = current;
        }

        var frequencies = map
          .Where(x => x > 0)
          .Select(x => x)
          .OrderByDescending(x => x)
          .ToArray();

        nums = nums
          .OrderByDescending(x => x)
          .ToArray();

        var mod = (int)1e9 + 7;
        var ans = 0L;

        for (var i = 0; i < frequencies.Length; i++)
          ans += 1L * nums[i] * frequencies[i];

        return (int)(ans % mod);
      }
    }
  }
}
