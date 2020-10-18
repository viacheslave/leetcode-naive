using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/my-calendar-iii/
  ///    Submission: https://leetcode.com/submissions/detail/409530744/
  /// </summary>
  internal class P0732
  {
    public class MyCalendarThree
    {
      private readonly SortedDictionary<int, List<int>> _r;

      public MyCalendarThree()
      {
        _r = new SortedDictionary<int, List<int>>();
        }

      public int Book(int start, int end)
      {
        PutIfAbsent(start);
        PutIfAbsent(end);

        _r[start].Add(1);
        _r[end].Add(-1);

        var max = int.MinValue;
        var current = 0;

        foreach (var entry in _r)
        {
          current += entry.Value.Sum();

          max = Math.Max(max, current);
          }

        return max;
        }

      private void PutIfAbsent(int key)
      {
        if (!_r.ContainsKey(key))
          _r.Add(key, new List<int>());
        }
      }

    /**
     * Your MyCalendarThree object will be instantiated and called as such:
     * MyCalendarThree obj = new MyCalendarThree();
     * int param_1 = obj.Book(start,end);
     */
    }
}
