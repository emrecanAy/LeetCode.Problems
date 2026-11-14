namespace LeetCode.Quests.Easy;
public class LongestCommonPrefix
{
    /*
        LeetCode 14 - Longest Common Prefix

        Write a function to find the longest common prefix string amongst an array of strings.
        If there is no common prefix, return an empty string "".

        Example 1:
        Input: strs = ["flower","flow","flight"]
        Output: "fl"

        Example 2:
        Input: strs = ["dog","racecar","car"]
        Output: ""
        Explanation: There is no common prefix among the input strings.

        Constraints:
        1 <= strs.length <= 200
        0 <= strs[i].length <= 200
        strs[i] consists of only lowercase English letters if it is non-empty.
     */
    public string Solve(string[] strs)
    {
        CheckConstraints(strs);

        // Compare every string character by character with the first one (vertical scanning).
        var first = strs[0];
        for (int i = 0; i < first.Length; i++)
        {
            var c = first[i];
            for (int j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length || strs[j][i] != c)
                    return first[..i];
            }
        }

        return first;
    }

    private static void CheckConstraints(string[] strs)
    {
        if (strs is null || strs.Length < 1 || strs.Length > 200)
            throw new ArgumentException("Invalid array length.");

        if (strs.Any(x => x is null || x.Length > 200))
            throw new ArgumentException("Invalid string length.");

        if (strs.Any(x => x.Any(c => c < 'a' || c > 'z')))
            throw new ArgumentException("Strings must contain only lowercase English letters.");
    }
}
