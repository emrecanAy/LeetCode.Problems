namespace LeetCode.Quests.Hard;
public class MedianOfTwoSortedArrays
{
    /*
        LeetCode 4 - Median of Two Sorted Arrays

        Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        The overall run time complexity should be O(log (m+n)).

        Example 1:
        Input: nums1 = [1,3], nums2 = [2]
        Output: 2.00000
        Explanation: merged array = [1,2,3] and median is 2.

        Example 2:
        Input: nums1 = [1,2], nums2 = [3,4]
        Output: 2.50000
        Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

        Constraints:
        nums1.length == m
        nums2.length == n
        0 <= m <= 1000
        0 <= n <= 1000
        1 <= m + n <= 2000
        -10^6 <= nums1[i], nums2[i] <= 10^6
     */
    public double Solve(int[] nums1, int[] nums2)
    {
        CheckConstraints(nums1, nums2);

        // Binary search on the shorter array for a partition where
        // every element on the left side <= every element on the right side.
        if (nums1.Length > nums2.Length)
            (nums1, nums2) = (nums2, nums1);

        int m = nums1.Length, n = nums2.Length;
        int halfLength = (m + n + 1) / 2;
        int low = 0, high = m;

        while (low <= high)
        {
            int cut1 = (low + high) / 2;
            int cut2 = halfLength - cut1;

            int left1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
            int right1 = cut1 == m ? int.MaxValue : nums1[cut1];
            int left2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];
            int right2 = cut2 == n ? int.MaxValue : nums2[cut2];

            if (left1 <= right2 && left2 <= right1)
            {
                if ((m + n) % 2 == 1)
                    return Math.Max(left1, left2);

                return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
            }

            if (left1 > right2)
                high = cut1 - 1;
            else
                low = cut1 + 1;
        }

        throw new ArgumentException("Input arrays are not sorted.");
    }

    private static void CheckConstraints(int[] nums1, int[] nums2)
    {
        if (nums1 is null || nums2 is null)
            throw new ArgumentException("Arrays cannot be null.");

        if (nums1.Length > 1000 || nums2.Length > 1000)
            throw new ArgumentException("Invalid array length.");

        if (nums1.Length + nums2.Length < 1)
            throw new ArgumentException("At least one array must contain an element.");

        if (nums1.Concat(nums2).Any(x => x < -Math.Pow(10, 6) || x > Math.Pow(10, 6)))
            throw new ArgumentException("Array elements are out of range.");
    }
}
