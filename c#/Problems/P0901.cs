using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/online-stock-span/
  ///    Submission: https://leetcode.com/submissions/detail/427436619/
  /// </summary>
  internal class P0901
  {
    public class StockSpanner
    {
      private readonly Stack<(int price, int length)> stack = new Stack<(int, int)>();

      public StockSpanner()
      {
      }

      public int Next(int price)
      {
        var prev = 0;
        while (stack.Count > 0 && stack.Peek().price <= price)
        {
          var item = stack.Pop();
          prev += item.length;
        }

        stack.Push((price, prev + 1));
        return prev + 1;
      }
    }

    /**
     * Your StockSpanner object will be instantiated and called as such:
     * StockSpanner obj = new StockSpanner();
     * int param_1 = obj.Next(price);
     */
  }
}
