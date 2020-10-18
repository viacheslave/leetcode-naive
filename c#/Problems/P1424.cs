using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/diagonal-traverse-ii/
  ///    Submission: https://leetcode.com/submissions/detail/331981164/
  /// </summary>
  internal class P1424
  {
    public class Solution
    {
      public int[] FindDiagonalOrder(IList<IList<int>> nums)
      {
        var ans = new List<int>();

        var map = new SortedDictionary<int, List<(int row, int value)>>();

        for (var row = 0; row < nums.Count; row++)
        {
          for (var col = 0; col < nums[row].Count; col++)
          {
            var sum = row + col;
            if (!map.ContainsKey(sum)) map[sum] = new List<(int row, int value)>();

            map[sum].Add((row, nums[row][col]));
          }
        }

        foreach (var item in map)
        {
          ans.AddRange(item.Value.OrderByDescending(i => i.row).Select(i => i.value));
        }

        return ans.ToArray();
      }
    }
  }
}
