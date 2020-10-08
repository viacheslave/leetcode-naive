using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/stone-game-v/
	///		Submission: https://leetcode.com/submissions/detail/406140055/
	/// </summary>
	internal class P1563
	{
    private int _sum;
    private int[] _prefix;
    private int[] _suffix;

    public int StoneGameV(int[] stoneValue)
    {
      if (stoneValue.Length == 1)
        return 0;

      _sum = stoneValue.Sum();
      _prefix = new int[stoneValue.Length];
      _suffix = new int[stoneValue.Length];

      CalcPrefix(stoneValue);
      CalcSuffix(stoneValue);

      var dp = new int[500, 500];
      var ans = GetDP(dp, 0, stoneValue.Length - 1, stoneValue);

      return ans;
    }

    private void CalcSuffix(int[] stoneValue)
    {
      for (var i = stoneValue.Length - 1; i >= 0; --i)
      {
        if (i == stoneValue.Length - 1)
        {
          _suffix[i] = stoneValue[i];
          continue;
        }

        _suffix[i] = _suffix[i + 1] + stoneValue[i];
      }
    }

    private void CalcPrefix(int[] stoneValue)
    {
      for (var i = 0; i < stoneValue.Length; ++i)
      {
        if (i == 0)
        {
          _prefix[i] = stoneValue[i];
          continue;
        }

        _prefix[i] = _prefix[i - 1] + stoneValue[i];
      }
    }

    private int GetDP(int[,] dp, int start, int end, int[] stoneValue)
    {
      if (dp[start, end] != 0)
        return dp[start, end];

      if (start == end)
        return stoneValue[start];

      var max = 0;

      for (var mid = start; mid < end; mid++)
      {
        var leftSum = _suffix[start] + _prefix[mid] - _sum;
        var rightSum = _suffix[mid + 1] + _prefix[end] - _sum;

        if (leftSum < rightSum)
        {
          var pLeft = GetDP(dp, start, mid, stoneValue) +
              (start != mid ? leftSum : 0);

          max = Math.Max(max, pLeft);
        }
        else if (leftSum > rightSum)
        {
          var pRight = GetDP(dp, mid + 1, end, stoneValue) +
              (mid + 1 != end ? rightSum : 0);

          max = Math.Max(max, pRight);
        }
        else
        {
          var profitLeft = GetDP(dp, start, mid, stoneValue) +
              (start != mid ? leftSum : 0);

          var profitRight = GetDP(dp, mid + 1, end, stoneValue) +
              (mid + 1 != end ? rightSum : 0);

          max = Math.Max(max, Math.Max(profitLeft, profitRight));
        }
      }

      dp[start, end] = max;
      return max;
    }
  }
}
