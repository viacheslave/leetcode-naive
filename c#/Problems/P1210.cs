using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-moves-to-reach-target-with-rotations/
  ///    Submission: https://leetcode.com/submissions/detail/424012141/
  /// </summary>
  internal class P1210
  {
    public class Solution
    {
      enum Alignment
      {
        Vertical,
        Horizontal
      }

      class Key : IEquatable<Key>
      {
        public (int i, int j) Point { get; }
        public Alignment Align { get; }

        public Key((int, int) point, Alignment align)
        {
          Point = point;
          Align = align;
        }

        public override string ToString() => $"{Point} {Align}";

        public override bool Equals(object obj) => ((Key)obj).Point == Point && ((Key)obj).Align == Align;

        public override int GetHashCode() => HashCode.Combine(Point, Align);

        public bool Equals(Key other) => other.Point == Point && other.Align == Align;
      }

      class QueueItem
      {
        public Key Key { get; }
        public int Path { get; }

        public QueueItem(Key key, int path)
        {
          Key = key;
          Path = path;
        }
      }

      public int MinimumMoves(int[][] grid)
      {
        var dp = new Dictionary<Key, int>();

        var queue = new Queue<QueueItem>();
        queue.Enqueue(new QueueItem(key: new Key((0, 0), Alignment.Horizontal), path: 0));

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();

          if (item.Key.Align == Alignment.Horizontal && item.Key.Point == (grid.Length - 1, grid[0].Length - 2))
            return item.Path;

          if (dp.ContainsKey(item.Key)/* && dp[item.Key] <= item.Path*/)
            continue;

          dp[item.Key] = item.Path;

          var ways = new List<QueueItem>();

          // vertical down or right
          if (item.Key.Align == Alignment.Vertical)
          {
            if (item.Key.Point.i + 2 < grid.Length &&
                grid[item.Key.Point.i + 2][item.Key.Point.j] == 0)
            {
              ways.Add(new QueueItem(
                new Key((item.Key.Point.i + 1, item.Key.Point.j), Alignment.Vertical),
                item.Path + 1));
            }

            if (item.Key.Point.i + 1 < grid.Length &&
                item.Key.Point.j + 1 < grid[0].Length &&
                grid[item.Key.Point.i][item.Key.Point.j + 1] == 0 &&
                grid[item.Key.Point.i + 1][item.Key.Point.j + 1] == 0)
            {
              ways.Add(new QueueItem(
                new Key((item.Key.Point.i, item.Key.Point.j + 1), Alignment.Vertical),
                item.Path + 1));
            }
          }

          // horizontal down or right
          if (item.Key.Align == Alignment.Horizontal)
          {
            if (item.Key.Point.j + 2 < grid[0].Length &&
                grid[item.Key.Point.i][item.Key.Point.j + 2] == 0)
            {
              ways.Add(new QueueItem(
                new Key((item.Key.Point.i, item.Key.Point.j + 1), Alignment.Horizontal),
                item.Path + 1));
            }

            if (item.Key.Point.i + 1 < grid.Length &&
                item.Key.Point.j + 1 < grid[0].Length &&
                grid[item.Key.Point.i + 1][item.Key.Point.j] == 0 &&
                grid[item.Key.Point.i + 1][item.Key.Point.j + 1] == 0)
            {
              ways.Add(new QueueItem(
                new Key((item.Key.Point.i + 1, item.Key.Point.j), Alignment.Horizontal),
                item.Path + 1));
            }
          }

          // rotate to vertical
          if (item.Key.Align == Alignment.Horizontal)
          {
            if (item.Key.Point.i + 1 < grid.Length &&
                grid[item.Key.Point.i + 1][item.Key.Point.j] == 0 &&
                grid[item.Key.Point.i + 1][item.Key.Point.j + 1] == 0)
            {
              ways.Add(new QueueItem(
                new Key((item.Key.Point.i, item.Key.Point.j), Alignment.Vertical),
                item.Path + 1));
            }
          }

          // rotate to horizontal
          if (item.Key.Align == Alignment.Vertical)
          {
            if (item.Key.Point.j + 1 < grid[0].Length &&
                grid[item.Key.Point.i][item.Key.Point.j + 1] == 0 &&
                grid[item.Key.Point.i + 1][item.Key.Point.j + 1] == 0)
            {
              ways.Add(new QueueItem(
                new Key((item.Key.Point.i, item.Key.Point.j), Alignment.Horizontal),
                item.Path + 1));
            }
          }

          foreach (var way in ways)
            queue.Enqueue(way);
        }

        return -1;
      }
    }
  }
}
