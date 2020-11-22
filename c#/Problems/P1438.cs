using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/
  ///    Submission: https://leetcode.com/submissions/detail/423041327/
  /// </summary>
  internal class P1438
  {
    public class Solution
    {
      public int LongestSubarray(int[] nums, int limit)
      {
        var segmin = new SegmentTreeQuery(nums, int.MaxValue, (a, b) => Math.Min(a, b));
        var segmax = new SegmentTreeQuery(nums, int.MinValue, (a, b) => Math.Max(a, b));

        var ans = 0;

        var left = -1;
        var right = -1;

        // sliding window
        while (left <= right && right < nums.Length)
        {
          left++;
          if (left == nums.Length)
            break;

          if (right < left)
            right = left;

          while (right < nums.Length)
          {
            var min = segmin.GetRangeValue((left, right));
            var max = segmax.GetRangeValue((left, right));

            if (max - min <= limit)
            {
              ans = Math.Max(ans, right - left + 1);
              right++;
              continue;
            }

            break;
          }
        }

        return ans;
      }

      // Segment tree that supports min or max
      public class SegmentTreeQuery
      {
        private readonly int[] _data;
        private readonly int _length;
        private readonly int _extremum;
        private readonly Func<int, int, int> _comparisonFunc;

        public SegmentTreeQuery(int[] arr, int extremum, Func<int, int, int> comparisonFunc)
        {
          var height = (int)Math.Ceiling(Math.Log(arr.Length) / Math.Log(2));

          var maxSize = 2 * (int)Math.Pow(2, height) - 1;
          _data = new int[maxSize];

          _length = arr.Length;
          _extremum = extremum;
          _comparisonFunc = comparisonFunc;

          Build(arr, (0, arr.Length - 1), 0);
        }

        public int GetRangeValue((int from, int to) range)
        {
          return GetRangeValue((0, _length - 1), range, 0);
        }

        private int GetRangeValue((int from, int to) dr, (int from, int to) qr, int index)
        {
          if (qr.from <= dr.from && qr.to >= dr.to)
            return _data[index];

          if (qr.from > dr.to || qr.to < dr.from)
            return _extremum;

          var mid = dr.from + (dr.to - dr.from) / 2;

          return _comparisonFunc(
            GetRangeValue((dr.from, mid), qr, 2 * index + 1),
            GetRangeValue((mid + 1, dr.to), qr, 2 * index + 2));
        }

        private int Build(int[] arr, (int from, int to) dr, int index)
        {
          if (dr.from == dr.to)
          {
            _data[index] = arr[dr.from];
            return arr[dr.from];
          }

          var mid = dr.from + (dr.to - dr.from) / 2;

          _data[index] = _comparisonFunc(
            Build(arr, (dr.from, mid), index * 2 + 1),
            Build(arr, (mid + 1, dr.to), index * 2 + 2));

          return _data[index];
        }
      }
    }
  }
}
