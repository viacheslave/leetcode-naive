package leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/minimum-time-to-collect-all-apples-in-a-tree/
 * Submission: https://leetcode.com/submissions/detail/375344346/
 */
public class P1443 {
    class Solution {
        public int minTime(int n, int[][] edges, List<Boolean> hasApple) {
            ArrayList<TreeNode> nodes = new ArrayList<>();

            for (int i = 0; i < n; i++) {
                TreeNode node = new TreeNode();
                node.hasApple = hasApple.get(i);
                node.value = i;

                nodes.add(node);
            }

            for (int i = 0; i < edges.length; i++) {
                nodes.get(edges[i][0]).nodes.add(nodes.get(edges[i][1]));
                nodes.get(edges[i][1]).nodes.add(nodes.get(edges[i][0]));
            }

            return getTime(nodes.get(0), null, nodes);
        }

        private int getTime(TreeNode treeNode, TreeNode parent, ArrayList<TreeNode> nodes) {
            if (treeNode == null)
                return 0;

            var res = 0;

            for (var i = 0; i < treeNode.nodes.size(); i++) {
                var child = treeNode.nodes.get(i);
                if (child == parent)
                    continue;

                var trav = getTime(child, treeNode, nodes);

                if (trav > 0 || child.hasApple)
                    trav += 2;

                res += trav;
            }

            return res;
        }

        class TreeNode {
            public int value;
            public boolean hasApple;

            public ArrayList<TreeNode> nodes = new ArrayList<>();
        }
    }
}
