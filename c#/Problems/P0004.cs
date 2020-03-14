using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/add-two-numbers/
	///		Submission: https://leetcode.com/submissions/detail/223539591/
	/// </summary>
	internal class P0004
	{
		//Definition for singly-linked list.
		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}

		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			var left = l1;
			var right = l2;

			var currentNode = new ListNode(0);
			var head = currentNode;

			do
			{
				var newValue = (left == null ? 0 : left.val) + (right == null ? 0 : right.val);

				var newNode = new ListNode(newValue);

				if (left != null)
					left = left.next;

				if (right != null)
					right = right.next;

				if (currentNode.next == null)
					currentNode.next = newNode;
				else
					currentNode.next = new ListNode(1 + newValue);

				if (currentNode.next.val >= 10)
				{
					currentNode.next.val = currentNode.next.val % 10;
					currentNode.next.next = new ListNode(1);
				}

				currentNode = currentNode.next;
			}
			while (left != null || right != null);

			return head.next;
		}
	}
}
