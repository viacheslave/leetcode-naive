using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-nth-node-from-end-of-list/
	///		Submission: https://leetcode.com/submissions/detail/228258754/
	/// </summary>
	internal class P0019
	{
		public ListNode RemoveNthFromEnd(ListNode head, int n)
		{
			ListNode current = head;
			ListNode prev = null;

			for (int i = 0; ; i++)
			{
				if (i - n == 0)
					prev = head;

				if (current.next != null)
				{
					current = current.next;
					if (prev != null)
						prev = prev.next;

					continue;
				}
				break;
			}

			if (prev == null)
				return head.next;

			prev.next = prev.next.next;

			return head;
		}
	}
}
