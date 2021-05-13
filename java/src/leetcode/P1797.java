package leetcode;

import java.util.HashMap;
import java.util.Map;

/*
 * Problem: https://leetcode.com/problems/design-authentication-manager/
 * Submission: https://leetcode.com/submissions/detail/492757453/
 */
public class P1797 {
    class AuthenticationManager {
        private Map<String, Integer> map = new HashMap<>();
        private int ttl;
      
        public AuthenticationManager(int timeToLive) {
          this.ttl = timeToLive;    
        }
        
        public void generate(String tokenId, int currentTime) {
          this.map.put(tokenId, currentTime + ttl);      
        }
        
        public void renew(String tokenId, int currentTime) {
          var token = map.getOrDefault(tokenId, null);
          if (token != null && token > currentTime) {
            map.put(tokenId, currentTime + ttl);
          }
        }
        
        public int countUnexpiredTokens(int currentTime) {
          var ans = 0;
      
          for (var entry : map.entrySet()) {
            if (entry.getValue() > currentTime) {
              ans++;
            }
          }
      
          return ans;
        }
    }
    
    /**
     * Your AuthenticationManager object will be instantiated and called as such:
    * AuthenticationManager obj = new AuthenticationManager(timeToLive);
    * obj.generate(tokenId,currentTime);
    * obj.renew(tokenId,currentTime);
    * int param_3 = obj.countUnexpiredTokens(currentTime);
    */
}