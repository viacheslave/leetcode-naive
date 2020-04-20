using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/
	///		Submission: https://leetcode.com/submissions/detail/327762588/
	/// </summary>
	internal class P1415
	{
    public string GetHappyString(int n, int k)
    {
      var vars = new List<string>(n);
      var arr = new char[n];

      try
      {
        Inc(vars, arr, n, k, 0);
      }
      catch
      {
        return vars.Last();
      }

      return "";
    }

    private void Inc(List<string> vars, char[] arr, int n, int k, int index)
    {
      if (index == n)
      {
        vars.Add(new string(arr));
        if (vars.Count == k)
          throw new ApplicationException();

        return;
      }

      var digits = new char[] { 'a', 'b', 'c' };
      for (var i = 0; i < digits.Length; i++)
      {
        arr[index] = digits[i];
        if (index > 0)
        {
          if (digits[i] == arr[index - 1])
            continue;
        }

        Inc(vars, arr, n, k, index + 1);
      }
    }
  }
}
