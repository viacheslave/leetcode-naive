package leetcode;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

/**
 * Problem: https://leetcode.com/problems/number-of-nodes-in-the-sub-tree-with-the-same-label/
 * Submission: https://leetcode.com/submissions/detail/374562260/
 */
public class P1519 {
    class Solution {

        private class Node
        {
            public int id;
            public char label;
            public ArrayList<Node> children = new ArrayList<Node>();
        }

        public int[] countSubTrees(int n, int[][] edges, String labels) {
            var nodes = new ArrayList<Node>();

            for (int i = 0; i < n; i++) {
                var node = new Node();
                node.id = i;
                node.label = labels.charAt(i);

                nodes.add(node);
            }

            // connect them
            for (int i = 0; i < edges.length; i++) {
                nodes.get(edges[i][0]).children.add(nodes.get(edges[i][1]));
                nodes.get(edges[i][1]).children.add(nodes.get(edges[i][0]));
            }

            var ans = new int[n];

            for (int i = 0; i < n; i++) {
                if (ans[i] == 0)
                    Process(ans, nodes.get(i), null);
            }

            return ans;
        }

        private HashMap<Character, Integer> Process(int[] ans, Node node, Node parent) {
            var maps = new ArrayList<HashMap<Character, Integer>>();

            for (var child : node.children) {
                if (parent != null && child.id == parent.id)
                    continue;

                var map = Process(ans, child, node);
                maps.add(map);
            }

            var combinedmap = new HashMap<Character, Integer>();

            for (var map : maps) {
                Iterator it = map.entrySet().iterator();

                while (it.hasNext()) {
                    var pair = (Map.Entry<Character, Integer>)it.next();

                    var key = pair.getKey();
                    var value = pair.getValue();

                    if (!combinedmap.containsKey(key))
                        combinedmap.put(key, value);
                    else {
                        var value2 = combinedmap.get(key);
                        combinedmap.put(key, value2 + value);
                    }

                }
            }

            ans[node.id] = 1;
            if (combinedmap.containsKey(node.label))
                ans[node.id] += combinedmap.get(node.label);

            if (!combinedmap.containsKey(node.label))
                combinedmap.put(node.label, 1);
            else
                combinedmap.put(node.label, combinedmap.get(node.label) + 1);

            return combinedmap;
        }
    }
}
