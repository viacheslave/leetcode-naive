using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers/
  ///    Submission: https://leetcode.com/submissions/detail/427828710/
  /// </summary>
  internal class P1296
  {
    public class Solution
    {
      public bool IsPossibleDivide(int[] nums, int k)
      {
        var map = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var sd = new SortedList<int, int>(map);

        while (sd.Count > 0)
        {
          var range = Enumerable.Range(sd.Keys[0], k);

          foreach (var item in range)
          {
            if (!sd.ContainsKey(item))
              return false;

            sd[item]--;
            if (sd[item] == 0)
              sd.Remove(item);
          }
        }

        return true;
      }
    }
  }
}
