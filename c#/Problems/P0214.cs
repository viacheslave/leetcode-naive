using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/shortest-palindrome/
  ///    Submission: https://leetcode.com/submissions/detail/437198974/
  /// </summary>
  internal class P0214 
  {
    public class Solution
    {
      public string ShortestPalindrome(string s)
      {
        if (s.Length <= 1)
          return s;

        var fo = new RollingHash(s);
        var rv = new RollingHash(new string(s.ToCharArray().Reverse().ToArray()));

        // check current string
        if (s.Length % 2 == 0 &&
          fo.Hash(s.Length / 2, s.Length - 1) == rv.Hash(s.Length / 2, s.Length - 1))
        {
          return s;
        }

        var palindromeLength = 1;

        // pick middle
        // check left and right parts
        for (var i = s.Length / 2 + 1; i < s.Length; i++)
        {
          var length = s.Length - i;

          var r = rv.Hash(i, i + length - 1);
          var f2 = fo.Hash(s.Length - i + 1, s.Length - i + 1 + length - 1);

          if (r == f2)
          {
            palindromeLength = (s.Length - i + 1 + length - 1) + 1;
            break;
          }

          var f1 = fo.Hash(s.Length - i, s.Length - i + length - 1);

          if (r == f1)
          {
            palindromeLength = (s.Length - i + length - 1) + 1;
            break;
          }
        }

        var prefix = s.Substring(palindromeLength);
        var ans = new string(prefix.ToCharArray().Reverse().ToArray()) + s;

        return ans;
      }

      public class RollingHash
      {
        long[] p;
        long[] h;

        const long A = 3176161685720312321;
        const long B = 78556651776524353;

        public RollingHash(string text)
        {
          h = new long[text.Length];
          p = new long[text.Length];

          h[0] = text[0] % B;
          p[0] = 1;

          for (var i = 1; i < text.Length; i++)
          {
            h[i] = (Mod(h[i - 1], A, B) + text[i]) % B;
            p[i] = (Mod(p[i - 1], A, B)) % B;
          }
        }

        public long Hash(int from, int to)
        {
          return Hash(h, p, from, to, B);
        }

        private long Hash(long[] h, long[] p, long a, long b, long B)
        {
          if (a == 0)
            return h[b];

          return ((h[b] + B) - Mod(h[a - 1], p[b - a + 1], B)) % B;
        }

        private long Mod(long a, long b, long mod)
        {
          var res = 0L;
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
}
