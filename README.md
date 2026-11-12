# LeetCode Problems in C#

My solutions to LeetCode problems, written in C# with a short note on the approach and its complexity.

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-Apache%202.0-blue?style=flat-square)

## Solutions

| # | Problem | Difficulty | Approach | Time | Space | Code |
|---|---|---|---|---|---|---|
| 1 | [Two Sum](https://leetcode.com/problems/two-sum/) | Easy | Hash map of seen values | O(n) | O(n) | [TwoSum.cs](LeetCode.Quests/Easy/TwoSum.cs) |

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

## Structure

```
LeetCode.Quests/
├── Easy/      one class per problem, with the problem statement as a comment
└── Program.cs runs a solution against the examples
```

## Run

```bash
git clone https://github.com/emrecanAy/LeetCode.Problems.git
cd LeetCode.Problems
dotnet run --project LeetCode.Quests
```
