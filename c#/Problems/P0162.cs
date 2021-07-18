using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-peak-element/
  ///    Submission: https://leetcode.com/submissions/detail/524590572/
  /// </summary>
  internal class P0162
  {
    public class Solution
    {
      public int FindPeakElement(int[] nums)
      {
        var arr = new[] { new[] { int.MinValue }, nums, new[] { int.MinValue } }
          .SelectMany(_ => _)
          .ToArray();

        var ans = SearchRec(arr, 1, arr.Length - 2);

        return ans.HasValue
          ? ans.Value - 1
          : 0;
      }

      private int? SearchRec(int[] arr, int start, int end)
      {
        if (start > end)
          return default;

        var mid = (start + end) / 2;

        if (arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1])
          return mid;

        if (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1])
          return SearchRec(arr, mid + 1, end);

        if (arr[mid - 1] > arr[mid] && arr[mid] > arr[mid + 1])
          return SearchRec(arr, start, mid - 1);

        return SearchRec(arr, mid + 1, end) ?? SearchRec(arr, start, mid - 1);
      }
    }
  }
}
