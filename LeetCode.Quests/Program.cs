using LeetCode.Quests.Easy;

namespace LeetCode.Quests;

public class Program
{
    static void Main(string[] args)
    {
        var solver = new TwoSum();

        int[] nums = { 3,2,4 };
        int target = 6;

        var result = solver.Solve(nums, target);

        Console.WriteLine($"{result[0]}, {result[1]}");

        Console.ReadLine();
    }
}
