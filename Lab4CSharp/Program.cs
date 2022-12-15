namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // better use initializer list for this
            Money money = new(nominal: 50, amount: 3);

            // part 1

            //Console.WriteLine(money.GetInfo());
            //Console.WriteLine(money.Sum);
            //Console.WriteLine(money.IsEnoughToBuy(30));
            //Console.WriteLine(money.IsEnoughToBuy(300));
            //Console.WriteLine(money.HowManyIsPossibleToBuy(40));

            // part 2
            money[0] = 30;
            money[1] = 23;
            Console.WriteLine(money.ToString());
            money++;
            Console.WriteLine(money.ToString());
            money--;
            Console.WriteLine(money.ToString());
            money += 4;
            Console.WriteLine(money.ToString());

            Console.WriteLine(!money);
            money[1] = 0;
            Console.WriteLine(!money);
            Console.WriteLine();

            // only that format!!!
            Money money_2 = new("/3/4/5/76/");
            Console.WriteLine(money_2.ToString());
        }
    }
}