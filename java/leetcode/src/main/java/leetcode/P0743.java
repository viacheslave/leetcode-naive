package leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/network-delay-time/
 * Submission: https://leetcode.com/submissions/detail/395141311/
 */
public class P0743 {
    class Solution {
        public int networkDelayTime(int[][] times, int N, int K) {
            var ping = new HashMap<Integer, Integer>();
            ping.put(K, 0);

            var nodes = new HashMap<Integer, List<List<Integer>>>();
            for (var time : times) {
                nodes.putIfAbsent(time[0], new ArrayList<>());

                var value = nodes.get(time[0]);
                value.add(new ArrayList<>(Arrays.asList(time[1], time[2])));
            }

            Queue queue = new LinkedList<Map.Entry<Integer, Integer>>();
            queue.add(Map.entry(K, 0));

            var visited = new HashSet<Integer>();

            while (queue.size() > 0) {
                var item = (Map.Entry<Integer, Integer>)queue.poll();

                var key = item.getKey();
                var value = item.getValue();

                if (visited.contains(key) && value >= ping.get(key))
                    continue;

                visited.add(key);

                if (!ping.containsKey(key)) {
                    ping.put(key, value);
                } else {
                    if (ping.get(key) > value)
                        ping.put(key, value);
                }

                var dest = nodes.get(key);
                if (dest == null)
                    continue;

                for (var next : dest) {
                    queue.add(Map.entry(next.get(0), next.get(1) + value));
                }
            }

            return ping.size() == N
                ? ping.entrySet().stream().map(c -> c.getValue()).max(Comparator.naturalOrder()).get().intValue()
                : -1;
        }
    }
}
