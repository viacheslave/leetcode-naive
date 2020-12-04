using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/richest-customer-wealth/
  ///    Submission: https://leetcode.com/submissions/detail/427137173/
  /// </summary>
  internal class P1672
  {
    public class Solution
    {
      public int MaximumWealth(int[][] accounts)
      {
        return accounts.Max(a => a.Sum());
      }
    }
  }
}
