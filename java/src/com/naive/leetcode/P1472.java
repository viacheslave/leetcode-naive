package com.naive.leetcode;

import java.util.ArrayList;

/**
 * Problem: https://leetcode.com/problems/design-browser-history/
 * Submission: https://leetcode.com/submissions/detail/375046651/
 */
public class P1472 {
    class BrowserHistory {

        private ArrayList<String> history;
        private int index;

        public BrowserHistory(String homepage) {
            this.history = new ArrayList<>();
            this.history.add(homepage);

            this.index = 0;
        }

        public void visit(String url) {
            if (this.history.size() > this.index + 1)
                this.history = new ArrayList<>(this.history.subList(0, index + 1));

            this.history.add(url);
            this.index++;
        }

        public String back(int steps) {
            int newIndex = this.index - steps;

            if (newIndex < 0)
                this.index = 0;
            else
                this.index = newIndex;

            return this.history.get(this.index);
        }

        public String forward(int steps) {
            int newIndex = this.index + steps;

            if (newIndex >= this.history.size())
                this.index = this.history.size() - 1;
            else
                this.index = newIndex;

            return this.history.get(this.index);
        }
    }

    /**
     * Your BrowserHistory object will be instantiated and called as such:
     * BrowserHistory obj = new BrowserHistory(homepage);
     * obj.visit(url);
     * String param_2 = obj.back(steps);
     * String param_3 = obj.forward(steps);
     */
}
