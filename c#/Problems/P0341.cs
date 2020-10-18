using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flatten-nested-list-iterator/
  ///    Submission: https://leetcode.com/submissions/detail/241472281/
  /// </summary>
  internal class P0341
  {
    public class Solution
    {
      public class NestedIterator
      {
        List<int> _items = new List<int>();
        int _currentIndex = -1;

        public NestedIterator(IList<NestedInteger> nestedList)
        {
          foreach (NestedInteger item in nestedList)
            _items.AddRange(Parse(item));
        }

        private List<int> Parse(NestedInteger nested)
        {
          var values = new List<int>();

          if (nested.IsInteger())
          {
            values.Add(nested.GetInteger());
          }

          if (nested.GetList() != null)
          {
            var listItems = nested.GetList().SelectMany(Parse);
            values.AddRange(listItems);
          }

          return values;
        }

        public bool HasNext()
        {
          return _currentIndex < _items.Count - 1;
        }

        public int Next()
        {
          _currentIndex++;
          return _items[_currentIndex];
        }
      }
    }
  }
}
