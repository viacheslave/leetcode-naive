using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/html-entity-parser/
  ///    Submission: https://leetcode.com/submissions/detail/323813451/
  /// </summary>
  internal class P1410
  {
    public class Solution
    {
      public string EntityParser(string text)
      {
        var map = new Dictionary<string, string>
        {
          ["&quot;"] = "\"",
          ["&apos;"] = "'",
          ["&amp;"] = "&",
          ["&lt;"] = "<",
          ["&gt;"] = ">",
          ["&frasl;"] = "/",
        };

        var sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
          if (text[i] != '&')
          {
            sb.Append(text[i]);
            continue;
          }

          var found = false;
          foreach (var key in map.Keys)
          {
            if (text.IndexOf(key, i) == i)
            {
              sb.Append(map[key]);
              i += key.Length - 1;
              found = true;
              break;
            }
          }

          if (!found)
            sb.Append('&');
        }
        return sb.ToString();
      }
    }
  }
}
