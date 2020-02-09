using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/linked-list-random-node/
	///		Submission: https://leetcode.com/submissions/detail/235379891/
	/// </summary>
	internal class P0382
	{
		/** @param head The linked list's head.
        Note that the head is guaranteed to be not null, so it contains at least one node. */

		public int _length = 1;

		public Random _rnd = new Random((int)DateTime.Now.Ticks);

		public ListNode _head;

		public P0382(ListNode head)
		{
			if (head == null)
				return;

			_head = head;

			var current = head;
			while (current.next != null)
			{
				_length++;
				current = current.next;
			}
		}

		/** Returns a random node's value. */
		public int GetRandom()
		{
			var index = _rnd.Next(_length);

			var current = _head;
			var i = 0;

			while (i < index)
			{
				i++;
				current = current.next;
			}

			return current.val;
		}
	}
}
