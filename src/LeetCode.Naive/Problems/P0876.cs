using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/middle-of-the-linked-list/
	///		Submission: https://leetcode.com/submissions/detail/227376532/
	/// </summary>
	internal class P0876
	{
		public ListNode MiddleNode(ListNode head)
		{
			if (head == null)
				return head;

			var current = head;
			var middle = current;

			while (current.next != null && current.next.next != null)
			{
				middle = middle.next;
				current = current.next.next;
			}

			if (current.next != null && current.next.next == null)
				middle = middle.next;

			return middle;
		}
	}
}
