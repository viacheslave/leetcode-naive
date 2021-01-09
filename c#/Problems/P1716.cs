namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/calculate-money-in-leetcode-bank/
  ///    Submission: https://leetcode.com/submissions/detail/440756803/
  /// </summary>
  internal class P1716
  {
    public class Solution
    {
      public int TotalMoney(int n)
      {
        var ans = 0;
        var current = 6;

        for (var i = 0; i < n; i++)
        {
          if (i % 7 == 0)
            current -= 5;
          else
            current++;

          ans += current;
        }

        return ans;
      }
    }
  }
}
