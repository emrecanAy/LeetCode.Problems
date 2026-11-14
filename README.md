# LeetCode Problems in C#

My solutions to LeetCode problems, written in C# with a short note on the approach and its complexity.

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-Apache%202.0-blue?style=flat-square)

## Solutions

| # | Problem | Difficulty | Approach | Time | Space | Code |
|---|---|---|---|---|---|---|
| 1 | [Two Sum](https://leetcode.com/problems/two-sum/) | Easy | Hash map of seen values | O(n) | O(n) | [TwoSum.cs](LeetCode.Quests/Easy/TwoSum.cs) |
| 3 | [Longest Substring Without Repeating Characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/) | Medium | Sliding window + last-seen index | O(n) | O(k) | [LongestSubstringWithoutRepeating.cs](LeetCode.Quests/Medium/LongestSubstringWithoutRepeating.cs) |
| 4 | [Median of Two Sorted Arrays](https://leetcode.com/problems/median-of-two-sorted-arrays/) | Hard | Binary search on partition | O(log min(m,n)) | O(1) | [MedianOfTwoSortedArrays.cs](LeetCode.Quests/Hard/MedianOfTwoSortedArrays.cs) |
| 11 | [Container With Most Water](https://leetcode.com/problems/container-with-most-water/) | Medium | Two pointers, move shorter side | O(n) | O(1) | [ContainerWithMostWater.cs](LeetCode.Quests/Medium/ContainerWithMostWater.cs) |
| 13 | [Roman to Integer](https://leetcode.com/problems/roman-to-integer/) | Easy | Subtract when next symbol is bigger | O(n) | O(1) | [RomanToInteger.cs](LeetCode.Quests/Easy/RomanToInteger.cs) |
| 14 | [Longest Common Prefix](https://leetcode.com/problems/longest-common-prefix/) | Easy | Vertical scanning | O(S) | O(1) | [LongestCommonPrefix.cs](LeetCode.Quests/Easy/LongestCommonPrefix.cs) |
| 15 | [3Sum](https://leetcode.com/problems/3sum/) | Medium | Sort + two pointers | O(n²) | O(n) | [ThreeSum.cs](LeetCode.Quests/Medium/ThreeSum.cs) |
| 20 | [Valid Parentheses](https://leetcode.com/problems/valid-parentheses/) | Easy | Stack of open brackets | O(n) | O(n) | [ValidParentheses.cs](LeetCode.Quests/Easy/ValidParentheses.cs) |
| 26 | [Remove Duplicates from Sorted Array](https://leetcode.com/problems/remove-duplicates-from-sorted-array/) | Easy | Two pointers (in-place) | O(n) | O(1) | [RemoveDuplicates.cs](LeetCode.Quests/Easy/RemoveDuplicates.cs) |
| 32 | [Longest Valid Parentheses](https://leetcode.com/problems/longest-valid-parentheses/) | Hard | Stack of indexes with base marker | O(n) | O(n) | [LongestValidParentheses.cs](LeetCode.Quests/Hard/LongestValidParentheses.cs) |
| 41 | [First Missing Positive](https://leetcode.com/problems/first-missing-positive/) | Hard | Cyclic sort (in-place) | O(n) | O(1) | [FirstMissingPositive.cs](LeetCode.Quests/Hard/FirstMissingPositive.cs) |
| 42 | [Trapping Rain Water](https://leetcode.com/problems/trapping-rain-water/) | Hard | Two pointers with left/right max | O(n) | O(1) | [TrappingRainWater.cs](LeetCode.Quests/Hard/TrappingRainWater.cs) |
| 49 | [Group Anagrams](https://leetcode.com/problems/group-anagrams/) | Medium | Letter-count signature as key | O(n·k) | O(n·k) | [GroupAnagrams.cs](LeetCode.Quests/Medium/GroupAnagrams.cs) |
| 70 | [Climbing Stairs](https://leetcode.com/problems/climbing-stairs/) | Easy | Fibonacci DP, two variables | O(n) | O(1) | [ClimbingStairs.cs](LeetCode.Quests/Easy/ClimbingStairs.cs) |
| 238 | [Product of Array Except Self](https://leetcode.com/problems/product-of-array-except-self/) | Medium | Prefix × suffix products | O(n) | O(1)* | [ProductOfArrayExceptSelf.cs](LeetCode.Quests/Medium/ProductOfArrayExceptSelf.cs) |
| 239 | [Sliding Window Maximum](https://leetcode.com/problems/sliding-window-maximum/) | Hard | Monotonic deque | O(n) | O(k) | [SlidingWindowMaximum.cs](LeetCode.Quests/Hard/SlidingWindowMaximum.cs) |

**Progress:** 6 Easy · 5 Medium · 5 Hard — 16 total.  
*\* Output array not counted as extra space.*

## Notes

### 1. Two Sum

The brute-force solution checks every pair, which is O(n²). Instead, walk the array once and keep a
dictionary of `value → index` for everything seen so far. For each number, the matching partner is
`target - nums[i]`; if it's already in the dictionary, the answer is found. Each lookup is O(1), so the
whole pass is O(n).

```csharp
for (int i = 0; i < nums.Length; i++)
{
    int complement = target - nums[i];
    if (seen.TryGetValue(complement, out int j))
        return new[] { j, i };

    seen[nums[i]] = i;
}
```

### 3. Longest Substring Without Repeating Characters

Keep a window `[left, right]` with no duplicates and remember the last index of every character. When
`s[right]` was already seen inside the window, jump `left` just past that index instead of shrinking one
step at a time. Each character is visited once, so it's O(n); `k` is the size of the character set.

### 4. Median of Two Sorted Arrays

Merging would be O(m+n). Instead, binary search a cut in the shorter array; the cut in the other array
follows so that the left half holds `(m+n+1)/2` elements. The cut is correct when
`left1 <= right2 && left2 <= right1`, and then the median comes from the four border values.

### 11. Container With Most Water

Start with the widest container (both ends). The area is limited by the shorter line, so moving the taller
one can never help: always move the shorter pointer inward and track the best area.

### 13. Roman to Integer

Read left to right and add each symbol's value, except when the next symbol is bigger (`IV`, `CM`, ...);
then subtract it instead.

### 14. Longest Common Prefix

Take the first string as reference and compare column by column with every other string. Stop at the
first mismatch or when any string runs out. `S` is the total number of characters.

### 15. 3Sum

Sort the array, fix the first number `nums[i]`, then search the rest with two pointers for a pair summing
to `-nums[i]`. Skipping equal neighbours for the first and second numbers removes duplicate triplets
without a set. Early exit once `nums[i] > 0`.

### 20. Valid Parentheses

Push every opening bracket on a stack. On a closing bracket, the top of the stack must be its matching
pair. The string is valid if the stack is empty at the end.

### 26. Remove Duplicates from Sorted Array

Because the array is sorted, duplicates are adjacent. Pointer `k` marks the next free slot; copy
`nums[i]` there only when it differs from the last kept value.

### 32. Longest Valid Parentheses

Push indexes on a stack that starts with `-1` as a base. `(` pushes its index; `)` pops. If the stack
becomes empty, the current `)` is unmatched and becomes the new base; otherwise `i - stack.Peek()` is the
length of the current valid substring.

### 41. First Missing Positive

The answer is always in `[1, n+1]`. Place every value `v` in that range at index `v-1` by swapping
(cyclic sort). Then the first index `i` where `nums[i] != i+1` gives the answer; if none, it's `n+1`.
O(n) time, no extra memory.

### 42. Trapping Rain Water

Water above a bar is `min(maxLeft, maxRight) - height`. With two pointers, the side whose max is smaller
is already bounded, so its water can be added immediately and that pointer moves inward.

### 49. Group Anagrams

Anagrams have identical letter counts. Build a 26-slot count array for each word and use it as the
dictionary key: O(k) per word instead of O(k log k) for sorting.

### 70. Climbing Stairs

To reach step `n` you come from `n-1` or `n-2`, so `ways(n) = ways(n-1) + ways(n-2)`, which is Fibonacci.
Only the previous two values are needed.

### 238. Product of Array Except Self

No division allowed. First pass stores the product of everything to the left of `i` in the answer
array; second pass (right to left) multiplies in a running product of everything to the right.

### 239. Sliding Window Maximum

Keep a deque of indexes whose values are decreasing. Before adding `nums[i]`, drop smaller values from the
back (they can never be a maximum again) and drop the front index if it left the window. The front is
always the current window's maximum. Every index is pushed and popped at most once.

## Structure

```
LeetCode.Quests/
├── Easy/      one class per problem, with the problem statement as a comment
├── Medium/
├── Hard/
└── Program.cs runs a solution against the examples
```

## Run

```bash
git clone https://github.com/emrecanAy/LeetCode.Problems.git
cd LeetCode.Problems
dotnet run --project LeetCode.Quests
```
