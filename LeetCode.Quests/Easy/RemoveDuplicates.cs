namespace LeetCode.Quests.Easy;
public class RemoveDuplicates
{
    /*
        LeetCode 26 - Remove Duplicates from Sorted Array

        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place
        such that each unique element appears only once. The relative order of the elements should be kept the same.
        Return k, the number of unique elements. The first k elements of nums must hold the unique elements.

        Example 1:
        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.

        Example 2:
        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.

        Constraints:
        1 <= nums.length <= 3 * 10^4
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
     */
    public int Solve(int[] nums)
    {
        CheckConstraints(nums);

        // k points to the next free slot for a unique value (two pointers).
        int k = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[k - 1])
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }

    private static void CheckConstraints(int[] nums)
    {
        if (nums is null || nums.Length < 1 || nums.Length > 3 * Math.Pow(10, 4))
            throw new ArgumentException("Invalid array length.");

        if (nums.Any(x => x < -100 || x > 100))
            throw new ArgumentException("Array elements are out of range.");

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
                throw new ArgumentException("Array must be sorted in non-decreasing order.");
        }
    }
}
