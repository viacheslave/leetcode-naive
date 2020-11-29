using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/make-sum-divisible-by-p/
  ///    Submission: https://leetcode.com/submissions/detail/425324954/
  /// </summary>
  internal class P1590
  {
    public class Solution
    {
      public int MinSubarray(int[] nums, int p)
      {
        var ans = int.MaxValue;

        var rem = (int)(nums.Select(f => (long)f).Sum() % p);
        if (rem == 0)
          return 0;

        var pre = new int[nums.Length + 1];
        for (var i = 0; i < nums.Length; ++i)
          pre[i + 1] = (pre[i] + nums[i]) % p;

        var lastpos = new Dictionary<int, List<int>>();
        for (var i = 0; i < nums.Length; ++i)
        {
          if (!lastpos.ContainsKey(pre[i + 1]))
            lastpos.Add(pre[i + 1], new List<int>());

          lastpos[pre[i + 1]].Add(i);
        }

        for (var i = 0; i < pre.Length; ++i)
        {
          var target = (pre[i] + rem) % p;
          if (lastpos.ContainsKey(target))
          {
            foreach (var ind in lastpos[target])
            {
              if (ind < i)
                continue;

              ans = Math.Min(ans, ind - i + 1);
              break;
            }
          }
        }

        return (ans == int.MaxValue || ans == nums.Length) ? -1 : ans;
      }
    }
  }
}
