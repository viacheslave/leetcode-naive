using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
	///		Submission: https://leetcode.com/submissions/detail/384781836/
	/// </summary>
	internal class P1249
	{
    public string MinRemoveToMakeValid(string s)
    {
      var open = 0;
      var close = 0;
      var arr = s.ToCharArray().ToList();

      var removedLeft = new List<int>();
      var removedRight = new List<int>();

      for (var i = 0; i < arr.Count; i++)
      {
        if (arr[i] != '(' && arr[i] != ')')
          continue;

        if (arr[i] == '(')
          open++;

        if (arr[i] == ')')
        {
          if (open <= close)
            removedLeft.Add(i);
          else
            close++;
        }
      }

      for (var i = removedLeft.Count - 1; i >= 0; i--)
        arr.RemoveAt(removedLeft[i]);

      open = close = 0;

      for (var i = arr.Count - 1; i >= 0; i--)
      {
        if (arr[i] != '(' && arr[i] != ')')
          continue;

        if (arr[i] == ')')
          open++;

        if (arr[i] == '(')
        {
          if (open <= close)
            removedRight.Add(i);
          else
            close++;
        }
      }

      for (var i = 0; i < removedRight.Count; i++)
        arr.RemoveAt(removedRight[i]);

      return new string(arr.ToArray());
    }
  }
}
