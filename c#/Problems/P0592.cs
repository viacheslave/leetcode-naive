using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/fraction-addition-and-subtraction/
  ///    Submission: https://leetcode.com/submissions/detail/290239544/
  /// </summary>
  internal class P0592
  {
    public class Solution
    {
      public class Fraction
      {
        public int Top;
        public int Bottom;
      }

      public string FractionAddition(string expression)
      {
        if (char.IsDigit(expression[0]))
          expression = "+" + expression;

        var fractions = new List<Fraction>();
        ParseFractions(expression, fractions);

        var res = NormalizeFractions(fractions);
        ReduceResult(res);

        return $"{res.Top}/{res.Bottom}";
      }

      private void ReduceResult(Fraction res)
      {
        if (res.Top == 0)
        {
          res.Bottom = 1;
          return;
        }

        var isnegative = res.Top < 0;
        res.Top = Math.Abs(res.Top);

        var v = Math.Max(res.Top, res.Bottom);
        for (var divisor = 2; divisor <= Math.Min(res.Top, res.Bottom); divisor++)
        {
          while (res.Top % divisor == 0 && res.Bottom % divisor == 0)
          {
            res.Top /= divisor;
            res.Bottom /= divisor;
          }
        }

        if (isnegative)
          res.Top = -res.Top;
      }

      private static Fraction NormalizeFractions(List<Fraction> fractions)
      {
        var bottoms = fractions.Select(v => v.Bottom).Distinct();
        if (bottoms.Count() > 1)
        {
          var commonBottom = 1;
          foreach (var b in bottoms)
          {
            commonBottom *= b;
          }
          foreach (var fraction in fractions)
          {
            fraction.Top *= (commonBottom / fraction.Bottom);
            fraction.Bottom = commonBottom;
          }

          return new Fraction { Top = fractions.Sum(f => f.Top), Bottom = commonBottom };
        }
        return new Fraction { Top = fractions.Sum(f => f.Top), Bottom = fractions[0].Bottom };
      }

      private static void ParseFractions(string expression, List<Fraction> fractions)
      {
        var start = 0;
        for (var index = 1; index < expression.Length; index++)
        {
          if (expression[index] == '+' || expression[index] == '-')
          {
            var fraction = new Fraction();
            var part = expression.Substring(start, index - start);
            var parts = part.Split("/");

            fraction.Top = int.Parse(parts[0]);
            fraction.Bottom = int.Parse(parts[1]);
            fractions.Add(fraction);

            start = index;
          }
        }

        var p = expression.Substring(start, expression.Length - start);
        var ps = p.Split("/");

        var f = new Fraction();
        f.Top = int.Parse(ps[0]);
        f.Bottom = int.Parse(ps[1]);
        fractions.Add(f);
      }
    }
  }
}
