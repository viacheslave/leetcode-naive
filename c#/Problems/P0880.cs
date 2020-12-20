using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/decoded-string-at-index/
  ///    Submission: https://leetcode.com/submissions/detail/432566885/
  /// </summary>
  internal class P0880
  {
    public class Solution
    {
      public string DecodeAtIndex(string S, int K)
      {
        var stack = new Stack<(char ch, long length)>();
        var index = 0;
        var length = 0L;

        while (index < S.Length)
        {
          length = char.IsLetter(S[index])
            ? length + 1
            : length * int.Parse(S[index].ToString());

          // for every index, save running length
          stack.Push((S[index], length));

          if (K <= length)
            break;

          index++;
        }

        long k = K;

        // unwind stack
        // if stack item is letter - just pop it and check if searched position equals to running length
        // if stack item is digit - calculate length of the part that's repeated, adjust searched position with the running length part
        while (stack.Count > 0)
        {
          var item = stack.Pop();

          if (char.IsLetter(item.ch))
          {
            if (k == item.length)
              return item.ch.ToString();
          }
          else
          {
            var repeats = int.Parse(item.ch.ToString());
            var partLength = item.length / repeats;

            while (k > partLength)
              k -= partLength;
          }
        }

        // never happens
        return "";
      }
    }
  }
}
