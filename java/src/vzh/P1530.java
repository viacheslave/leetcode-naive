package leetcode;

import java.util.HashSet;

/**
 * Problem: https://leetcode.com/problems/number-of-good-leaf-nodes-pairs/
 * Submission: https://leetcode.com/submissions/detail/377455155/
 */
public class P1530 {
     private class TreeNode {
         int val;
         TreeNode left;
         TreeNode right;
         TreeNode() {}
         TreeNode(int val) { this.val = val; }
         TreeNode(int val, TreeNode left, TreeNode right) {
             this.val = val;
             this.left = left;
             this.right = right;
         }
     }

    class Solution {
        public int countPairs(TreeNode root, int distance) {
            var rootExtended = GetExtended(root, null);

            var ans = Traverse(rootExtended, distance);
            return ans / 2;
        }

        private TreeNodeExtended GetExtended(TreeNode node, TreeNodeExtended parent) {
            if (node == null)
                return null;

            var extended = new TreeNodeExtended();
            extended.val = node.val;

            extended.parent = parent;
            extended.left = GetExtended(node.left, extended);
            extended.right = GetExtended(node.right, extended);
            return extended;
        }

        private int Traverse(TreeNodeExtended node, int distance) {
            if (node == null)
                return 0;

            if (node.left == null && node.right == null)
                return DFS(node, distance, 1, new HashSet<TreeNodeExtended>());

            return
                    Traverse(node.left, distance)
                            + Traverse(node.right, distance);
        }

        private int DFS(TreeNodeExtended node, int distance, int init, HashSet<TreeNodeExtended> set) {
            set.add(node);

            var ans = 0;

            for (var item : node.getNodes()) {
                if (item == null || set.contains(item))
                    continue;

                if (init <= distance && item.left == null && item.right == null) {
                    ans++;
                }

                ans += DFS(item, distance, init + 1, set);
            }

            return ans;
        }

        private class TreeNodeExtended {
            public int val;
            public TreeNodeExtended left;
            public TreeNodeExtended right;
            public TreeNodeExtended parent;

            public TreeNodeExtended[] getNodes() {
                return new TreeNodeExtended[] { left, right, parent };
            }
        }
    }
}
