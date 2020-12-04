using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-chunked-palindrome-decomposition/
  ///    Submission: https://leetcode.com/submissions/detail/426895616/
  /// </summary>
  internal class P1147
  {
    public class Solution
    {
      public int LongestDecomposition(string text)
      {
        var r = new RollingHash(text);

        var dp = new Dictionary<int, int>();

        for (var i = 0; i < text.Length; i++)
        {
          if (dp.Count == 0)
          {
            if (r.Eq(0, i, text.Length - 1 - i, text.Length - 1))
              dp[i] = 1;
            continue;
          }

          var next = new Dictionary<int, int>();

          foreach (var entry in dp)
          {
            var start = entry.Key + 1;
            var end = i;

            if (r.Eq(start, end, text.Length - 1 - end, text.Length - 1 - start))
            {
              next[i] = next.ContainsKey(i)
                ? Math.Max(next[i], entry.Value + 1)
                : entry.Value + 1;
            }
            else
            {
              next[entry.Key] = entry.Value;
            }
          }

          dp = next;
        }

        return dp.Max(d => d.Value);
      }

      public class RollingHash
      {
        int[] p;
        int[] h;

        const int A = 911382323;
        const int B = 972663749;

        public RollingHash(string text)
        {
          h = new int[text.Length];
          p = new int[text.Length];

          h[0] = text[0] % B;
          p[0] = 1;

          for (var i = 1; i < text.Length; i++)
          {
            h[i] = (Mod(h[i - 1], A, B) + text[i]) % B;
            p[i] = (Mod(p[i - 1], A, B)) % B;
          }
        }

        public bool Eq(int from1, int to1, int from2, int to2)
        {
          return Hash(h, p, from1, to1, B) ==
            Hash(h, p, from2, to2, B);
        }

        private int Hash(int[] h, int[] p, int a, int b, int B)
        {
          if (a == 0)
            return h[b];

          return ((h[b] + B) - Mod(h[a - 1], p[b - a + 1], B)) % B;
        }

        private int Mod(int a, int b, int mod)
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
}
