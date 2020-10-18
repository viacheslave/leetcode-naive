using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-atoms/
  ///    Submission: https://leetcode.com/submissions/detail/239763447/
  /// </summary>
  internal class P0726
  {
    public class Solution
    {
      public string CountOfAtoms(string formula)
      {
        var st = new Stack<Dictionary<string, int>>();

        var current = new Dictionary<string, int>();
        string lastElement = null;

        for (int i = 0; i < formula.Length; i++)
        {
          if (formula[i] == '(')
          {
            st.Push(current);

            current = new Dictionary<string, int>();
            continue;
          }

          if (formula[i] == ')')
          {
            var countStr = GetCount(formula, i + 1);
            var count = countStr == string.Empty ? 1 : int.Parse(countStr);

            var stacked = st.Pop();
            current = Merge(stacked, current, count);

            i += countStr.Length;
            continue;
          }

          if (char.IsDigit(formula[i]))
          {
            var countStr = GetCount(formula, i);
            var count = countStr == string.Empty ? 0 : int.Parse(countStr);
            current[lastElement] += count - 1;

            i += countStr.Length - 1;
            continue;
          }

          if (char.IsLetter(formula[i]))
          {
            var element = GetElement(formula, i);
            if (!current.ContainsKey(element))
              current[element] = 0;

            current[element]++;

            lastElement = element;
            i += element.Length - 1;
          }
        }

        return string.Join("", current.OrderBy(_ => _.Key).Select(_ =>
        {
          var valueStr = _.Value == 1 ? string.Empty : _.Value.ToString();
          return $"{_.Key}{valueStr}";
        }));
      }

      private string GetElement(string formula, int i)
      {
        var ci = i;
        while (ci + 1 < formula.Length && char.IsLetter(formula[ci + 1]) && char.IsLower(formula[ci + 1]))
          ci++;

        return formula.Substring(i, ci - i + 1);
      }

      private string GetCount(string formula, int i)
      {
        var ci = i;
        while (ci + 1 < formula.Length && char.IsDigit(formula[ci + 1]))
          ci++;

        return formula.Substring(i, ci - i + 1);
      }

      private Dictionary<string, int> Merge(Dictionary<string, int> stacked, Dictionary<string, int> current, int v)
      {
        foreach (var c in current)
        {
          if (!stacked.ContainsKey(c.Key))
            stacked[c.Key] = 0;

          stacked[c.Key] += current[c.Key] * v;
        }

        return stacked;
      }
    }
  }
}
