using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/design-circular-queue/
	///		Submission: https://leetcode.com/submissions/detail/240189485/
	/// </summary>
	internal class P0622
	{
		public class MyCircularQueue
		{
			private readonly int _k;
			private readonly LinkedList<int> _list;

			/** Initialize your data structure here. Set the size of the queue to be k. */
			public MyCircularQueue(int k)
			{
				_k = k;
				_list = new LinkedList<int>();
			}

			/** Insert an element into the circular queue. Return true if the operation is successful. */
			public bool EnQueue(int value)
			{
				if (IsFull()) return false;
				_list.AddLast(value);
				return true;
			}

			/** Delete an element from the circular queue. Return true if the operation is successful. */
			public bool DeQueue()
			{
				if (IsEmpty()) return false;
				_list.RemoveFirst();
				return true;
			}

			/** Get the front item from the queue. */
			public int Front()
			{
				if (IsEmpty()) return -1;
				return _list.First.Value;
			}

			/** Get the last item from the queue. */
			public int Rear()
			{
				if (IsEmpty()) return -1;
				return _list.Last.Value;
			}

			/** Checks whether the circular queue is empty or not. */
			public bool IsEmpty()
			{
				return _list.Count == 0;
			}

			/** Checks whether the circular queue is full or not. */
			public bool IsFull()
			{
				return _list.Count == _k;
			}
		}
	}
}
