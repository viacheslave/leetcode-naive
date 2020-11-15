using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-an-ordered-stream/
  ///    Submission: https://leetcode.com/submissions/detail/420467085/
  /// </summary>
  internal class P1656
  {
    public class OrderedStream
    {
      private int _ptr = 1;
      private readonly string[] _arr;

      public OrderedStream(int n)
      {
        _arr = new string[n + 1];
      }

      public IList<string> Insert(int id, string value)
      {
        var ans = new List<string>();

        _arr[id] = value;

        if (_ptr == id)
        {
          for (var i = id; i < _arr.Length; i++)
          {
            if (_arr[i] != null)
            {
              ans.Add(_arr[i]);
            }
            else
            {
              _ptr = i;
              break;
            }
          }
        }

        return ans;
      }
    }
  }
}
