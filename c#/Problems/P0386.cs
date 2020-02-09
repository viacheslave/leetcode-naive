using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/lexicographical-numbers/
	///		Submission: https://leetcode.com/submissions/detail/238784678/
	/// </summary>
	internal class P0386
	{
		public struct Value : IComparable<Value>, IEqualityComparer<Value>
		{
			public int _value;
			public int _maxdigits;
			public int _expanded;

			public static readonly Dictionary<int, int> _powers = new Dictionary<int, int>
			{
				[0] = 1,
				[1] = 10,
				[2] = 100,
				[3] = 1000,
				[4] = 10000,
				[5] = 100000,
				[6] = 1000000,
				[7] = 10000000,
			};

			public Value(int value, int maxdigits)
			{
				_value = value;
				_maxdigits = maxdigits - _value.ToString().Length;
				_expanded = _value * _powers[_maxdigits];
			}

			public int CompareTo(Value other)
			{
				if (_expanded < other._expanded)
					return -1;

				if (_expanded > other._expanded)
					return 1;

				else
				{
					if (_maxdigits > other._maxdigits)
						return -1;

					if (_maxdigits < other._maxdigits)
						return 1;

					return 0;
				}
			}

			public bool Equals(Value x, Value y)
			{
				return x._value == y._value && x._maxdigits == y._maxdigits;
			}

			public int GetHashCode(Value obj)
			{
				return obj._value ^ obj._maxdigits;
			}

			public override string ToString() => _value.ToString();
		}

		public IList<int> LexicalOrder(int n)
		{
			var length = n.ToString().Length;

			var set = new SortedSet<Value>(Enumerable.Range(1, n).Select(_ => new Value(_, length)));

			return set.Select(_ => _._value).ToList();
		}
	}
}
