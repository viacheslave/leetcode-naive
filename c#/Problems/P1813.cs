using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sentence-similarity-iii/
  ///    Submission: https://leetcode.com/submissions/detail/476373927/
  /// </summary>
  internal class P1813
  {
    public class Solution
    {
      public bool AreSentencesSimilar(string sentence1, string sentence2)
      {
        if (sentence1 == sentence2)
          return true;

        var lensen = sentence1.Length > sentence2.Length ? sentence1 : sentence2;

        var left = 0;
        var right = 0;

        for (var i = 0; i < Math.Min(sentence1.Length, sentence2.Length); ++i)
        {
          if (sentence1[i] == sentence2[i])
            left = i + 1;
          else
            break;
        }

        for (var i = 1; i <= Math.Min(sentence1.Length, sentence2.Length); ++i)
        {
          if (sentence1[^i] == sentence2[^i])
            right = i;
          else
            break;
        }

        var min = Math.Min(sentence1.Length, sentence2.Length);

        if (left > 0 && right > 0)
        {
          if (sentence1[left - 1] != ' ' || sentence1[^right] != ' ')
            return false;

          return left + right - 1 == min;
        }

        if (right == 0)
          return min == left && lensen[left] == ' ';

        if (left == 0)
          return min == right && lensen[^(right + 1)] == ' ';

        return false;
      }
    }
  }
}
