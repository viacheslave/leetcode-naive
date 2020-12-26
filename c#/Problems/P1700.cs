using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/
  ///    Submission: https://leetcode.com/submissions/detail/434801733/
  /// </summary>
  internal class P1700
  {
    public class Solution
    {
      public int CountStudents(int[] students, int[] sandwiches)
      {
        var ones = students.Count(x => x == 1);
        var studentsQueue = new Queue<int>(students);
        var sandwichesList = new List<int>(sandwiches);

        while (studentsQueue.Count > 0)
        {
          var st = studentsQueue.Peek();

          if (st == sandwichesList[0])
          {
            var eater = studentsQueue.Dequeue();
            if (eater == 1)
              ones--;

            sandwichesList.RemoveAt(0);
            continue;
          }

          if (studentsQueue.Count == ones || ones == 0)
            break;

          var nonEater = studentsQueue.Dequeue();
          studentsQueue.Enqueue(nonEater);
        }

        return sandwichesList.Count;
      }
    }
  }
}
