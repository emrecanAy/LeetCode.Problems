namespace LeetCode.Quests.Medium;
public class GroupAnagrams
{
    /*
        LeetCode 49 - Group Anagrams

        Given an array of strings strs, group the anagrams together. You can return the answer in any order.
        An anagram is a word formed by rearranging the letters of another word, using all the original letters exactly once.

        Example 1:
        Input: strs = ["eat","tea","tan","ate","nat","bat"]
        Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
        Explanation:
        There is no string in strs that can be rearranged to form "bat".
        The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
        The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.

        Example 2:
        Input: strs = [""]
        Output: [[""]]

        Example 3:
        Input: strs = ["a"]
        Output: [["a"]]

        Constraints:
        1 <= strs.length <= 10^4
        0 <= strs[i].length <= 100
        strs[i] consists of lowercase English letters.
     */
    public IList<IList<string>> Solve(string[] strs)
    {
        CheckConstraints(strs);

        // Anagrams share the same letter counts, so the count signature is used as the group key.
        Dictionary<string, List<string>> groups = new();
        foreach (var word in strs)
        {
            var counts = new int[26];
            foreach (var c in word)
                counts[c - 'a']++;

            var key = string.Join('#', counts);
            if (!groups.TryGetValue(key, out var group))
            {
                group = new List<string>();
                groups[key] = group;
            }
            group.Add(word);
        }

        return groups.Values.ToList<IList<string>>();
    }

    private static void CheckConstraints(string[] strs)
    {
        if (strs is null || strs.Length < 1 || strs.Length > Math.Pow(10, 4))
            throw new ArgumentException("Invalid array length.");

        if (strs.Any(x => x is null || x.Length > 100))
            throw new ArgumentException("Invalid string length.");

        if (strs.Any(x => x.Any(c => c < 'a' || c > 'z')))
            throw new ArgumentException("Strings must contain only lowercase English letters.");
    }
}
