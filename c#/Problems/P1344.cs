using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
  /// <summary>
	///		Problem: https://leetcode.com/problems/angle-between-hands-of-a-clock/
	///		Submission: https://leetcode.com/submissions/detail/301638736/
	/// </summary>
	internal class P1344
  {
    public double AngleClock(int hour, int minutes)
    {
      if (hour == 12)
        hour = 0;

      var angleMinute = minutes * 6;
      var angleHour = 30 * hour + (minutes / 2d);

      var ans = Math.Abs(angleHour - angleMinute);
      if (360 - ans < ans)
        ans = 360 - ans;
      return ans;
    }
  }
}
