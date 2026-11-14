namespace LeetCode.Quests.Hard;
public class FirstMissingPositive
{
    /*
        LeetCode 41 - First Missing Positive

        Given an unsorted integer array nums, return the smallest positive integer that is not present in nums.
        You must implement an algorithm that runs in O(n) time and uses O(1) auxiliary space.

        Example 1:
        Input: nums = [1,2,0]
        Output: 3
        Explanation: The numbers in the range [1,2] are all in the array.

        Example 2:
        Input: nums = [3,4,-1,1]
        Output: 2
        Explanation: 1 is in the array but 2 is missing.

        Example 3:
        Input: nums = [7,8,9,11,12]
        Output: 1
        Explanation: The smallest positive integer 1 is missing.

        Constraints:
        1 <= nums.length <= 10^5
        -2^31 <= nums[i] <= 2^31 - 1
     */
    public int Solve(int[] nums)
    {
        CheckConstraints(nums);

        // Cyclic sort: put every value v in range [1, n] at index v - 1.
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                var target = nums[i] - 1;
                (nums[i], nums[target]) = (nums[target], nums[i]);
            }
        }

        // First index whose value is not i + 1 is the answer.
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i + 1)
                return i + 1;
        }

        return n + 1;
    }

    private static void CheckConstraints(int[] nums)
    {
        // Element range (-2^31 .. 2^31 - 1) is already guaranteed by the int type.
        if (nums is null || nums.Length < 1 || nums.Length > Math.Pow(10, 5))
            throw new ArgumentException("Invalid array length.");
    }
}
