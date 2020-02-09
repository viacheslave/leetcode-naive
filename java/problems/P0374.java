package problems;

class P0374 {
    public class Solution extends GuessGame {
        public int guessNumber(int n) {
            int lo = 1;
            int hi = n;
            Integer next = hi / 2;

            while (true) {
                next = lo + (hi - lo) / 2;

                int res = guess(next);
                if (res == 0)
                    return next;

                if (res == 1) {
                    lo = next;
                }

                if (res == -1) {
                    hi = next;
                }

                if (hi - lo <= 1) {
                    int r = guess(lo);
                    if (r == 0)
                        return lo;

                    int r2 = guess(hi);
                    if (r2 == 0)
                        return hi;
                }
            }
        }
    }
}