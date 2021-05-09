using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/seat-reservation-manager/
  ///    Submission: https://leetcode.com/submissions/detail/490847002/
  /// </summary>
  internal class P1845
  {
    public class SeatManager
    {
      private SortedSet<int> _seats = new SortedSet<int>();

      public SeatManager(int n)
      {
        _seats = new SortedSet<int>(Enumerable.Range(1, n));
      }

      public int Reserve()
      {
        var min = _seats.Min;

        _seats.Remove(min);
        return min;
      }

      public void Unreserve(int seatNumber)
      {
        _seats.Add(seatNumber);
      }
    }

    /**
     * Your SeatManager object will be instantiated and called as such:
     * SeatManager obj = new SeatManager(n);
     * int param_1 = obj.Reserve();
     * obj.Unreserve(seatNumber);
     */
  }
}
