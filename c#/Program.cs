using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LeetCode.Naive
{
  class Program
  {
    static void Main(string[] args)
    {
      var root = new TreeNode(3);
      root.left = new TreeNode((4));
      root.right = new TreeNode(5);

      root.left.left = new TreeNode(1);
      root.left.right = new TreeNode(3);

      root.right.right = new TreeNode(1);

      var res = new Solution().RankTeams(new[] { "AXYB", "AYXB", "AXYB", "AYXB" });
      //var res2 = new Solution().MaxSubarraySumCircular(new int[] { 5,4,3,2,1 });
    }
  }
  /*
  public class Solution
  {
    public int MaxCoins(int[] nums)
    {
      var mxn = 3;
      var dp = new int[mxn, mxn];

      for (var i = 0; i < mxn; i++)
        for (var j = 0; j < mxn; j++)
          dp[i, j] = -1;

      DP(nums, 0, nums.Length - 1, dp, 0, nums.Length - 1);

      var ans = dp[0, nums.Length - 1];
      return ans;
    }

    private int DP(int[] nums, int start, int end, int[,] dp, int left, int right)
    {
      if (dp[start, end] != -1)
        return dp[start, end];

      var value = 1;

      for (var mid = start; mid <= end; ++mid)
      {
        var current = nums[mid];

        if (mid > start)
          current *= nums[mid - 1];
        else if (mid == start && left < start && mid - 2 >= 0)
          current *= nums[mid - 2];

        if (mid < end)
          current *= nums[mid + 1];
        else if (mid == end && end < right && mid + 2 < nums.Length)
          current *= nums[mid + 2];

        if (mid < end)
          current += DP(nums, mid + 1, end, dp, start, end);

        if (start < mid)
          current += DP(nums, start, mid - 1, dp, start, end);
        
        value = Math.Max(value, current);
      }

      dp[start, end] = value;
      return value;
    }
  }*/

  public class Solution
  {
    public string RankTeams(string[] votes)
    {
      const int teams = 26;

      var ranks = new int[teams][];
      for (var i = 0; i < teams; i++)
        ranks[i] = new int[teams];


      foreach (var vote in votes)
      {
        for (var place = 0; place < vote.Length; place++)
        {
          var team = vote[place];
          ranks[team - 65][place]++;
        }
      }

      var ranksMap = ranks
        .Select((r, i) => (r, i))
        .Where(r => r.r.Any(v => v > 0))
        .ToDictionary(x => x.i, x => x.r);

      var ordered = ranksMap
        .Select((r, i) => (r, i))
        .OrderByDescending(x => x.r, new RanksComparer())
        .ToList();

      return string.Join("", ordered.Select(x => (char)(65 + x.r.Key)));
    }

    internal class RanksComparer : IComparer<KeyValuePair<int, int[]>>
    {
      public int Compare(KeyValuePair<int, int[]> x, KeyValuePair<int, int[]> y)
      {
        for (var i = 0; i < x.Value.Length; i++)
        {
          if (x.Value[i] < y.Value[i])
            return -1;
          if (x.Value[i] > y.Value[i])
            return 1;
        }

        return 1;
      }
    }
  }
}
