namespace LeetCode.Quests.Hard;
public class TrappingRainWater
{
    /*
        LeetCode 42 - Trapping Rain Water

        Given n non-negative integers representing an elevation map where the width of each bar is 1,
        compute how much water it can trap after raining.

        Example 1:
        Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
        Output: 6
        Explanation: The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1].
        In this case, 6 units of rain water are being trapped.

        Example 2:
        Input: height = [4,2,0,3,2,5]
        Output: 9

        Constraints:
        n == height.length
        1 <= n <= 2 * 10^4
        0 <= height[i] <= 10^5
     */
    public int Solve(int[] height)
    {
        CheckConstraints(height);

        // Water above a bar = min(max on the left, max on the right) - bar height.
        // Two pointers: the side with the smaller max is already bounded, so it can be resolved.
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0, water = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                leftMax = Math.Max(leftMax, height[left]);
                water += leftMax - height[left];
                left++;
            }
            else
            {
                rightMax = Math.Max(rightMax, height[right]);
                water += rightMax - height[right];
                right--;
            }
        }

        return water;
    }

    private static void CheckConstraints(int[] height)
    {
        if (height is null || height.Length < 1 || height.Length > 2 * Math.Pow(10, 4))
            throw new ArgumentException("Invalid array length.");

        if (height.Any(x => x < 0 || x > Math.Pow(10, 5)))
            throw new ArgumentException("Array elements are out of range.");
    }
}
