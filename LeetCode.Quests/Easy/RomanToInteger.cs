namespace LeetCode.Quests.Easy;
public class RomanToInteger
{
    /*
        LeetCode 13 - Roman to Integer

        Roman numerals are represented by seven symbols:
        I = 1, V = 5, X = 10, L = 50, C = 100, D = 500, M = 1000
        Normally symbols are written from largest to smallest (left to right).
        When a smaller symbol comes before a larger one, it is subtracted (IV = 4, IX = 9, XL = 40, XC = 90, CD = 400, CM = 900).
        Given a roman numeral, convert it to an integer.

        Example 1:
        Input: s = "III"
        Output: 3
        Explanation: III = 3.

        Example 2:
        Input: s = "LVIII"
        Output: 58
        Explanation: L = 50, V = 5, III = 3.

        Example 3:
        Input: s = "MCMXCIV"
        Output: 1994
        Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

        Constraints:
        1 <= s.length <= 15
        s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
        It is guaranteed that s is a valid roman numeral in the range [1, 3999].
     */
    private static readonly Dictionary<char, int> Symbols = new()
    {
        { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 },
        { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
    };

    public int Solve(string s)
    {
        CheckConstraints(s);

        int total = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var current = Symbols[s[i]];
            // If the next symbol is bigger, current one must be subtracted (e.g. IV, IX).
            if (i + 1 < s.Length && current < Symbols[s[i + 1]])
                total -= current;
            else
                total += current;
        }

        return total;
    }

    private static void CheckConstraints(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length > 15)
            throw new ArgumentException("Invalid string length.");

        if (s.Any(c => !Symbols.ContainsKey(c)))
            throw new ArgumentException("String contains invalid roman characters.");
    }
}
