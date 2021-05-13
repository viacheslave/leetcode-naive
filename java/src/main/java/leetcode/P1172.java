package leetcode;

import java.util.*;

/*
 * Problem: https://leetcode.com/problems/dinner-plate-stacks/
 * Submission: https://leetcode.com/submissions/detail/413798648/
 */
class P1172 {
  class DinnerPlates {

    final int capacity;
    final ArrayList<Stack<Integer>> list = new ArrayList<>();
    final TreeSet<Integer> leftmost = new TreeSet<>();
    final TreeSet<Integer> rightmost = new TreeSet<>();


    public DinnerPlates(int capacity) {
      this.capacity = capacity;

      this.leftmost.add(0);
    }

    public void push(int val) {
      var index = -1;

      if (!leftmost.isEmpty()) {
        index = leftmost.first();
      } else {
        index = list.get(list.size() - 1).size() == this.capacity
          ? list.size()
          : list.size() - 1;
      }

      if (list.size() == index)
        list.add(new Stack<>());

      var stack = list.get(index);
      stack.push(val);

      if (!rightmost.contains(index))
        rightmost.add(index);

      if (stack.size() == capacity) {
        leftmost.remove(index);
      }
    }

    public int pop() {
      if (rightmost.isEmpty())
        return -1;

      var index = rightmost.last();
      return popAtStack(index);
    }

    public int popAtStack(int index) {
      if (list.size() <= index)
        return -1;

      var stack = list.get(index);
      var value = stack.isEmpty() ? -1 : stack.pop();

      if (stack.size() < this.capacity) {
        if (!leftmost.contains(index))
          leftmost.add(index);

        if (stack.isEmpty())
          rightmost.remove(index);
      }

      return value;
    }
  }

  /**
   * Your DinnerPlates object will be instantiated and called as such:
   * DinnerPlates obj = new DinnerPlates(capacity);
   * obj.push(val);
   * int param_2 = obj.pop();
   * int param_3 = obj.popAtStack(index);
   */
}