using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-digit-one/
  ///    Submission: https://leetcode.com/submissions/detail/433678823/
  /// </summary>
  internal class P0233
  {
    public class Solution
    {
      public int CountDigitOne(int n)
      {
        return GetCount(n, n.ToString().Length - 1);
      }

      private int GetCount(int n, int pos)
      {
        if (pos == 0)
          return n >= 1 ? 1 : 0;

        var pow = (int)Math.Pow(10, pos);

        var digit = n / pow;
        if (digit == 0)
          return GetCount(n, pos - 1);

        // the idea is to split the number into parts:
        // - number that is all nines before the first number with current digit count: for 123 it is 99, i.e.
        // - number that is the current number mod 10 pow digit: for 123 it is 23

        var nines = pow - 1;
        var remainder = n - pow * digit;

        var countInNines = GetCount(nines, pos - 1);
        var countInRemainder = GetCount(remainder, pos - 1);

        return countInNines * digit
          + countInRemainder
          + ((digit > 1) ? pow : (remainder + 1)); // if current digits is '1' or not.
      }
    }
  }
}
