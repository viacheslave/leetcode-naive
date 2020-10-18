using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/peeking-iterator/
  ///    Submission: https://leetcode.com/submissions/detail/391302022/
  /// </summary>
  internal class P0284
  {
    public class Solution
    {
      // C# IEnumerator interface reference:
      // https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8

      class PeekingIterator
      {
        private int? _next = null;

        private readonly IEnumerator<int> _iterator;

        // iterators refers to the first element of the array.
        public PeekingIterator(IEnumerator<int> iterator)
        {
          _iterator = iterator;

          _next = _iterator.Current;
        }

        // Returns the next element in the iteration without advancing the iterator.
        public int Peek()
        {
          return _next.GetValueOrDefault();
        }

        // Returns the next element in the iteration and advances the iterator.
        public int Next()
        {
          var value = _next.GetValueOrDefault();

          _next = _iterator.MoveNext()
            ? _iterator.Current
            : (int?)null;

          return value;
        }

        // Returns false if the iterator is refering to the end of the array of true otherwise.
        public bool HasNext()
        {
          return _next.HasValue;
        }
      }
    }
  }
}
