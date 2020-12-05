using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-duplicate-substring/submissions/
  ///    Submission: https://leetcode.com/submissions/detail/427423464/
  /// </summary>
  internal class P1044
  {
    public class Solution
    {
      public string LongestDupSubstring(string s)
      {
        var rh = new RollingHash(s);

        var start = 1;
        var end = s.Length - 1;

        while (true)
        {
          if (end - start == 1)
          {
            var data = WorksFor(rh, end, s);
            if (data != null)
              return data;

            data = WorksFor(rh, start, s);
            if (data != null)
              return data;

            return "";
          }

          var mid = (start + end) / 2;
          var m = WorksFor(rh, mid, s);

          if (m == null)
            end = mid;
          else
            start = mid;
        }
      }

      private string WorksFor(RollingHash rh, int length, string s)
      {
        var map = new HashSet<long>();

        for (var i = 0; i < s.Length - length + 1; i++)
        {
          var hash = rh.Hash(i, i + length - 1);

          if (map.Contains(hash))
            return s.Substring(i, length);

          map.Add(hash);
        }

        return null;
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
