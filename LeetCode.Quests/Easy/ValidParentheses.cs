namespace LeetCode.Quests.Easy;
public class ValidParentheses
{
    /*
        LeetCode 20 - Valid Parentheses

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
        1. Open brackets must be closed by the same type of brackets.
        2. Open brackets must be closed in the correct order.
        3. Every close bracket has a corresponding open bracket of the same type.

        Example 1:
        Input: s = "()"
        Output: true

        Example 2:
        Input: s = "()[]{}"
        Output: true

        Example 3:
        Input: s = "(]"
        Output: false

        Example 4:
        Input: s = "([])"
        Output: true

        Constraints:
        1 <= s.length <= 10^4
        s consists of parentheses only '()[]{}'.
     */
    private static readonly Dictionary<char, char> Pairs = new()
    {
        { ')', '(' }, { ']', '[' }, { '}', '{' }
    };

    public bool Solve(string s)
    {
        CheckConstraints(s);

        // Push opening brackets; on a closing bracket, top of the stack must be its pair.
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (Pairs.TryGetValue(c, out var open))
            {
                if (stack.Count == 0 || stack.Pop() != open)
                    return false;
            }
            else
            {
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }

    private static void CheckConstraints(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length > Math.Pow(10, 4))
            throw new ArgumentException("Invalid string length.");

        if (s.Any(c => !"()[]{}".Contains(c)))
            throw new ArgumentException("String must contain only parentheses.");
    }
}
