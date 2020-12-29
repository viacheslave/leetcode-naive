using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/shortest-common-supersequence/
  ///    Submission: https://leetcode.com/submissions/detail/435965990/
  /// </summary>
  internal class P1092
  {
    public class Solution
    {
      public string ShortestCommonSupersequence(string str1, string str2)
      {
        var lcss = LCSS(str1, str2);
        var ans = new StringBuilder();

        int i1 = 0, i2 = 0;

        for (var i = 0; i < lcss.Length; i++)
        {
          var lch = lcss[i];

          // move positions in both strings 
          // closer to current character in LCSS
          while (str1[i1] != lch)
          {
            ans.Append(str1[i1]);
            i1++;
          }

          while (str2[i2] != lch)
          {
            ans.Append(str2[i2]);
            i2++;
          }

          ans.Append(lch);
          i1++; i2++;
        }

        // common part is processed by here
        // current positions may be not at the end of the strings
        // so we need to add missing characters

        while (i1 < str1.Length)
        {
          ans.Append(str1[i1]);
          i1++;
        }

        while (i2 < str2.Length)
        {
          ans.Append(str2[i2]);
          i2++;
        }


        return ans.ToString();
      }

      public string LCSS(string str1, string str2)
      {
        var dp = new string[str1.Length + 1, str2.Length + 1];

        for (var i = 0; i <= str1.Length; i++)
          dp[i, 0] = string.Empty;

        for (var j = 0; j <= str2.Length; j++)
          dp[0, j] = string.Empty;

        for (var i = 0; i < str1.Length; i++)
          for (var j = 0; j < str2.Length; j++)
            dp[i + 1, j + 1] = str1[i] == str2[j]
                ? dp[i, j] + str1[i]
                : dp[i + 1, j].Length > dp[i, j + 1].Length
                  ? dp[i + 1, j]
                  : dp[i, j + 1];

        return dp[str1.Length, str2.Length];
      }
    }
  }
}
