namespace LeetCode.Quests.Easy;
public class ClimbingStairs
{
    /*
        LeetCode 70 - Climbing Stairs

        You are climbing a staircase. It takes n steps to reach the top.
        Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

        Example 1:
        Input: n = 2
        Output: 2
        Explanation: There are two ways to climb to the top.
        1. 1 step + 1 step
        2. 2 steps

        Example 2:
        Input: n = 3
        Output: 3
        Explanation: There are three ways to climb to the top.
        1. 1 step + 1 step + 1 step
        2. 1 step + 2 steps
        3. 2 steps + 1 step

        Constraints:
        1 <= n <= 45
     */
    public int Solve(int n)
    {
        CheckConstraints(n);

        // ways(n) = ways(n - 1) + ways(n - 2) -> Fibonacci. Only the last two values are needed.
        int prev = 1, current = 1;
        for (int i = 2; i <= n; i++)
        {
            var next = prev + current;
            prev = current;
            current = next;
        }

        return current;
    }

    private static void CheckConstraints(int n)
    {
        if (n < 1 || n > 45)
            throw new ArgumentException("n is out of range.");
    }
}
