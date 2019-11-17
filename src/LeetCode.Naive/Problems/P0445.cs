using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/add-two-numbers-ii/
	///		Submission: https://leetcode.com/submissions/detail/235228372/
	/// </summary>
	internal class P0445
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			var s1 = GetStack(l1);
			var s2 = GetStack(l2);

			ListNode current = null;

			var carry = 0;
			while (s1.Count > 0 || s2.Count > 0)
			{
				var val1 = s1.Count > 0 ? s1.Pop() : 0;
				var val2 = s2.Count > 0 ? s2.Pop() : 0;

				var node = new ListNode(val1 + val2 + carry);
				if (node.val >= 10)
				{
					node.val = node.val - 10;
					carry = 1;
				}
				else
				{
					carry = 0;
				}

				node.next = current;
				current = node;
			}

			if (carry == 1)
			{
				var node = new ListNode(carry);
				node.next = current;
				current = node;
			}

			return current;
		}

		Stack<int> GetStack(ListNode node)
		{
			var s = new Stack<int>();

			var current = node;
			if (current == null)
				return s;

			s.Push(current.val);

			while (current.next != null)
			{
				s.Push(current.next.val);
				current = current.next;
			}

			return s;
		}
	}
}
