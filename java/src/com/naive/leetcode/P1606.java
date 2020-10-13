package com.naive.leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/find-servers-that-handled-most-number-of-requests/
 * Submission: https://leetcode.com/submissions/detail/408173285/
 */
public class P1606 {
    class Solution {
        public List<Integer> busiestServers(int k, int[] arrival, int[] load) {
            var serverLoadMap = new HashMap<Integer, Integer>();
            var endTimeMap = new TreeMap<Integer, TreeSet<Integer>>();

            // reset all servers end-times
            var servers = new TreeSet<Integer>();
            for (var i = 0 ; i < k; i++)
                servers.add(i);

            endTimeMap.put(1, servers);

            for (var i = 0; i < arrival.length; i++) {
                var ar = arrival[i];
                var l = load[i];

                var subMap = endTimeMap.subMap(1, true, ar, true);
                var removeKeys = new ArrayList<Integer>();

                // by request arrival, find all servers which end-time is behind current arrival time
                for (var entry : subMap.entrySet()) {
                    if (entry.getKey() != 1) {
                        var values = endTimeMap.get(1);
                        values.addAll(entry.getValue());
                        removeKeys.add(entry.getKey());
                    }
                }

                // remove those keys from map
                for (var r = 0; r < removeKeys.size(); r++) {
                    endTimeMap.remove(removeKeys.get(r));
                }

                // get available server
                var availableServers = endTimeMap.get(1);
                if (availableServers == null || availableServers.isEmpty())
                    continue;

                // next available server is i % k,
                // otherwise - first one
                var nextServer = availableServers.ceiling(i % k);
                if (nextServer == null)
                    nextServer = availableServers.first();

                serverLoadMap.put(nextServer, serverLoadMap.getOrDefault(nextServer, 0) + 1);
                availableServers.remove(nextServer);

                // put new request end-time
                var endTime = ar + l;
                endTimeMap.putIfAbsent(endTime, new TreeSet<Integer>());
                endTimeMap.get(endTime).add(nextServer);
            }

            var maxRequestsPerServer = serverLoadMap.entrySet()
                .stream()
                .max(Comparator.comparingInt(c -> c.getValue()))
                .get()
                .getValue();

            var busiestServer = serverLoadMap.entrySet().stream()
                .filter(c -> c.getValue().intValue() == maxRequestsPerServer)
                .map(c -> c.getKey())
                .collect(Collectors.toList());

            return busiestServer;
        }
    }
}
