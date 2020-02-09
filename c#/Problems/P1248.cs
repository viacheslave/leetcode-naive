using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-number-of-nice-subarrays/
	///		Submission: https://leetcode.com/submissions/detail/291476922/
	/// </summary>
	internal class P1248
	{
    public int NumberOfSubarrays(int[] nums, int k)
    {
      var ans = 0;

      var pref = new int[nums.Length];
      var suff = new int[nums.Length];

      for (int i = 0; i < nums.Length - 1; i++)
      {
        if (i == 0)
        {
          pref[i + 1] = IsOdd(nums, i);
          suff[i + 1] = IsOdd(nums, nums.Length - 1);
          continue;
        }

        pref[i + 1] = pref[i] + IsOdd(nums, i);
        suff[i + 1] = suff[i] + IsOdd(nums, nums.Length - i - 1);
      }

      var all = nums.Count(x => x % 2 == 1);

      var start = 0;
      var end = nums.Length - start - 1;

      // 2, 2, 2, 1, 2, 2, 1, 2, 2, 2
      while (start < nums.Length)
      {
        while (end >= 0 && all - pref[start] - suff[end] < k)
        {
          end--;
        }

        if (end == -1)
          break;

        var left = -1;

        while (end >= 0 && all - pref[start] - suff[end] == k)
        {
          if (left == -1)
            left = end;

          ans++;
          end--;
        }

        start++;
        end = nums.Length - start - 1;

        if (left != -1)
        {
          if (left < end)
            end = left;
        }
      }

      return ans;
    }

    private int IsOdd(int[] nums, int index)
    {
      return nums[index] % 2 == 1 ? 1 : 0;
    }
  }
}
