using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/hand-of-straights/
  ///    Submission: https://leetcode.com/submissions/detail/239805184/
  /// </summary>
  internal class P0846
  {
    public class Solution
    {
      public bool IsNStraightHand(int[] hand, int W)
      {
        if (hand.Length == 0 || hand.Length % W != 0)
          return false;

        var map = hand.GroupBy(h => h).ToDictionary(h => h.Key, h => h.Count());
        var sd = new SortedDictionary<int, int>(map);
        var groups = hand.Length / W;

        for (int i = 0; i < groups; i++)
        {
          var min = sd.First().Key;
          for (int j = 0; j < W; j++)
          {
            var card = min + j;
            if (!sd.ContainsKey(card))
              return false;

            if (sd[card] == 1) sd.Remove(card);
            else sd[card]--;
          }
        }

        return true;
      }
    }
  }
}
