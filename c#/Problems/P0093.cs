using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/restore-ip-addresses/
  ///    Submission: https://leetcode.com/submissions/detail/230476996/
  /// </summary>
  internal class P0093
  {
    public class Solution
    {
      public IList<string> RestoreIpAddresses(string s)
      {
        var sb = new StringBuilder();
        var hs = new HashSet<string>();

        Iter(s, 1, sb, hs, 0);

        return hs.ToList();
      }

      private void Iter(string s, int iteration, StringBuilder sb, HashSet<string> res, int start)
      {
        if (iteration == 5)
        {
          res.Add(sb.ToString().TrimEnd(new char[] { '.' }));
          return;
        }

        if (iteration == 4)
        {
          IterInner(s, iteration, sb, res, start, s.Length - start);
          return;
        }

        IterInner(s, iteration, sb, res, start, 1);
        IterInner(s, iteration, sb, res, start, 2);
        IterInner(s, iteration, sb, res, start, 3);
      }

      private void IterInner(string s, int iteration, StringBuilder sb, HashSet<string> res, int start, int take)
      {
        if (start < s.Length && (start + take) <= s.Length)
        {
          var takeOne = s.Substring(start, take);

          if (takeOne.Length <= 3 && int.Parse(takeOne) <= 255)
          {
            if (takeOne == "0" || takeOne == takeOne.TrimStart(new char[] { '0' }))
            {
              sb.Append(takeOne + ".");
              Iter(s, iteration + 1, sb, res, start + take);
              sb.Remove(sb.Length - 1 - take, take + 1);
            }
          }
        }
      }
    }
  }
}
