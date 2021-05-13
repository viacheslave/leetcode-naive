package leetcode;

import java.util.Collections;
import java.util.HashMap;
import java.util.PriorityQueue;
import java.util.TreeMap;

/*
 * Problem: https://leetcode.com/problems/maximum-frequency-stack/
 * Submission: https://leetcode.com/submissions/detail/417435415/
 */
class P0895 {
  class FreqStack {

    class Item implements Comparable<Item> {
      public int value;
      public int count;
      public int n;

      public Item(int value, int count, int n) {
        this.value = value;
        this.count = count;
        this.n = n;
      }

      @Override
      public int compareTo(Item o) {
        if (o.count - this.count > 0)
          return -1;
        if (o.count - this.count < 0)
          return 1;

        return this.n - o.n;
      }
    }

    HashMap<Integer, Integer> lastFreq = new HashMap<>();
    PriorityQueue<Item> pq = new PriorityQueue<>(Collections.reverseOrder());
    int counter = 0;

    public FreqStack() {
    }

    public void push(int x) {
      this.lastFreq.putIfAbsent(x, 0);
      this.lastFreq.put(x, this.lastFreq.get(x) + 1);

      pq.add(new Item(x, this.lastFreq.get(x), this.counter++));
    }

    public int pop() {
      var pop = this.pq.poll();
      this.lastFreq.put(pop.value, this.lastFreq.get(pop.value) - 1);

      return pop.value;
    }
  }
}