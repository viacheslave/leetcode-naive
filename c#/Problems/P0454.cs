using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/4sum-ii/submissions/
  ///    Submission: https://leetcode.com/submissions/detail/431582887/
  /// </summary>
  internal class P0454
  {
    public class Solution
    {
      public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
      {
        var length = A.Length;

        // compress to two sequences
        var a = new int[length * length];
        var b = new int[length * length];

        for (int i = 0; i < length; i++)
        {
          for (int j = 0; j < length; j++)
          {
            a[i * length + j] = A[i] + B[j];
            b[i * length + j] = C[i] + D[j];
          }
        }

        // create hashmaps of value -> count of that value
        var map_a = a.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());
        var map_b = b.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());

        var sorted_a = map_a.Keys.OrderBy(_ => _).ToArray();
        var sorted_b = map_b.Keys.OrderBy(_ => _).ToArray();

        var ans = 0;

        var ai = 0;
        var bi = sorted_b.Length - 1;

        // two pointers
        while (ai < sorted_a.Length)
        {
          while (bi >= 0 && sorted_a[ai] + sorted_b[bi] >= 0)
          {
            if (sorted_a[ai] + sorted_b[bi] == 0)
            {
              ans += map_a[sorted_a[ai]] * map_b[sorted_b[bi]];
              break;
            }

            bi--;
          }

          if (bi < 0)
            break;

          ai++;
        }

        return ans;
      }
    }
  }
}
