using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/evaluate-the-bracket-pairs-of-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/476424294/
  /// </summary>
  internal class P1807
  {
    public class Solution
    {
      public string Evaluate(string s, IList<IList<string>> knowledge)
      {
        var open = new List<int>();
        var closed = new List<int>();

        for (var i = 0; i < s.Length; ++i)
        {
          if (s[i] == '(') open.Add(i);
          if (s[i] == ')') closed.Add(i);
        }

        var sb = new StringBuilder(s);
        var map = knowledge.ToDictionary(x => x[0], x => x[1]);

        for (var i = open.Count - 1; i >= 0; i--)
        {
          var value = s.Substring(open[i] + 1, closed[i] - open[i] - 1);
          sb.Remove(open[i], closed[i] - open[i] + 1);

          if (map.ContainsKey(value))
          {
            sb.Insert(open[i], map[value]);
          }
          else
          {
            sb.Insert(open[i], "?");
          }
        }

        return sb.ToString();
      }
    }
  }
}
