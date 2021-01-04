using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-good-meals/
  ///    Submission: https://leetcode.com/submissions/detail/438032056/
  /// </summary>
  internal class P1711
  {
    public class Solution
    {
      public int CountPairs(int[] deliciousness)
      {
        // store count of each number
        // will be used in counting of pairs
        var set = deliciousness.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());
        var arr = deliciousness.Distinct().OrderBy(_ => _).ToArray();
        var mod = (int)1e9 + 7;

        var maxPow = 21;
        var powers = Enumerable.Range(0, 21).Select(i => 1 << i).ToHashSet();

        var ans = 0;

        for (var i = 0; i <= maxPow; i++)
        {
          var pow = 1 << i;

          // count of pairs
          // use two-pointers
          var count = CountPairs(arr, pow, set);

          ans += count;
          ans %= mod;
        }

        // if each element is power of two
        // elem + elem == power of two
        // then count pairs within elements
        foreach (var item in arr)
        {
          if (powers.Contains(item))
          {
            var mul = 0;
            if (set[item] % 2 == 0)
              ans += MultMod(set[item] / 2, set[item] - 1, mod);
            else
              ans += MultMod((set[item] - 1) / 2, set[item], mod);

            ans %= mod;
          }
        }

        return ans;
      }

      private int CountPairs(int[] arr, int pow, Dictionary<int, int> set)
      {
        var ans = 0;
        var mod = (int)1e9 + 7;

        var low = 0;
        var high = arr.Length - 1;

        while (low < arr.Length)
        {
          if (high <= low)
            high = low + 1;

          if (high == arr.Length)
            break;

          if (arr[low] + arr[high] > pow)
            while (high - low > 1 && arr[low] + arr[high] > pow)
              high--;
          else
            while (high < arr.Length - 1 && arr[low] + arr[high] < pow)
              high++;

          if (arr[low] + arr[high] == pow)
          {
            ans += MultMod(set[arr[low]], set[arr[high]], mod);
            ans %= mod;
          }

          low++;
        }

        return ans;
      }

      private static int MultMod(int a, int b, int mod)
      {
        var res = 0;
        a %= mod;

        while (b > 0)
        {
          if ((b & 1) > 0)
            res = (res + a) % mod;

          a = (2 * a) % mod;
          b >>= 1;
        }

        return res;
      }
    }
  }
}
