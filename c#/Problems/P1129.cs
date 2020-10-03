using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/shortest-path-with-alternating-colors/
	///		Submission: https://leetcode.com/submissions/detail/404016452/
	/// </summary>
	internal class P1129
	{
    public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges)
    {
      var red = red_edges
          .GroupBy(x => x[0])
          .ToDictionary(x => x.Key, x => x.Select(v => v[1]).ToList());

      var blue = blue_edges
          .GroupBy(x => x[0])
          .ToDictionary(x => x.Key, x => x.Select(v => v[1]).ToList());

      var ans = Enumerable.Repeat(int.MaxValue, n).ToList();
      ans[0] = 0;

      var resRed = new Dictionary<int, int>() { };
      var resBlue = new Dictionary<int, int>() { };

      var queue = new Queue<(int number, int color, int value)>();
      queue.Enqueue((0, 0, 0));
      queue.Enqueue((0, 1, 0));

      while (queue.Count > 0)
      {
        var item = queue.Dequeue();

        var storage = item.color == 0 ? resRed : resBlue;
        var nextColor = 1 - item.color;

        if (!storage.ContainsKey(item.number) || storage[item.number] > item.value)
        {
          storage[item.number] = item.value;

          var edgeMap = nextColor == 0 ? red : blue;

          if (edgeMap.ContainsKey(item.number))
          {
            foreach (var egde in edgeMap[item.number])
              queue.Enqueue((egde, nextColor, item.value + 1));
          }
        }
      }

      foreach (var item in resRed)
        ans[item.Key] = Math.Min(item.Value, ans[item.Key]);

      foreach (var item in resBlue)
        ans[item.Key] = Math.Min(item.Value, ans[item.Key]);

      for (int i = 0; i < ans.Count; i++)
      {
        if (ans[i] == int.MaxValue)
          ans[i] = -1;
      }

      return ans.ToArray();
    }
  }
}
