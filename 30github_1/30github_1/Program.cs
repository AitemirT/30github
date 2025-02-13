namespace _30github_1;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int target = 16;
        int[] res = TwoSum(nums, target);
        foreach (int numbers in res)
        {
            Console.WriteLine(numbers);
        }
    }
    public static int[] TwoSum(int[] nums, int target) {
        int[] result = new int[2];
        for(int i = 0; i < nums.Length; i++){
            for(int j = 1; j < nums.Length; j++){
                if(nums[i] + nums[j] == target){
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }
        return result;
    }
}