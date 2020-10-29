using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-in-mountain-array/
  ///    Submission: https://leetcode.com/submissions/detail/414492580/
  /// </summary>
  internal class P1095
  {
    /**
    * // This is MountainArray's API interface.
    * // You should not implement it, or speculate about its implementation
    */
    class MountainArray {
      public int Get(int index) { throw new NotImplementedException(); }
      public int Length() { throw new NotImplementedException(); }
    }

    class Solution
    {
      public int FindInMountainArray(int target, MountainArray mountainArr)
      {
        var length = mountainArr.Length();
        var peek = GetPeek(mountainArr, length);

        var search_forward = BinarySearch(target, mountainArr, 0, peek, 1);
        var search_backwards = BinarySearch(target, mountainArr, peek, length - 1, -1);

        if (search_backwards == -1 && search_forward == -1)
          return -1;

        var ans = new[] { search_backwards, search_forward }
          .Where(x => x >= 0)
          .Min();

        return ans;
      }

      private int BinarySearch(int target, MountainArray mountainArr, int left, int right, int direction)
      {
        var el_left = mountainArr.Get(left);
        var el_right = mountainArr.Get(right);

        if (direction == 1)
        {
          if (target < el_left || el_right < target)
            return -1;
        }
        else
        {
          if (target > el_left || el_right > target)
            return -1;
        }

        while (true)
        {
          if (right - left == 1)
          {
            if (mountainArr.Get(left) == target)
              return left;
            if (mountainArr.Get(right) == target)
              return right;
            return -1;
          }

          var mid = (left + right) / 2;
          var mid_value = mountainArr.Get(mid);

          if (mid_value == target)
            return mid;

          if (direction == 1)
          {
            if (mid_value < target)
              left = mid;
            else
              right = mid;
          }
          else
          {
            if (mid_value < target)
              right = mid;
            else
              left = mid;
          }
        }
      }

      private int GetPeek(MountainArray mountainArr, int length)
      {
        var left = 0;
        var right = length - 1;
        int peek;

        while (true)
        {
          if (right - left == 1)
          {
            var is_left_peek = IsPeek(mountainArr, left);
            peek = is_left_peek ? left : right;
            break;
          }

          var mid = (right + left) / 2;

          var position = GetPosition(mountainArr, mid, length);
          if (position == 0)
          {
            peek = mid;
            break;
          }

          if (position == -1)
            left = mid;
          else
            right = mid;
        }

        return peek;
      }

      private int GetPosition(MountainArray mountainArr, int mid, int length)
      {
        if (mid == 0)
          return -1;
        if (mid == length - 1)
          return 1;

        var el_mid = mountainArr.Get(mid);
        var el_left = mountainArr.Get(mid - 1);
        var el_right = mountainArr.Get(mid + 1);

        if (el_mid > el_left && el_mid > el_right)
          return 0;

        if (el_left < el_mid && el_mid < el_right)
          return -1;
        else
          return 1;
      }

      private bool IsPeek(MountainArray mountainArr, int point)
      {
        var el_mid = mountainArr.Get(point);
        var el_left = mountainArr.Get(point - 1);
        var el_right = mountainArr.Get(point + 1);

        return el_mid > el_left && el_mid > el_right;
      }
    }
  }
}
