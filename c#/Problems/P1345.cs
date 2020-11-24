using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/jump-game-iv/
  ///    Submission: https://leetcode.com/submissions/detail/423731368/
  /// </summary>
  internal class P1345
  {
    public class Solution
    {
      public int MinJumps(int[] arr)
      {
        if (arr.Length == 1)
          return 0;

        var indexMap = arr
          .Select((x, i) => (x, i))
          .GroupBy(x => x.x)
          .ToDictionary(
            x => x.Key,
            x => x.Select(_ => _.i).OrderByDescending(_ => _).ToList());

        var seen = new HashSet<int>();
        var queue = new Queue<(int index, int steps)>();

        queue.Enqueue((0, 0));
        seen.Add(0);

        while (queue.Count > 0)
        {
          var qi = queue.Dequeue();

          var set = new HashSet<(int index, int steps)>();

          if (qi.index - 1 >= 0)
          {
            if (!seen.Contains(qi.index - 1))
            {
              set.Add((qi.index - 1, qi.steps + 1));
              seen.Add(qi.index - 1);
            }
          }

          if (qi.index + 1 < arr.Length)
          {
            if (qi.index + 1 == arr.Length - 1)
              return qi.steps + 1;

            if (!seen.Contains(qi.index + 1))
            {
              set.Add((qi.index + 1, qi.steps + 1));
              seen.Add(qi.index + 1);
            }
          }

          foreach (var i in indexMap[arr[qi.index]])
          {
            if (!seen.Contains(i))
            {
              if (i == arr.Length - 1)
                return qi.steps + 1;

              set.Add((i, qi.steps + 1));
              seen.Add(i);
            }
          }

          foreach (var item in set.OrderByDescending(_ => _))
            queue.Enqueue(item);
        }

        // should not happen
        return -1;
      }
    }
  }
}
