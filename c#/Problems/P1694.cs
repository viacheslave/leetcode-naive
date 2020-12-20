using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reformat-phone-number/
  ///    Submission: https://leetcode.com/submissions/detail/432608456/
  /// </summary>
  internal class P1694
  {
    public class Solution
    {
      public string ReformatNumber(string number)
      {
        number = number.Replace(" ", "").Replace("-", "");

        var parts = new List<string>();
        var index = 0;

        while (index < number.Length)
        {
          if (index + 2 == number.Length)
          {
            parts.Add(number.Substring(index, 2));
            break;
          }

          if (index + 3 == number.Length)
          {
            parts.Add(number.Substring(index, 3));
            break;
          }

          if (index + 4 == number.Length)
          {
            parts.Add(number.Substring(index, 2));
            parts.Add(number.Substring(index + 2, 2));
            break;
          }

          parts.Add(number.Substring(index, 3));
          index += 3;
        }

        return string.Join("-", parts);
      }
    }
  }
}
