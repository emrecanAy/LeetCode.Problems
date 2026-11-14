namespace LeetCode.Quests.Medium;
public class ThreeSum
{
    /*
        LeetCode 15 - 3Sum

        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that
        i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
        Notice that the solution set must not contain duplicate triplets.

        Example 1:
        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation:
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].

        Example 2:
        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.

        Example 3:
        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.

        Constraints:
        3 <= nums.length <= 3000
        -10^5 <= nums[i] <= 10^5
     */
    public IList<IList<int>> Solve(int[] nums)
    {
        CheckConstraints(nums);

        // Sort, fix one number, then find the other two with two pointers.
        var sorted = nums.OrderBy(x => x).ToArray();
        var result = new List<IList<int>>();

        for (int i = 0; i < sorted.Length - 2; i++)
        {
            if (sorted[i] > 0)
                break;
            if (i > 0 && sorted[i] == sorted[i - 1])
                continue; // skip duplicate first numbers

            int left = i + 1, right = sorted.Length - 1;
            while (left < right)
            {
                var sum = sorted[i] + sorted[left] + sorted[right];
                if (sum < 0)
                    left++;
                else if (sum > 0)
                    right--;
                else
                {
                    result.Add(new List<int> { sorted[i], sorted[left], sorted[right] });
                    left++;
                    right--;
                    while (left < right && sorted[left] == sorted[left - 1])
                        left++; // skip duplicate second numbers
                }
            }
        }

        return result;
    }

    private static void CheckConstraints(int[] nums)
    {
        if (nums is null || nums.Length < 3 || nums.Length > 3000)
            throw new ArgumentException("Invalid array length.");

        if (nums.Any(x => x < -Math.Pow(10, 5) || x > Math.Pow(10, 5)))
            throw new ArgumentException("Array elements are out of range.");
    }
}
