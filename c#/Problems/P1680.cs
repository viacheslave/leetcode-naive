namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers/
  ///    Submission: https://leetcode.com/submissions/detail/427774541/
  /// </summary>
  internal class P1680
  {
    public class Solution
    {
      public int ConcatenatedBinary(int n)
      {
        var ans = 0;
        var length = 1;
        var nextpower = 2; // to determine binary length of next element
        var mod = (int)1e9 + 7;

        for (var i = 1; i <= n; i++)
        {
          if (i >= nextpower)
          {
            length++;
            nextpower <<= 1;
          }

          ans = MultMod(ans, 1 << length, mod);
          ans += i;
          ans %= mod;
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
