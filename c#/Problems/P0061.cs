using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/rotate-list/
	///		Submission: https://leetcode.com/submissions/detail/228462703/
	/// </summary>
	internal class P0061
	{
		public ListNode RotateRight(ListNode head, int k)
		{
			if (head == null || head.next == null)
				return head;

			var length = 0;
			var current = head;

			while (current != null)
			{
				length++;
				current = current.next;
			}

			ListNode prevNode = null;
			current = head;
			var tail = current;

			k = k % length;
			if (k == 0)
				return head;

			var index = 0;

			while (current != null)
			{
				if (length - k - 1 == index)
				{
					prevNode = current;
				}

				index++;

				if (current.next == null)
					tail = current;

				current = current.next;
			}


			var newhead = prevNode.next;
			prevNode.next = null;
			tail.next = head;

			return newhead;
		}
	}
}
