using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/implement-queue-using-stacks/
	///		Submission: https://leetcode.com/submissions/detail/229913427/
	/// </summary>
	internal class P0232
	{
		public class MyQueue
		{
			Stack<int> sp = new Stack<int>();
			Stack<int> ss = new Stack<int>();


			/** Initialize your data structure here. */
			public MyQueue()
			{

			}

			/** Push element x to the back of queue. */
			public void Push(int x)
			{
				sp.Push(x);
			}

			/** Removes the element from in front of queue and returns that element. */
			public int Pop()
			{
				Move();

				return ss.Pop();
			}

			/** Get the front element. */
			public int Peek()
			{
				Move();

				return ss.Peek();
			}

			/** Returns whether the queue is empty. */
			public bool Empty()
			{
				return sp.Count == 0 && ss.Count == 0;
			}

			private void Move()
			{
				if (ss.Count > 0)
					return;

				while (sp.Count > 0)
				{
					var el = sp.Pop();
					ss.Push(el);
				}
			}
		}
	}
}
