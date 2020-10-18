using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/implement-stack-using-queues/
  ///    Submission: https://leetcode.com/submissions/detail/230407459/
  /// </summary>
  internal class P0225
  {
    public class Solution
    {
      public class MyStack
      {

        Queue<int> s1 = new Queue<int>();
        Queue<int> s2 = new Queue<int>();
        Queue<int> stemp = new Queue<int>();

        /** Initialize your data structure here. */
        public MyStack()
        {

        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
          if (s2.Count > 0)
          {
            var t = s2.Dequeue();
            s1.Enqueue(t);
          }

          s2.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
          if (s2.Count == 0)
            Move();

          return s2.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
          if (s2.Count == 0)
            Move();

          return s2.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
          return s1.Count == 0 && s2.Count == 0;
        }

        private void Move()
        {
          while (s1.Count > 0)
          {
            var el = s1.Dequeue();
            stemp.Enqueue(el);
          }

          while (stemp.Count > 0)
          {
            var el = stemp.Dequeue();

            if (s2.Count > 0)
            {
              var t = s2.Dequeue();
              s1.Enqueue(t);
            }

            s2.Enqueue(el);
          }
        }
      }
    }
  }
}
