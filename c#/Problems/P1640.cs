using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-array-formation-through-concatenation/
  ///    Submission: https://leetcode.com/submissions/detail/415577737/
  /// </summary>
  internal class P1640
  {
    public class Solution
    {
      public bool CanFormArray(int[] arr, int[][] pieces)
      {
        var list = arr.ToList();
        var sets = pieces.Select(s => s.ToList()).ToList();

        while (list.Count > 0)
        {
          var set = sets.FirstOrDefault(s =>
              list.Count >= s.Count &&
              list.Take(s.Count).Select((x, i) => (x, i)).All(x => x.x == s[x.i]));

          if (set == null)
            return false;

          list = list.Skip(set.Count).ToList();
        }

        return true;
      }
    }
  }
}
