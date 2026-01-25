namespace LeetCode.Quests.Easy;
public class TwoSum
{
    /*
        Example 1:
        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

        Example 2:
        Input: nums = [3,2,4], target = 6
        Output: [1,2]

        Example 3:
        Input: nums = [3,3], target = 6
        Output: [0,1]
 
        Constraints:
        2 <= nums.length <= 104
        -109 <= nums[i] <= 109
        -109 <= target <= 109
        Only one valid answer exists.
     */
    public int[] Solve(int[] nums, int target)
    {
        if (nums.Length < 2 && nums.Length > Math.Pow(10, 4))
            throw new ArgumentException("Invalid array length.");

        if(nums.Any(x => x < -Math.Pow(10, 9) || x > Math.Pow(10, 9)))
            throw new ArgumentException("Array elements are out of range.");

        if(target < -Math.Pow(10, 9) || target > Math.Pow(10, 9))
            throw new ArgumentException("Target is out of range.");

        Dictionary<int, int> readNumbers = new();

        for (int i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (readNumbers.ContainsKey(complement))
                return new int[] { readNumbers[complement], i };

            readNumbers[nums[i]] = i;
        }

        return new ArgumentException("No valid answer exists.").Data.Values.OfType<int>().ToArray();
    }
}
