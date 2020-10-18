using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-parking-system/
  ///    Submission: https://leetcode.com/submissions/detail/404314287/
  /// </summary>
  internal class P1603
  {
    public class ParkingSystem
    {

      private int _big, _medium, _small;

      public ParkingSystem(int big, int medium, int small)
      {
        _big = big;
        _medium = medium;
        _small = small;
      }

      public bool AddCar(int carType)
      {
        switch (carType)
        {
          case 1:
            if (_big == 0) return false;
            else _big--;
            break;
          case 2:
            if (_medium == 0) return false;
            else _medium--;
            break;
          case 3:
            if (_small == 0) return false;
            else _small--;
            break;
        }
        return true;
      }
    }

    /**
     * Your ParkingSystem object will be instantiated and called as such:
     * ParkingSystem obj = new ParkingSystem(big, medium, small);
     * bool param_1 = obj.AddCar(carType);
     */
  }
}
