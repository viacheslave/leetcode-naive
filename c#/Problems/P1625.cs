using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///   Problem: https://leetcode.com/problems/lexicographically-smallest-string-after-applying-operations/
  ///   Submission: https://leetcode.com/submissions/detail/410346550/
  /// </summary>
  internal class P1625
  {
    public string FindLexSmallestString(string s, int a, int b)
    {
      var visited = new HashSet<string>();
      var queue = new Queue<string>();

      var ans = new string('9', s.Length);

      queue.Enqueue(s);

      while (queue.Count > 0)
      {
        var el = queue.Dequeue();

        if (visited.Contains(el))
          continue;

        visited.Add(el);

        if (string.Compare(el, ans) < 0)
          ans = el;

        var add = Inc(el, a);
        var rotate = Rotate(el, b);

        queue.Enqueue(add);
        queue.Enqueue(rotate);
      }


      return ans;
    }

    private string Rotate(string tmp, int b)
    {
      return tmp.Substring(tmp.Length - b) + tmp.Substring(0, tmp.Length - b);
    }

    private string Inc(string tmp, int a)
    {
      var sb = new StringBuilder(tmp);

      for (var i = 1; i < tmp.Length; i += 2)
        sb[i] = ((int.Parse(sb[i].ToString()) + a) % 10).ToString()[0];

      return sb.ToString();
    }
  }
}
