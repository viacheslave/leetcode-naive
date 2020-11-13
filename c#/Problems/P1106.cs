using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/parsing-a-boolean-expression/
  ///    Submission: https://leetcode.com/submissions/detail/419973463/
  /// </summary>
  internal class P1106
  {
    public class Solution
    {
      public bool ParseBoolExpr(string expression)
      {
        if (expression == "t")
          return true;

        if (expression == "f")
          return false;

        if (expression[0] == '!')
          return ParseNot(1, expression).value;

        if (expression[0] == '&')
          return ParseAnd(1, expression).value;

        else return ParseOr(1, expression).value;
      }

      private (bool value, int lastpos) ParseNot(int start, string expression)
      {
        var parts = GetParts(start, expression);
        return (!parts.parts[0], parts.lastpos);
      }

      private (bool value, int lastpos) ParseAnd(int start, string expression)
      {
        var parts = GetParts(start, expression);
        return (parts.parts.Aggregate(true, (a, b) => a & b), parts.lastpos);
      }

      private (bool value, int lastpos) ParseOr(int start, string expression)
      {
        var parts = GetParts(start, expression);
        return (parts.parts.Aggregate(false, (a, b) => a | b), parts.lastpos);
      }

      private (List<bool> parts, int lastpos) GetParts(int start, string expression)
      {
        var parts = new List<bool>();

        while (expression[start] != ')')
        {
          switch (expression[start + 1])
          {
            case 't':
              parts.Add(true);
              start += 2;
              break;
            case 'f':
              parts.Add(false);
              start += 2;
              break;
            case '!':
              var not = ParseNot(start + 2, expression);
              parts.Add(not.value);
              start = not.lastpos;
              break;
            case '&':
              var and = ParseAnd(start + 2, expression);
              parts.Add(and.value);
              start = and.lastpos;
              break;
            case '|':
              var or = ParseOr(start + 2, expression);
              parts.Add(or.value);
              start = or.lastpos;
              break;
          }
        }

        return (parts, start + 1);
      }
    }
  }
}
