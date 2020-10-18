using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-circular-deque/
  ///    Submission: https://leetcode.com/submissions/detail/240188010/
  /// </summary>
  internal class P0641
  {
    public class MyCircularDeque
    {
      private readonly int _k;
      private readonly LinkedList<int> _list;

      /** Initialize your data structure here. Set the size of the deque to be k. */
      public MyCircularDeque(int k)
      {
        _k = k;
        _list = new LinkedList<int>();
      }

      /** Adds an item at the front of Deque. Return true if the operation is successful. */
      public bool InsertFront(int value)
      {
        if (IsFull()) return false;
        _list.AddFirst(value);
        return true;
      }

      /** Adds an item at the rear of Deque. Return true if the operation is successful. */
      public bool InsertLast(int value)
      {
        if (IsFull()) return false;
        _list.AddLast(value);
        return true;
      }

      /** Deletes an item from the front of Deque. Return true if the operation is successful. */
      public bool DeleteFront()
      {
        if (IsEmpty()) return false;
        _list.RemoveFirst();
        return true;
      }

      /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
      public bool DeleteLast()
      {
        if (IsEmpty()) return false;
        _list.RemoveLast();
        return true;
      }

      /** Get the front item from the deque. */
      public int GetFront()
      {
        if (IsEmpty()) return -1;
        return _list.First.Value;
      }

      /** Get the last item from the deque. */
      public int GetRear()
      {
        if (IsEmpty()) return -1;
        return _list.Last.Value;
      }

      /** Checks whether the circular deque is empty or not. */
      public bool IsEmpty()
      {
        return _list.Count == 0;
      }

      /** Checks whether the circular deque is full or not. */
      public bool IsFull()
      {
        return _list.Count == _k;
      }
    }
  }
}
