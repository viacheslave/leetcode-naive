using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/partition-to-k-equal-sum-subsets/
  ///    Submission: https://leetcode.com/submissions/detail/433056179/
  /// </summary>
  internal class P0698
  {
    public class Solution
    {
      public bool CanPartitionKSubsets(int[] nums, int k)
      {
        var sum = nums.Sum() / k;

        if (nums.Sum() % k != 0)
          return false;

        // try to fill in greater elements first
        nums = nums.OrderByDescending(x => x).ToArray();

        var bucketSum = Enumerable.Repeat(0, k).ToArray();
        var ans = Rec(nums, k, sum, bucketSum, 0);

        return ans;
      }

      private bool Rec(int[] nums, int k, int sum, int[] bucketSum, int index)
      {
        if (index == nums.Length)
          return bucketSum.All(d => d == sum);

        var ans = false;

        for (var bi = 0; bi < bucketSum.Length; bi++)
        {
          if (bucketSum[bi] == sum)
            continue;

          if (bucketSum[bi] + nums[index] <= sum)
          {
            bucketSum[bi] += nums[index];

            ans |= Rec(nums, k, sum, bucketSum, index + 1);
            if (ans)
              return true;

            bucketSum[bi] -= nums[index];
          }
        }

        return false;
      }
    }
  }
}
