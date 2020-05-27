using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/swap-nodes-in-pairs/
	///		Submission: https://leetcode.com/submissions/detail/231073219/
	/// </summary>
	internal class P0024
	{
		public ListNode SwapPairs(ListNode head)
		{
			if (head == null)
				return head;

			if (head.next == null)
				return head;

			ListNode newhead = null;

			var current = head;
			ListNode prev = null;

			while (current != null)
			{
				if (current.next == null)
					break;

				var next = current.next;
				var nextnext = next.next;

				if (prev != null)
					prev.next = next;
				else
					newhead = next;

				next.next = current;
				current.next = nextnext;

				prev = current;
				current = nextnext;
			}

			return newhead;
		}
	}
}
