using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/flatten-a-multilevel-doubly-linked-list/
	///		Submission: https://leetcode.com/submissions/detail/242559363/
	/// </summary>
	internal class P0430
	{
		public NodePrev Flatten(NodePrev head)
		{
			if (head == null)
				return null;

			var result = new NodePrev() { val = head.val };

			var source = head;
			var target = result;

			Process(null, source, target);

			return result;
		}

		private NodePrev Process(NodePrev parent, NodePrev source, NodePrev target)
		{
			while (source != null)
			{
				if (source.child != null)
				{
					var sourceChild = source.child;
					var targetChild = new NodePrev { val = sourceChild.val, prev = target };

					target.next = targetChild;

					target = Process(target, sourceChild, targetChild);
				}

				if (source.next != null)
				{
					var sourceNext = source.next;
					var targetNext = new NodePrev { val = sourceNext.val, prev = target };

					target.next = targetNext;
				}

				if (source.next == null)
					break;

				source = source.next;
				target = target.next;
			}

			return target;
		}
	}
}
