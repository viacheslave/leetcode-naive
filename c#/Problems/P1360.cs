using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-days-between-two-dates/
	///		Submission: https://leetcode.com/submissions/detail/308248865/
	/// </summary>
	internal class P1360
	{
    public int DaysBetweenDates(string date1, string date2)
    {
      var d1 = Get(date1);
      var d2 = Get(date2);

      return Math.Abs(d2 - d1);
    }

    private int Get(string date)
    {
      var parts = date.Split('-');
      var year = int.Parse(parts[0]);
      var month = int.Parse(parts[1]);
      var day = int.Parse(parts[2]);

      var datei = year * 10000 + month * 100 + day;

      var y = (year - 1971) * 365;
      for (var i = 1971; i <= year; i++)
      {
        var di = i * 10000 + 0229;
        if (di >= datei)
          continue;

        if (i % 4 == 0 && i != 2100)
          y++;
      }

      var md = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30 };
      var m = 0;
      for (var i = 0; i < month - 1; i++)
        m += md[i];

      var d = day;
      return y + m + d;
    }
  }
}
