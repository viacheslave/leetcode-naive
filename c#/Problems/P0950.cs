using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reveal-cards-in-increasing-order/
  ///    Submission: https://leetcode.com/submissions/detail/231276358/
  /// </summary>
  internal class P0950
  {
    public class Solution
    {
      public int[] DeckRevealedIncreasing(int[] deck)
      {
        if (deck.Length < 2)
          return deck;

        var res = new List<int>();

        Array.Sort(deck);

        var deckList = new List<int>(deck);

        while (deckList.Count > 0)
        {
          if (res.Count > 0)
          {
            res.Insert(0, res[res.Count - 1]);
            res.RemoveAt(res.Count - 1);
          }

          res.Insert(0, deckList[deckList.Count - 1]);
          deckList.RemoveAt(deckList.Count - 1);
        }

        return res.ToArray();
      }
    }
  }
}
