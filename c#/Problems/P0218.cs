using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/the-skyline-problem/
  ///    Submission: https://leetcode.com/submissions/detail/425687831/
  /// </summary>
  internal class P0218
  {
    public class Solution
    {
      public IList<IList<int>> GetSkyline(int[][] buildings)
      {
        var ans = new List<IList<int>>();

        if (buildings.Length == 0)
          return ans;

        var walls = buildings
          .Select(b => (left: b[0], right: b[1], height: b[2]))
          .ToList();

        var skyline = GetSkyline(walls, 0, walls.Count - 1);
        if (skyline[^1].height != 0)
          skyline[^1] = (skyline[^1].left, 0);

        ans = skyline.Select(x => (IList<int>)new List<int>() { x.left, x.height }).ToList();
        return ans;
      }

      private IList<(int left, int height)> GetSkyline(
        List<(int left, int right, int height)> buildings,
        int from, int to)
      {
        if (from == to)
        {
          var ans = new List<(int, int)>();
          Add(ans, (buildings[from].left, buildings[from].height));
          Add(ans, (buildings[from].right, 0));

          return ans;
        }

        var mid = (from + to) / 2;

        var left = GetSkyline(buildings, from, mid);
        var right = GetSkyline(buildings, mid + 1, to);

        return Merge(left, right);
      }

      private IList<(int, int)> Merge(IList<(int left, int height)> left, IList<(int left, int height)> right)
      {
        var ans = new List<(int, int)>();

        var h1 = 0;
        var h2 = 0;
        var i = 0;
        var j = 0;

        while (i < left.Count && j < right.Count)
        {
          if (left[i].left < right[j].left)
          {
            h1 = left[i].height;
            Add(ans, (left[i].left, Math.Max(h1, h2)));
            i++;
          }
          else
          {
            h2 = right[j].height;
            Add(ans, (right[j].left, Math.Max(h1, h2)));
            j++;
          }
        }

        while (i < left.Count)
        {
          Add(ans, left[i]);
          i++;
        }

        while (j < right.Count)
        {
          Add(ans, right[j]);
          j++;
        }

        return ans;
      }

      private void Add(List<(int left, int height)> list, (int left, int height) item)
      {
        if (list.Count > 0 && list[^1].height == item.height)
          return;

        if (list.Count > 0 && list[^1].left == item.left)
        {
          list[^1] = (list[^1].left, Math.Max(list[^1].height, item.height));
          return;
        }

        list.Add(item);
      }
    }
  }
}
