using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/push-dominoes/
  ///    Submission: https://leetcode.com/submissions/detail/388116585/
  /// </summary>
  internal class P0838
  {
    public class Solution
    {
      public string PushDominoes(string dominoes)
      {
        var indexes = new Dictionary<int, int>();
        var sb = new StringBuilder(dominoes);

        for (int i = 0; i < dominoes.Length; i++)
        {
          if (dominoes[i] == 'L') indexes.Add(i, -1);
          if (dominoes[i] == 'R') indexes.Add(i, +1);
        }

        while (indexes.Count > 0)
        {
          foreach (var key in indexes.Keys.ToList())
          {
            var k = indexes[key];

            if (k == -1)
            {
              // last
              if (key == 0 || sb[key - 1] != '.')
              {
                indexes.Remove(key);
                continue;
              }

              if (sb[key - 1] == '.')
              {
                if (key - 2 >= 0 && sb[key - 2] == 'R' && !indexes.ContainsKey(key - 2))
                  indexes.Remove(key);
                else
                {
                  sb[key - 1] = 'L';
                  indexes.Remove(key);
                  indexes.Add(key - 1, -1);
                }
              }
            }

            if (k == 1)
            {
              // last
              if (key == sb.Length - 1 || sb[key + 1] != '.')
              {
                indexes.Remove(key);
                continue;
              }

              if (sb[key + 1] == '.')
              {
                if (key + 2 < sb.Length && sb[key + 2] == 'L')
                  indexes.Remove(key);
                else
                {
                  sb[key + 1] = 'R';
                  indexes.Remove(key);
                  indexes.Add(key + 1, +1);
                }
              }
            }
          }
        }

        return sb.ToString();
      }
    }
  }
}
