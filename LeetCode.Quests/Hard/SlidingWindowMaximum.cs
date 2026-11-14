namespace LeetCode.Quests.Hard;
public class SlidingWindowMaximum
{
    /*
        LeetCode 239 - Sliding Window Maximum

        You are given an array of integers nums, there is a sliding window of size k which is moving
        from the very left of the array to the very right. You can only see the k numbers in the window.
        Each time the sliding window moves right by one position. Return the max sliding window.

        Example 1:
        Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
        Output: [3,3,5,5,6,7]
        Explanation:
        Window position                Max
        ---------------               -----
        [1  3  -1] -3  5  3  6  7       3
         1 [3  -1  -3] 5  3  6  7       3
         1  3 [-1  -3  5] 3  6  7       5
         1  3  -1 [-3  5  3] 6  7       5
         1  3  -1  -3 [5  3  6] 7       6
         1  3  -1  -3  5 [3  6  7]      7

        Example 2:
        Input: nums = [1], k = 1
        Output: [1]

        Constraints:
        1 <= nums.length <= 10^5
        -10^4 <= nums[i] <= 10^4
        1 <= k <= nums.length
     */
    public int[] Solve(int[] nums, int k)
    {
        CheckConstraints(nums, k);

        // Monotonic deque of indexes: values are decreasing from front to back,
        // so the front is always the max of the current window.
        var deque = new LinkedList<int>();
        var result = new int[nums.Length - k + 1];

        for (int i = 0; i < nums.Length; i++)
        {
            // Drop index that slid out of the window.
            if (deque.Count > 0 && deque.First!.Value <= i - k)
                deque.RemoveFirst();

            // Smaller values behind the new one can never be a max again.
            while (deque.Count > 0 && nums[deque.Last!.Value] <= nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            if (i >= k - 1)
                result[i - k + 1] = nums[deque.First!.Value];
        }

        return result;
    }

    private static void CheckConstraints(int[] nums, int k)
    {
        if (nums is null || nums.Length < 1 || nums.Length > Math.Pow(10, 5))
            throw new ArgumentException("Invalid array length.");

        if (nums.Any(x => x < -Math.Pow(10, 4) || x > Math.Pow(10, 4)))
            throw new ArgumentException("Array elements are out of range.");

        if (k < 1 || k > nums.Length)
            throw new ArgumentException("k is out of range.");
    }
}
