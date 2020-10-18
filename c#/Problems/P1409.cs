using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/queries-on-a-permutation-with-key/
  ///    Submission: https://leetcode.com/submissions/detail/324355708/
  /// </summary>
  internal class P1409
  {
    public class Solution
    {
      public int[] ProcessQueries(int[] queries, int m)
      {
        var list = Enumerable.Range(1, m).ToList();
        var ans = new List<int>(queries.Length);

        foreach (var q in queries)
        {
          var pos = list.IndexOf(q);
          ans.Add(pos);

          list.RemoveAt(pos);
          list.Insert(0, q);
        }

        return ans.ToArray();
      }
    }
  }
}
