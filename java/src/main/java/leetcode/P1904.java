package leetcode;

/*
 * Problem: https://leetcode.com/problems/merge-triplets-to-form-target-triplet/
 * Submission: https://leetcode.com/submissions/detail/511787180/
 */
public class P1904 {
  class Solution {
    public int numberOfRounds(String startTime, String finishTime) {
      var startParts = startTime.split(":");
      var endParts = finishTime.split(":");

      var startHrs = Integer.parseInt(startParts[0]);
      var endHrs = Integer.parseInt(endParts[0]);

      var startMins = Integer.parseInt(startParts[1]) * 4.0 / 60;
      var endMins = Integer.parseInt(endParts[1]) * 4.0 / 60;

      var startMinsCeil = (int)Math.ceil(startMins);
      var endMinsFloor = (int)Math.floor(endMins);

      if (endHrs < startHrs || (endHrs == startHrs && endMins < startMins))
        endHrs += 24;

      if (startMinsCeil == 4) {
        startMinsCeil = 0;
        startHrs++;
      }

      var ans = 0;

      var ch = startHrs;
      var cm = startMinsCeil;

      while (true) {
        if (ch > endHrs || ((ch == endHrs) && (cm >= endMinsFloor)))
          break;

        cm++;

        if (cm == 4) {
          cm = 0;
          ch++;
        }

        ans++;
      }

      return ans;
    }
  }
}