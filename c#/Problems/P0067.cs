using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/add-binary/
  ///    Submission: https://leetcode.com/submissions/detail/227856913/
  /// </summary>
  internal class P0067
  {
    public class Solution
    {
      public string AddBinary(string a, string b)
      {
        var length = Math.Max(a.Length, b.Length);

        var sb = new StringBuilder();
        var carry = 0;

        for (var i = 0; i < length; i++)
        {
          int left = 0;
          int right = 0;

          if (a.Length - 1 - i >= 0)
            left = int.Parse(a[a.Length - 1 - i].ToString());

          if (b.Length - 1 - i >= 0)
            right = int.Parse(b[b.Length - 1 - i].ToString());

          var sum = left + right + carry;

          if (sum % 2 == 0)
          {
            sb.Insert(0, "0");
            carry = sum > 1 ? 1 : 0;
          }
          else
          {
            sb.Insert(0, "1");
            carry = sum > 2 ? 1 : 0;
          }
        }

        if (carry == 1)
          sb.Insert(0, "1");


        return sb.ToString();
      }
    }
  }
}
