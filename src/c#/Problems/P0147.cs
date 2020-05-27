using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/insertion-sort-list/
	///		Submission: https://leetcode.com/submissions/detail/228397564/
	/// </summary>
	internal class P0147
	{
		public ListNode InsertionSortList(ListNode head)
		{
			if (head == null)
				return null;

			Stack<ListNode> stack = new Stack<ListNode>();
			var newHead = head;

			var current = head;

			while (current != null)
			{
				if (stack.Count == 0)
				{
					stack.Push(current);
					current = current.next;
					continue;
				}

				ListNode p = null;
				ListNode pp = null;

				if (stack.Count > 0)
					p = stack.Peek();

				while (p != null && current.val < p.val)
				{
					if (stack.Count > 0)
						p = stack.Pop();
					else p = null;

					if (stack.Count > 0)
						pp = stack.Peek();
					else pp = null;

					if (pp != null) pp.next = current;
					if (p != null) p.next = current.next;
					current.next = p;

					p = pp;

					if (stack.Count == 0 && p == null)
						newHead = current;
				}

				stack.Push(current);

				current = current.next;
			}
			return newHead;
		}
	}
}
