using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reorder-list/
	///		Submission: https://leetcode.com/submissions/detail/230933713/
	/// </summary>
	internal class P0143
	{
		public void ReorderList(ListNode head)
		{
			if (head == null)
				return;

			Stack<ListNode> s = new Stack<ListNode>();

			var current = head;
			while (current != null)
			{
				s.Push(current);
				current = current.next;
			}

			current = head;
			var topStack = s.Pop();

			while (current != topStack)
			{
				if (current.next == topStack)
					break;

				var tmpNext = current.next;
				current.next = topStack;
				topStack.next = tmpNext;

				current = tmpNext;
				topStack = s.Pop();
			}

			topStack.next = null;
		}
	}
}
