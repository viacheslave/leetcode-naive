using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-k-pairs-with-smallest-sums/
	///		Submission: https://leetcode.com/submissions/detail/237787286/
	/// </summary>
	internal class P0373
	{
		public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
		{
			List<IList<int>> res = new List<IList<int>>();

			var minHeap = new MinHeap(nums1.Length * nums2.Length);

			for (var i = 0; i < nums1.Length; i++)
				for (var j = 0; j < nums2.Length; j++)
					minHeap.Add((nums1[i] + nums2[j], (nums1[i], nums2[j])));

			var current = k;
			while (k > 0 && !minHeap.IsEmpty())
			{
				var val = minHeap.Pop().Item2;

				res.Add(new List<int>() { val.Item1, val.Item2 });
				k--;
			}

			return res;
		}

		public class MinHeap
		{
			private readonly (int, (int, int))[] _elements;
			private int _size;

			public MinHeap(int size)
			{
				_elements = new (int, (int, int))[size];
			}

			private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
			private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
			private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

			private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
			private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
			private bool IsRoot(int elementIndex) => elementIndex == 0;

			private (int, (int, int)) GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
			private (int, (int, int)) GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
			private (int, (int, int)) GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

			private void Swap(int firstIndex, int secondIndex)
			{
				var temp = _elements[firstIndex];
				_elements[firstIndex] = _elements[secondIndex];
				_elements[secondIndex] = temp;
			}

			public bool IsEmpty()
			{
				return _size == 0;
			}

			public (int, (int, int)) Peek()
			{
				if (_size == 0)
					throw new IndexOutOfRangeException();

				return _elements[0];
			}

			public (int, (int, int)) Pop()
			{
				if (_size == 0)
					throw new IndexOutOfRangeException();

				var result = _elements[0];
				_elements[0] = _elements[_size - 1];
				_size--;

				ReCalculateDown();

				return result;
			}

			public void Add((int, (int, int)) element)
			{
				if (_size == _elements.Length)
					throw new IndexOutOfRangeException();

				_elements[_size] = element;
				_size++;

				ReCalculateUp();
			}

			private void ReCalculateDown()
			{
				int index = 0;
				while (HasLeftChild(index))
				{
					var smallerIndex = GetLeftChildIndex(index);
					if (HasRightChild(index) && GetRightChild(index).Item1 < GetLeftChild(index).Item1)
					{
						smallerIndex = GetRightChildIndex(index);
					}

					if (_elements[smallerIndex].Item1 >= _elements[index].Item1)
					{
						break;
					}

					Swap(smallerIndex, index);
					index = smallerIndex;
				}
			}

			private void ReCalculateUp()
			{
				var index = _size - 1;
				while (!IsRoot(index) && _elements[index].Item1 < GetParent(index).Item1)
				{
					var parentIndex = GetParentIndex(index);
					Swap(parentIndex, index);
					index = parentIndex;
				}
			}
		}
	}
}
