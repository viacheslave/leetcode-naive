namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/design-hashset/
  ///    Submission: https://leetcode.com/problems/design-hashset/
  /// </summary>
  internal class P0705
  {
    public class MyHashSet
    {

      public int bucketsCount = 10000000;

      public Node[] buckets;

      public class Node
      {
        public int key;
        public int val;

        public Node next;
        public Node prev;

        public Node() {   }

        public Node(int key, int val)
        {
          this.key = key;
          this.val = val;
        }
      }

      private int GetBucket(int key)
      {
        return key % bucketsCount;
      }

      /** Initialize your data structure here. */
      public MyHashSet()
      {
        buckets = new Node[bucketsCount];
      }

      /** value will always be non-negative. */
      public void Add(int key)
      {
        var bucketIndex = GetBucket(key);
        var bucket = buckets[bucketIndex];

        if (bucket == null)
        {
          buckets[bucketIndex] = new Node(key, key);
          return;
        }

        var currentNode = bucket;
        while (currentNode != null)
        {
          if (currentNode.key == key)
          {
            currentNode.val = key;
            return;
          }

          if (currentNode.next == null)
          {
            var newNode = new Node(key, key);
            currentNode.next = newNode;
            newNode.prev = currentNode;
            return;
          }

          currentNode = currentNode.next;
        }
      }

      /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
      public bool Contains(int key)
      {
        var bucketIndex = GetBucket(key);
        var bucket = buckets[bucketIndex];

        if (bucket == null)
          return false;

        var currentNode = bucket;
        while (currentNode != null)
        {
          if (currentNode.key == key)
            return true;

          currentNode = currentNode.next;
        }

        return false;
      }

      /** Removes the mapping of the specified value key if this map contains a mapping for the key */
      public void Remove(int key)
      {
        var bucketIndex = GetBucket(key);
        var bucket = buckets[bucketIndex];

        if (bucket == null)
          return;

        var currentNode = bucket;
        while (currentNode != null)
        {
          if (currentNode.key == key)
          {
            if (currentNode.prev == null)
            {
              buckets[bucketIndex] = currentNode.next;
              return;
            }

            currentNode.prev = currentNode.next;
            return;
          }

          currentNode = currentNode.next;
        }
      }
    }
  }
}
