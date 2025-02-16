namespace _30github_1;

class Program
{
    static Random random = new Random();
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number:");
        int number = int.Parse(Console.ReadLine());
        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine(i);
        }

        while (true)
        {
            Console.WriteLine("Ведите число больше 0:");
            number = int.Parse(Console.ReadLine());
            if (number > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Число должно быть больше 0. Попробуйте снова.");
            }
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

    public static void FeedTheCat()
    {
        Food[] foods = new[] { Food.meat, Food.milk, Food.corn, Food.chicken, Food.fish };
        int satietyOfTheCat = random.Next(1, 101);
        int disiredSatiety = random.Next(1, 101);
        int satiety = 0;
        while (true)
        {
            if (satietyOfTheCat > disiredSatiety)
            {
                Console.WriteLine("Current satiety: " + satietyOfTheCat);
                Console.WriteLine("Disired satiety: " + disiredSatiety);
                Console.WriteLine("The cat should go on a diet");
                break;
            }
            else if (satietyOfTheCat == disiredSatiety)
            {
                Console.WriteLine("Your cat is full!");
                break;
            }
            else
            {
                Console.WriteLine("Current Satiety: " + satietyOfTheCat);
                Console.WriteLine("Disired Satiety: " + disiredSatiety);
                Console.WriteLine("Menu");
                Console.WriteLine("0 - Meat\n1 - Milk\n2 - Corn\n3 - Chicken\n4 - fish");
                Console.WriteLine("What will you feed the cat?");
                int index = random.Next(foods.Length);
                switch (index)
                {
                    case 0:
                        satiety = (int)Food.meat;
                        break;
                    case 1:
                        satiety = (int)Food.milk;
                        break;
                    case 2:
                        satiety = (int)Food.corn;
                        break;
                    case 3:
                        satiety = (int)Food.chicken;
                        break;
                    case 4:
                        satiety = (int)Food.fish;
                        break;
                }

                satietyOfTheCat += satiety;
                Console.WriteLine("The cat ate " + index + " and its satiety increased to: " + satietyOfTheCat);
            }
        }
    }
    
    public static bool IsPalindrome(int x) {
        if(x < 0) return false;
        string strX = x.ToString();
        for(int i = 0; i < strX.Length / 2; i++){
            if(strX[i] != strX[strX.Length - i - 1]) return false;
        }
        return true;
    }
}