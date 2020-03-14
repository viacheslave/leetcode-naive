using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reverse-linked-list/
	///		Submission: https://leetcode.com/submissions/detail/226737224/
	/// </summary>
	internal class P0206
	{
		ListNode headNew = null;

		public ListNode ReverseList(ListNode head)
		{
			if (head == null)
				return head;

			var node = GetNext(head);
			node.next = null;
			return headNew;
		}

		private ListNode GetNext(ListNode node)
		{
			if (node.next == null)
			{
				headNew = node;
				return headNew;
			}

			var nextNode = GetNext(node.next);
			nextNode.next = node;
			return node;
		}
	}
}
