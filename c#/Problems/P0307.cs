using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/range-sum-query-mutable/
	///		Submission: https://leetcode.com/submissions/detail/301715678/
	/// </summary>
	internal class P0307
	{
    public class NumArray
		{
      private int[] nums;
      private int[] rangeSum;

      public NumArray(int[] nums)
      {
        this.nums = nums;
        this.rangeSum = new int[nums.Length];
        BuildRanges(0);
      }

      public void Update(int i, int val)
      {
        nums[i] = val;
        BuildRanges(i);
      }

      public int SumRange(int i, int j)
      {
        if (i == 0)
          return rangeSum[j];

        return rangeSum[j] - rangeSum[i - 1];
      }

      private void BuildRanges(int start)
      {
        for (int i = start; i < nums.Length; i++)
        {
          if (i == 0)
            rangeSum[i] = nums[i];
          else
            rangeSum[i] = rangeSum[i - 1] + nums[i];
        }
      }
    }
  }
}
