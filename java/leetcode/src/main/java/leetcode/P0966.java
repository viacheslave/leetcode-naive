package leetcode;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

/**
 * Problem: https://leetcode.com/problems/vowel-spellchecker/
 * Submission: https://leetcode.com/submissions/detail/395056262/
 */
public class P0966 {
    class Solution {
        public String[] spellchecker(String[] wordlist, String[] queries) {
            var ans = new ArrayList<String>();
    
            var set = new HashSet<Character>();
            var setWord = new HashSet<String>();
            var mapWordLowered = new HashMap<String, String>();
    
            var listChars = new Character[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            for (var ch : listChars) {
                set.add(ch);
            }
    
            for (var word : wordlist) {
                setWord.add(word);
    
                if (!mapWordLowered.containsKey(word.toLowerCase()))
                    mapWordLowered.put(word.toLowerCase(), word);
            }
    
            var mapWordNoVowels = new HashMap<String, String>();
            var mapWordVowels = new HashMap<String, Integer>();
    
            var mapQueryNoVowels = new HashMap<String, String>();
            var mapQueryVowels = new HashMap<String, Integer>();
    
            FillWords(wordlist, set, mapWordNoVowels, mapWordVowels);
            FillWords(queries, set, mapQueryNoVowels, mapQueryVowels);
    
            for (var query : queries)
            {
                if (setWord.contains(query))
                {
                    ans.add(query);
                    continue;
                }
    
                if (mapWordLowered.containsKey(query.toLowerCase()))
                {
                    ans.add(mapWordLowered.get(query.toLowerCase()));
                    continue;
                }
    
                String matchNoVowels = null;
    
                for (var word : wordlist)
                {
                    if (mapWordNoVowels.get(word).equals(mapQueryNoVowels.get(query)) &&
                        mapWordVowels.get(word).equals(mapQueryVowels.get(query)))
                    {
                        matchNoVowels = word;
                        break;
                    }
                }
    
                if (matchNoVowels != null)
                {
                    ans.add(matchNoVowels);
                    continue;
                }
    
                ans.add("");
            }
    
            return ans.toArray(new String[0]);
        }
    
        private void FillWords(
            String[] wordlist,
            HashSet<Character> set,
            HashMap<String, String> mapWordNoVowels,
            HashMap<String, Integer> mapWordVowels) {
    
            for (var word : wordlist)
            {
                var wlow = word.toLowerCase();
                var vowels = 0;
                var chs = new StringBuilder();
    
                for (var i = 0; i < word.length(); i++)
                    if (set.contains(word.charAt(i)))
                        vowels += 1 << i;
                    else
                        chs.append(wlow.charAt(i));
    
                mapWordNoVowels.put(word, chs.toString());
                mapWordVowels.put(word, vowels);
            }
        }
    }
}
