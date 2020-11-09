using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sell-diminishing-valued-colored-balls/
  ///    Submission: https://leetcode.com/submissions/detail/418401310/
  /// </summary>
  internal class P1648
  {
    public class Solution
    {
      public int MaxProfit(int[] inventory, int orders)
      {
        var upper = inventory.Max();
        var lower = 1;

        var mod = (int)1e9 + 7;

        while (true)
        {
          if (upper - lower == 1)
          {
            var ordersUpper = GetOrders(upper, inventory);
            var missingOrders = orders - ordersUpper;

            var ans = GetAns(upper, inventory);
            ans += 1L * lower * (missingOrders - 0);

            return (int)(ans % mod);
          }

          var mid = (upper + lower) / 2;
          var ordersMid = GetOrders(mid, inventory);

          if (ordersMid < orders)
            upper = mid;
          else
            lower = mid;
        }
      }

      private long GetOrders(int point, int[] inventory)
      {
        long orders = 0;

        for (var i = 0; i < inventory.Length; i++)
          if (inventory[i] >= point)
            orders += inventory[i] - point + 1;

        return orders;
      }

      private long GetAns(int point, int[] inventory)
      {
        long ans = 0;

        for (var i = 0; i < inventory.Length; i++)
          if (inventory[i] >= point)
            ans += (1L * inventory[i] * (inventory[i] + 1) / 2) - (1L * (point - 1) * point / 2);

        return ans;
      }
    }
  }
}
