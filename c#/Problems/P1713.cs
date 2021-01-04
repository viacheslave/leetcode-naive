using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-operations-to-make-a-subsequence/submissions/
  ///    Submission: https://leetcode.com/submissions/detail/437949662/
  /// </summary>
  internal class P1713
  {
    public class Solution
    {
      public int MinOperations(int[] target, int[] arr)
      {
        // save positions of elements in target
        // replace elements of arr with saved indexes
        // remove other elements

        var set = new Dictionary<int, int>();
        for (var i = 0; i < target.Length; i++)
          set[target[i]] = i;

        for (var i = 0; i < arr.Length; i++)
          if (set.ContainsKey(arr[i]))
            arr[i] = set[arr[i]];
          else
            arr[i] = -1;

        arr = arr
          .Where(a => a >= 0)
          .ToArray();

        // then the task is to find a Longest Increasing SubSequence in arr
        // in O(nlogn) time: [0:n], binary search

        var ans = target.Length - LengthOfLIS(arr);
        return ans;
      }

      public int LengthOfLIS(int[] nums)
      {
        var index = 1;

        var dp = new int[nums.Length];
        dp[0] = nums[0];

        foreach (var num in nums)
        {
          if (dp[index - 1] < num)
          {
            dp[index] = num;
            index++;
          }
          else
          {
            int pos = BinarySearch(dp, 0, index - 1, num);
            dp[pos] = num;
          }
        }

        return index;
      }

      private int BinarySearch(int[] dp, int from, int to, int target)
      {
        while (from <= to)
        {
          int mid = from + (to - from) / 2;

          if (dp[mid] == target)
            return mid;
          else if (dp[mid] > target)
            to = mid - 1;
          else if (dp[mid] < target)
            from = mid + 1;
        }

        return from;
      }
    }
  }
}
