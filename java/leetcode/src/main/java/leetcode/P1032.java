package leetcode;

import java.util.*;

/**
 * Problem: https://leetcode.com/problems/stream-of-characters/
 * Submission: https://leetcode.com/submissions/detail/385112776/
 */
public class P1032 {
    class StreamChecker {

        private final TrieNode _root = new TrieNode('\\');

        private ArrayList<TrieNode> _pointers = new ArrayList<>();

        public StreamChecker(String[] words) {
            for (var word : words)
                add(word);
        }

        public boolean query(char letter) {
            var ans = false;

            var pointersNew = new ArrayList<TrieNode>();

            var scan1 = scan(_pointers, pointersNew, letter);
            var scan2 = scan(new ArrayList<TrieNode>(Arrays.asList(_root)), pointersNew, letter);

            ans = scan1 || scan2;

            _pointers = pointersNew;
            return ans;
        }

        private boolean scan(ArrayList<TrieNode> list, ArrayList<TrieNode> pointersNew, char letter) {
            var ans = false;

            for (var pointer : list) {
                if (!pointer.children.containsKey(letter)) {
                    continue;
                }

                var node = pointer.children.get(letter);
                if (node.isEnd)
                    ans = true;

                pointersNew.add(node);
            }

            return ans;
        }

        private void add(String word) {
            var current = _root;

            for (var ch : word.toCharArray()) {
                if (!current.children.containsKey(ch)) {
                    var template = new TrieNode(ch);

                    current.children.put(ch, template);
                    current = template;
                    continue;
                }

                current = current.children.get(ch);
            }

            current.isEnd = true;
        }

        private class TrieNode {
            public HashMap<Character, TrieNode> children;
            public boolean isEnd;
            public char value;

            public TrieNode(char value) {
                this.value = value;
                this.children = new HashMap<Character, TrieNode>();
            }

            @Override
            public boolean equals(Object o) {
                if (this == o)
                    return true;
                if (o == null || getClass() != o.getClass())
                    return false;
                TrieNode trieNode = (TrieNode) o;
                return value == trieNode.value;
            }

            @Override
            public int hashCode() {
                return Objects.hash(value);
            }
        }
    }
}
