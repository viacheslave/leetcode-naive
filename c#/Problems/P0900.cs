using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/rle-iterator/
	///		Submission: https://leetcode.com/submissions/detail/247318446/
	/// </summary>
	internal class P0900
	{
		public class RLEIterator
		{
			private int[] _a;
			private int _index = 0;

			public RLEIterator(int[] A)
			{
				_a = A;
			}

			public int Next(int n)
			{
				while (_index < _a.Length && n > 0)
				{
					if (_a[_index] >= n)
					{
						_a[_index] -= n;
						return _a[_index + 1];
						break;
					}
					else
					{
						n -= _a[_index];
						_a[_index] = 0;
						_index += 2;
					}
				}

				return -1;
			}
		}

		/**
		 * Your RLEIterator object will be instantiated and called as such:
		 * RLEIterator obj = new RLEIterator(A);
		 * int param_1 = obj.Next(n);
		 */
	}
}
