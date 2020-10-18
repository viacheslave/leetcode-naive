using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/jewels-and-stones/
  ///    Submission: https://leetcode.com/submissions/detail/233645374/
  /// </summary>
  internal class P0771
  {
    public class Solution
    {
      public int NumJewelsInStones(string J, string S)
      {
        var j = new HashSet<char>();
        foreach (var ch in J)
          j.Add(ch);

        var count = 0;
        foreach (var ch in S)
          if (j.Contains(ch))
            count++;

        return count;
      }
    }
  }
}
