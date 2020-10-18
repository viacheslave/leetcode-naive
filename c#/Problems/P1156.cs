using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/swap-for-longest-repeated-character-substring/
  ///    Submission: https://leetcode.com/submissions/detail/312722097/
  /// </summary>
  internal class P1156
  {
    public class Solution
    {
      public int MaxRepOpt1(string text)
      {
        var map = new Dictionary<char, List<(int, int)>>();

        var ch = text[0];
        var start = 0;

        for (var i = 1; i < text.Length; i++)
        {
          if (text[i] == ch)
          {
            if (!map.ContainsKey(ch))
              map[ch] = new List<(int, int)>();

            if (i == text.Length - 1)
              map[ch].Add((start, i));

            continue;
          }


          if (!map.ContainsKey(ch))
            map[ch] = new List<(int, int)>();

          map[ch].Add((start, i - 1));
          start = i;
          ch = text[i];

          if (!map.ContainsKey(ch))
            map[ch] = new List<(int, int)>();

          if (i == text.Length - 1)
            map[ch].Add((start, i));
        }

        var ans = 0;
        foreach (var item in map)
        {
          if (item.Value.Count == 1)
          {
            ans = Math.Max(ans, item.Value[0].Item2 - item.Value[0].Item1 + 1);
            continue;
          }

          for (int i = 0; i < item.Value.Count; i++)
          {
            var th = item.Value[i];

            if (i + 1 < item.Value.Count)
            {
              var ne = item.Value[i + 1];

              if (ne.Item1 - th.Item2 == 2)
              {
                if (item.Value.Count == 2)
                  ans = Math.Max(ans, ne.Item2 - th.Item1);
                else
                  ans = Math.Max(ans, ne.Item2 - th.Item1 + 1);
              }

              else if (ne.Item1 - th.Item2 > 2)
              {
                ans = Math.Max(ans, ne.Item2 - ne.Item1 + 2);
                ans = Math.Max(ans, th.Item2 - th.Item1 + 2);
              }
            }
          }
        }

        return ans;
      }
    }
  }
}
