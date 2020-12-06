using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/goal-parser-interpretation/
  ///    Submission: https://leetcode.com/submissions/detail/427771126/
  /// </summary>
  internal class P1678
  {
    public class Solution
    {
      public string Interpret(string command)
      {
        var sb = new StringBuilder();
        var index = 0;

        while (index < command.Length)
        {
          if (command[index] == 'G')
          {
            sb.Append("G");
            index++;
            continue;
          }

          if (command.Substring(index, 2) == "()")
          {
            sb.Append("o");
            index += 2;
            continue;
          }

          sb.Append("al");
          index += 4;
        }

        return sb.ToString();
      }
    }
  }
}
