namespace LeetCode.Quests.Medium;
public class LongestSubstringWithoutRepeating
{
    /*
        LeetCode 3 - Longest Substring Without Repeating Characters

        Given a string s, find the length of the longest substring without duplicate characters.

        Example 1:
        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.

        Example 2:
        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.

        Example 3:
        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

        Constraints:
        0 <= s.length <= 5 * 10^4
        s consists of English letters, digits, symbols and spaces.
     */
    public int Solve(string s)
    {
        CheckConstraints(s);

        // Sliding window: when a char repeats, move left just past its last seen index.
        Dictionary<char, int> lastSeen = new();
        int left = 0, best = 0;
        for (int right = 0; right < s.Length; right++)
        {
            if (lastSeen.TryGetValue(s[right], out var index) && index >= left)
                left = index + 1;

            lastSeen[s[right]] = right;
            best = Math.Max(best, right - left + 1);
        }

        return best;
    }

    private static void CheckConstraints(string s)
    {
        if (s is null || s.Length > 5 * Math.Pow(10, 4))
            throw new ArgumentException("Invalid string length.");
    }
}
