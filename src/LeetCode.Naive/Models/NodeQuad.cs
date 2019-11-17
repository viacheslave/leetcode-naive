using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive
{
	public class NodeQuad
	{
		public bool val;
		public bool isLeaf;
		public NodeQuad topLeft;
		public NodeQuad topRight;
		public NodeQuad bottomLeft;
		public NodeQuad bottomRight;

		public NodeQuad() { }
		public NodeQuad(bool _val, bool _isLeaf, NodeQuad _topLeft, NodeQuad _topRight, NodeQuad _bottomLeft, NodeQuad _bottomRight)
		{
			val = _val;
			isLeaf = _isLeaf;
			topLeft = _topLeft;
			topRight = _topRight;
			bottomLeft = _bottomLeft;
			bottomRight = _bottomRight;
		}
	}
}
