using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/3sum-with-multiplicity/
  ///    Submission: https://leetcode.com/submissions/detail/471436469/
  /// </summary>
  internal class P0923
  {
    public class Solution
    {
      public int ThreeSumMulti(int[] A, int target)
      {
        var map = A.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
        var arr = A.Distinct().OrderBy(x => x).ToList();

        var ans = 0L;

        for (var i = 0; i < arr.Count; i++)
        {
          var j = i;
          var k = arr.Count - 1;

          var sum = target - arr[i];
          var a0 = arr[i];

          while (j <= k)
          {
            var a1 = arr[j];
            var a2 = arr[k];

            if (a1 + a2 < sum)
            {
              j++;
              continue;
            }

            if (a1 + a2 > sum)
            {
              k--;
              continue;
            }

            if (i < j && j < k)
            {
              ans += 1L * map[a0] * map[a1] * map[a2];
            }
            else if (i == j && j < k)
            {
              ans += 1L * map[a0] * (map[a0] - 1) / 2 * map[a2];
            }
            else if (i < j && j == k)
            {
              ans += 1L * map[a0] * map[a2] * (map[a2] - 1) / 2;
            }
            else
            {
              ans += 1L * map[a0] * (map[a0] - 1) * (map[a0] - 2) / 6;
            }

            j++;
            k--;
          }
        }

        return (int)(ans % 1_000_000_007);
      }
    }
  }
}
