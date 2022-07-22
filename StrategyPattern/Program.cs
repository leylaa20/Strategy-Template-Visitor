namespace StrategyPattern;

abstract class CookStrategy
{
    public abstract void Cook(string food);
}

class Grilling : CookStrategy
{
    public override void Cook(string food)
    {
        Console.WriteLine("\nCooking " + food + " by grilling");
    }
}

class OvenBaking : CookStrategy
{
    public override void Cook(string food)
    {
        Console.WriteLine("\nCooking " + food + " by oven baking");
    }
}

class Frying : CookStrategy
{
    public override void Cook(string food)
    {
        Console.WriteLine("\nCooking " + food + " by frying");
    }
}

class CookingMethod
{
    private string? Food;
    private CookStrategy? _cookStrategy;

    public void SetCookStrategy(CookStrategy cookStrategy)
    {
        _cookStrategy = cookStrategy;
    }

    public void SetFood(string name) => Food = name;

    public void Cook() => _cookStrategy?.Cook(Food);

}


class Program
{
    static void Main(string[] args)
    {
        CookingMethod cookMethod = new();
        string? food;
        int choice;
        bool cook = true;

        while (cook == true)
        {
            Console.WriteLine("\nWhat food would you like to cook?");
            food = Console.ReadLine();
            cookMethod.SetFood(food);

            Console.WriteLine("\nWhat cooking strategy would you like to use?");
            Console.Write("1. Grilling\n2. Oven Baking\n3. Frying\n4. Exit\nEnter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    cookMethod.SetCookStrategy(new Grilling());
                    cookMethod.Cook();
                    break;

                case 2:
                    cookMethod.SetCookStrategy(new OvenBaking());
                    cookMethod.Cook();
                    break;

                case 3:
                    cookMethod.SetCookStrategy(new Frying());
                    cookMethod.Cook();
                    break;

                case 4:
                    cook = false;
                    break;
                default:
                    Console.WriteLine("Wrong Selection!");
                    break;
            }
            Thread.Sleep(2000);
            Console.Clear();
        }

    }
}