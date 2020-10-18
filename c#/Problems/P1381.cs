using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-a-stack-with-increment-operation/
  ///    Submission: https://leetcode.com/submissions/detail/312636531/
  /// </summary>
  internal class P1381
  {
    public class CustomStack
    {
      private readonly LinkedList<int> _list = new LinkedList<int>();
      private readonly int _maxSize;

      public CustomStack(int maxSize)
      {
        this._maxSize = maxSize;
        }

      public void Push(int x)
      {
        if (_list.Count == _maxSize)
          return;

        _list.AddLast(x);
        }

      public int Pop()
      {
        if (_list.Count == 0)
          return -1;

        var value = _list.Last.Value;
        _list.RemoveLast();

        return value;
        }

      public void Increment(int k, int val)
      {
        var current = _list.First;

        while (current != null && k > 0)
        {
          current.Value += val;
          k--;
          current = current.Next;
        }
      }
    }
  }
}
