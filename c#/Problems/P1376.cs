using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/time-needed-to-inform-all-employees/
  ///    Submission: https://leetcode.com/submissions/detail/310956024/
  /// </summary>
  internal class P1376
  {
    public class Solution
    {
      public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
      {
        var map = new Dictionary<int, List<int>>();
        for (int i = 0; i < manager.Length; i++)
        {
          if (!map.ContainsKey(manager[i]))
            map[manager[i]] = new List<int>();
          map[manager[i]].Add(i);
        }

        var an = new Dictionary<int, int>();

        var q = new Queue<(int, int)>();
        q.Enqueue((headID, 0));

        while (q.Count > 0)
        {
          var item = q.Dequeue();
          var itemInformTime = informTime[item.Item1];

          an.Add(item.Item1, item.Item2);

          if (map.ContainsKey(item.Item1))
            foreach (var child in map[item.Item1])
              q.Enqueue((child, item.Item2 + itemInformTime));
        }

        return an.Max(a => a.Value);
      }
    }
  }
}
