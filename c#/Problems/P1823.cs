namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-the-winner-of-the-circular-game/
  ///    Submission: https://leetcode.com/submissions/detail/479247443/
  /// </summary>
  internal class P1823
  {
    public class Solution
    {
      public int FindTheWinner(int n, int k)
      {
        var head = new Node { value = 1 };

        var current = head;
        for (var i = 2; i <= n; i++)
        {
          var node = new Node { value = i };
          current.next = node;
          node.prev = current;

          current = node;
        }

        current.next = head;
        head.prev = current;

        current = head;

        while (n > 1)
        {
          for (var i = 0; i < k - 1; i++)
            current = current.next;

          current.prev.next = current.next;
          current.next.prev = current.prev;

          current = current.next;
          n--;
        }

        return current.value;
      }

      public class Node
      {
        public int value;

        public Node prev;
        public Node next;
      }
    }
  }
}
