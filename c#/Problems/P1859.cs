using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sorting-the-sentence/
  ///    Submission: https://leetcode.com/submissions/detail/493860057/
  /// </summary>
  internal class P1859
  {
    public class Solution
    {
      public string SortSentence(string s)
      {
        return string.Join(" ", s.Split(" ").Select(x => (x, x[^1])).OrderBy(x => x.Item2).Select(x => x.x.TrimEnd(x.Item2)));
      }
    }
  }
}
