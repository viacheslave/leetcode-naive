package leetcode;

import java.util.ArrayList;
import java.util.TreeMap;
import java.util.stream.Collectors;

/*
 * Problem: https://leetcode.com/problems/number-of-orders-in-the-backlog/
 * Submission: https://leetcode.com/submissions/detail/492752625/
 */
public class P1801 {
    class Solution {
        public int getNumberOfBacklogOrders(int[][] orders) {
            var sells = new TreeMap<Integer, Bag>();
            var buys = new TreeMap<Integer, Bag>();

            var ans = 0L;

            for (var order : orders) {
                var amount = order[1];
                var price = order[0];

                if (order[2] == 0) {
                    // buy order
                    while (amount > 0) {
                        var entry = sells.firstEntry();
                        if (entry == null)
                            break;

                        var item = entry.getValue();
                        if (item.price > price)
                            break;

                        if (item.amount <= amount) {
                            sells.remove(item.price);
                            amount -= item.amount;
                        } else {
                            item.amount -= amount;
                            amount = 0;
                        }
                    }

                    if (amount > 0) {
                        var bag = buys.getOrDefault(price, null);
                        if (bag == null)
                            bag = new Bag(price, amount);
                        else
                            bag.amount += amount;

                        buys.put(price, bag);
                    }
                }

                if (order[2] == 1) {
                    // buy order
                    while (amount > 0) {
                        var entry = buys.lastEntry();
                        if (entry == null)
                            break;

                        var item = entry.getValue();
                        if (item.price < price)
                            break;

                        if (item.amount <= amount) {
                            buys.remove(item.price);
                            amount -= item.amount;
                        } else {
                            item.amount -= amount;
                            amount = 0;
                        }
                    }

                    if (amount > 0) {
                        var bag = sells.getOrDefault(price, null);
                        if (bag == null)
                            bag = new Bag(price, amount);
                        else
                            bag.amount += amount;

                        sells.put(price, bag);
                    }
                }
            }

            for (var entry : sells.entrySet()) {
                ans += entry.getValue().amount;
            }

            for (var entry : buys.entrySet()) {
                ans += entry.getValue().amount;
            }

            return (int) (ans % 1_000_000_007);
        }

        public class Bag implements Comparable<Bag> {
            public int price;
            public long amount;

            public Bag(int price, long amount) {
                this.price = price;
                this.amount = amount;
            }

            @Override
            public int compareTo(Bag o) {
                return this.price < o.price ? -1 : (this.price > o.price ? 1 : 0);
            }
        }
    }
}