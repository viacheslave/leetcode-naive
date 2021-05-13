package leetcode;

import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/
 * Submission: https://leetcode.com/submissions/detail/381649264/
 */
public class P1834 {
    class Solution {
        public int[] getOrder(int[][] tasks) {
            var queue = new PriorityQueue<Task>();

            List<Task> items = new ArrayList<Task>();
            for (var i = 0; i < tasks.length; i++) {
                items.add(new Task(i, tasks[i][0], tasks[i][1]));
            }

            items = items.stream()
              .sorted((a, b) -> a.startTime < b.startTime ? -1 : (a.startTime > b.startTime ? 1 : 0))
              .collect(Collectors.toList());

            var ans = new ArrayList<Integer>();
            var processed = 0;
            var time = 0;
            var itemIndex = 0;

            while (processed < items.size()) {

                // process task from queue
                if (queue.size() > 0) {
                    var task = queue.poll();

                    processed++;
                    ans.add(task.index);

                    time = time + task.processingTime;
                }

                if (itemIndex == tasks.length)
                    continue;

                // add tasks to queue
                var task = items.get(itemIndex);

                if (task.startTime > time && queue.size() == 0)
                    time = task.startTime;

                while (task.startTime <= time) {
                    queue.add(task);

                    itemIndex++;
                    if (itemIndex == tasks.length)
                        break;

                    task = items.get(itemIndex);
                }
            }

            return ans.stream().mapToInt(i -> i).toArray();
        }

        class Task implements Comparable<Task>
        {
            public int index;
            public int startTime;
            public int processingTime;

            public Task(int index, int startTime, int processingTime) {
                this.index = index;
                this.startTime = startTime;
                this.processingTime = processingTime;
            }

            @Override
            public int compareTo(Task o) {
                if (this.processingTime < o.processingTime)
                    return -1;
                if (this.processingTime > o.processingTime)
                    return 1;

                if (this.index < o.index)
                    return -1;
                if (this.index > o.index)
                    return 1;
                return 0;
            }
        }
    }
}