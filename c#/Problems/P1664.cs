using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/ways-to-make-a-fair-array/
  ///    Submission: https://leetcode.com/submissions/detail/422922910/
  /// </summary>
  internal class P1664
  {
    public class Solution
    {
      public int WaysToMakeFair(int[] nums)
      {
        var even = new int[nums.Length + 2];
        var odd = new int[nums.Length + 2];

        for (var i = 0; i < nums.Length; i += 2)
          even[i + 2] = even[i + 1] = even[i] + nums[i];

        for (var i = 1; i < nums.Length; i += 2)
          odd[i + 2] = odd[i + 1] = odd[i] + nums[i];

        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
          var pre = i - 1;
          int preodd = 0;
          int preeven;

          if (i % 2 == 0)
          {
            // even
            preeven = pre < 0 ? 0 : even[pre + 1];
            preodd = pre < 0 ? 0 : odd[pre + 1];
          }
          else
          {
            // odd
            preeven = even[pre + 1];
            preodd = odd[pre + 1];
          }

          var posteven = even[nums.Length] - even[i + 1];
          var postodd = odd[nums.Length] - odd[i + 1];

          var sum1 = preeven + postodd;
          var sum2 = preodd + posteven;

          if (sum1 == sum2)
            ans++;
        }

        return ans;
      }
    }
  }
}
