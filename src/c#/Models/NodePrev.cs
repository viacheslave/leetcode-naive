using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive
{
	public class NodePrev
	{
		public int val;
		public NodePrev prev;
		public NodePrev next;
		public NodePrev child;

		public NodePrev() { }
		public NodePrev(int _val, NodePrev _prev, NodePrev _next, NodePrev _child)
		{
			val = _val;
			prev = _prev;
			next = _next;
			child = _child;
		}
	}
}
