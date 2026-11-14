namespace LeetCode.Quests.Medium;
public class ProductOfArrayExceptSelf
{
    /*
        LeetCode 238 - Product of Array Except Self

        Given an integer array nums, return an array answer such that answer[i] is equal to
        the product of all the elements of nums except nums[i].
        You must write an algorithm that runs in O(n) time and without using the division operation.

        Example 1:
        Input: nums = [1,2,3,4]
        Output: [24,12,8,6]

        Example 2:
        Input: nums = [-1,1,0,-3,3]
        Output: [0,0,9,0,0]

        Constraints:
        2 <= nums.length <= 10^5
        -30 <= nums[i] <= 30
        The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
     */
    public int[] Solve(int[] nums)
    {
        CheckConstraints(nums);

        var answer = new int[nums.Length];

        // First pass: answer[i] = product of everything on the left of i.
        answer[0] = 1;
        for (int i = 1; i < nums.Length; i++)
            answer[i] = answer[i - 1] * nums[i - 1];

        // Second pass: multiply by product of everything on the right of i.
        int suffix = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            answer[i] *= suffix;
            suffix *= nums[i];
        }

        return answer;
    }

    private static void CheckConstraints(int[] nums)
    {
        if (nums is null || nums.Length < 2 || nums.Length > Math.Pow(10, 5))
            throw new ArgumentException("Invalid array length.");

        if (nums.Any(x => x < -30 || x > 30))
            throw new ArgumentException("Array elements are out of range.");
    }
}
