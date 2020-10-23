namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/132-pattern/
  ///    Submission: https://leetcode.com/submissions/detail/412192589/
  /// </summary>
  internal class P0456
  {
    public class Solution
    {
      public bool Find132pattern(int[] nums)
      {
        if (nums.Length < 3)
          return false;

        var leftmin = nums[0];

        for (var i = 1; i < nums.Length - 1; ++i)
        {
          var current = nums[i];

          if (current < leftmin)
          {
            leftmin = current;
            continue;
          }

          for (var j = i + 1; j < nums.Length; ++j)
          {
            if (nums[j] < current && nums[j] > leftmin)
              return true;
          }
        }

        return false;
      }
    }
  }
}
