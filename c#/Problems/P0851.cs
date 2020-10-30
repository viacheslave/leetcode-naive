using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{

  /// <summary>
  ///    Problem: https://leetcode.com/problems/loud-and-rich/
  ///    Submission: https://leetcode.com/submissions/detail/414905253/
  /// </summary>
  internal class P0851
  {
    public class Solution
    {
      public int[] LoudAndRich(int[][] richer, int[] quiet)
      {
        var richMap = new Dictionary<int, HashSet<int>>();
        var topology = new Dictionary<int, HashSet<int>>();

        foreach (var item in richer)
        {
          if (!richMap.ContainsKey(item[1]))
            richMap[item[1]] = new HashSet<int>();

          richMap[item[1]].Add(item[0]);
        }

        for (var i = 0; i < quiet.Length; i++)
          DFS(i, topology, richMap);

        var ans = new int[quiet.Length];
        for (var i = 0; i < quiet.Length; i++)
        {
          if (!topology[i].Any())
          {
            ans[i] = i;
            continue;
          }

          ans[i] = topology[i]
            .Select(x => (person: x, q: quiet[x])).Concat(new[] { (person: i, q: quiet[i]) })
            .OrderBy(x => x.Item2)
            .First()
            .person;
        }

        return ans;
      }

      private void DFS(int i, Dictionary<int, HashSet<int>> topology, Dictionary<int, HashSet<int>> richMap)
      {
        if (topology.ContainsKey(i))
          return;

        topology[i] = new HashSet<int>();

        if (!richMap.ContainsKey(i))
          return;

        var hs = new HashSet<int>();

        foreach (var n in richMap[i])
        {
          hs.Add(n);

          DFS(n, topology, richMap);

          hs.UnionWith(topology[n]);
        }

        topology[i] = hs;
      }
    }
  }
}
