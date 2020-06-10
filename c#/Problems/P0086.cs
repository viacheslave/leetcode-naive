using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/partition-list/
	///		Submission: https://leetcode.com/submissions/detail/242298228/
	/// </summary>
	internal class P0086
	{
		public ListNode Partition(ListNode head, int x)
		{
			if (head == null)
				return null;

			var root = head;
			ListNode greater = null;

			var current = head;
			var stack = new Stack<ListNode>();

			while (current != null)
			{
				if (greater == null && current.val >= x)
				{
					greater = current;

					stack.Push(current);
					current = current.next;
					continue;
				}

				if (current.val < x)
				{
					if (greater == null)
					{
						stack.Push(current);
						current = current.next;
						continue;
					}

					var temp = current;
					var tempNext = current.next;

					while (temp.next != greater)
					{
						var prev = stack.Pop();
						prev.next = current.next;
						current.next = prev;

						if (stack.Count > 0)
						{
							stack.Peek().next = current;
						}
						else
						{
							root = current;
						}
					}

					while (current != tempNext)
					{
						stack.Push(current);
						current = current.next;
					}

					continue;
				}

				stack.Push(current);
				current = current.next;
			}

			return root;
		}
	}
}
