namespace LeetCode.Quests.Hard;
public class LongestValidParentheses
{
    /*
        LeetCode 32 - Longest Valid Parentheses

        Given a string containing just the characters '(' and ')',
        return the length of the longest valid (well-formed) parentheses substring.

        Example 1:
        Input: s = "(()"
        Output: 2
        Explanation: The longest valid parentheses substring is "()".

        Example 2:
        Input: s = ")()())"
        Output: 4
        Explanation: The longest valid parentheses substring is "()()".

        Example 3:
        Input: s = ""
        Output: 0

        Constraints:
        0 <= s.length <= 3 * 10^4
        s[i] is '(', or ')'.
     */
    public int Solve(string s)
    {
        CheckConstraints(s);

        // Stack keeps indexes. Bottom of the stack is the index just before the current valid substring.
        var stack = new Stack<int>();
        stack.Push(-1);
        int best = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
                continue;
            }

            stack.Pop();
            if (stack.Count == 0)
                stack.Push(i); // unmatched ')' becomes the new base
            else
                best = Math.Max(best, i - stack.Peek());
        }

        return best;
    }

    private static void CheckConstraints(string s)
    {
        if (s is null || s.Length > 3 * Math.Pow(10, 4))
            throw new ArgumentException("Invalid string length.");

        if (s.Any(c => c != '(' && c != ')'))
            throw new ArgumentException("String must contain only '(' and ')'.");
    }
}
