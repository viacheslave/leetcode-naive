using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-profit-of-operating-a-centennial-wheel/
  ///    Submission: https://leetcode.com/submissions/detail/412570560/
  /// </summary>
  internal class P1599
  {
    public class Solution
    {
      public int MinOperationsMaxProfit(int[] customers, int boardingCost, int runningCost)
      {
        var customersStack = new Stack<int>();

        for (int i = customers.Length - 1; i >= 0; i--)
          customersStack.Push(customers[i]);

        var ans = 0;
        var profit = 0;
        var maxProfit = int.MinValue;
        var people = 0;
        var rotates = 0;

        while (true)
        {
          if (customersStack.Count == 0 && people == 0)
            break;

          if (customersStack.Count > 0)
          {
            var pop = customersStack.Pop();
            people += pop;
          }

          var board = 0;

          if (people >= 4)
          {
            // full 
            board = 4;
            people -= 4;
          }
          else
          {
            board = people;
            people = 0;
          }

          profit += boardingCost * board - runningCost;
          rotates++;

          if (profit > maxProfit)
          {
            maxProfit = profit;
            ans = rotates;
          }
        }

        return maxProfit <= 0 ? -1 : ans;
      }
    }
  }
}
