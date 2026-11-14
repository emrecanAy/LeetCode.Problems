namespace LeetCode.Quests.Medium;
public class ContainerWithMostWater
{
    /*
        LeetCode 11 - Container With Most Water

        You are given an integer array height of length n. There are n vertical lines drawn such that
        the two endpoints of the ith line are (i, 0) and (i, height[i]).
        Find two lines that together with the x-axis form a container, such that the container contains the most water.
        Return the maximum amount of water a container can store.

        Example 1:
        Input: height = [1,8,6,2,5,4,8,3,7]
        Output: 49
        Explanation: Lines at index 1 (height 8) and index 8 (height 7) -> min(8, 7) * (8 - 1) = 49.

        Example 2:
        Input: height = [1,1]
        Output: 1

        Constraints:
        n == height.length
        2 <= n <= 10^5
        0 <= height[i] <= 10^4
     */
    public int Solve(int[] height)
    {
        CheckConstraints(height);

        // Two pointers from both ends. Always move the shorter line,
        // because moving the taller one can never increase the area.
        int left = 0, right = height.Length - 1, best = 0;
        while (left < right)
        {
            var area = Math.Min(height[left], height[right]) * (right - left);
            best = Math.Max(best, area);

            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return best;
    }

    private static void CheckConstraints(int[] height)
    {
        if (height is null || height.Length < 2 || height.Length > Math.Pow(10, 5))
            throw new ArgumentException("Invalid array length.");

        if (height.Any(x => x < 0 || x > Math.Pow(10, 4)))
            throw new ArgumentException("Array elements are out of range.");
    }
}
