using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/closest-dessert-cost/
  ///    Submission: https://leetcode.com/submissions/detail/490928005/
  /// </summary>
  internal class P1774
  {
    public class Solution
    {
      public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target)
      {
        var bases = baseCosts.Distinct().ToArray();
        var toppings = new List<List<int>>();

        foreach (var toppingCost in toppingCosts)
        {
          var topping = new List<int>();
          topping.Add(0);
          topping.Add(toppingCost);
          topping.Add(toppingCost * 2);

          toppings.Add(topping.Distinct().ToList());
        }

        var ans = new List<int>();

        foreach (var b in bases)
        {
          var sum = b;
          ans.Add(sum);

          var topIndex = 0;
          Process(ans, sum, toppings, topIndex);
        }

        var cost = ans
          .Select(a => (value: a, diff: Math.Abs(a - target)))
          .GroupBy(s => s.diff)
          .Select(s => (s.Key, v: s.OrderBy(f => f).ToList()))
          .OrderBy(s => s.Key)
          .Select(s => s.v.First()).First().value;

        return cost;
      }

      private void Process(List<int> ans, int sum, List<List<int>> toppings, int topIndex)
      {
        var topping = toppings[topIndex];

        foreach (var value in topping)
        {
          var s = sum + value;
          ans.Add(s);

          if (topIndex + 1 < toppings.Count)
            Process(ans, s, toppings, topIndex + 1);
        }
      }
    }
  }
}
