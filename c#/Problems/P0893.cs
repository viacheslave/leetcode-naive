using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/groups-of-special-equivalent-strings/
  ///    Submission: https://leetcode.com/submissions/detail/231510520/
  /// </summary>
  internal class P0893
  {
    public class Solution
    {
      public int NumSpecialEquivGroups(string[] A)
      {
        var dss = new Dictionary<string, Dictionary<int, string>>();

        foreach (var s in A)
        {
          var odd = new List<char>(s.Length);
          var even = new List<char>(s.Length);

          for (var i = 0; i < s.Length; i++)
          {
            if (i % 2 == 0)
              odd.Add(s[i]);
            else
              even.Add(s[i]);
          }

          var oddar = odd.ToArray();
          Array.Sort(oddar);

          var evenar = even.ToArray();
          Array.Sort(evenar);

          var ds = new Dictionary<int, string>();
          ds[0] = new string(evenar);
          ds[1] = new string(oddar);

          dss[s] = ds;
        }

        return dss.GroupBy(_ => new { o = _.Value[1], e = _.Value[0] })
            .Count();
      }
    }
  }
}
