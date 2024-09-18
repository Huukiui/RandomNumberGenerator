namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (long a, long c, long seed, long m) = GetConfigValues();
            var lcg = new LinearCongruentialGenerator(a, c, m, seed);

            bool running = true;

            while (running)
            {
                Console.Clear();
                lcg.Reset();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Calculate Period");
                Console.WriteLine("2. Print Numbers");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        long period = lcg.GetPeriod();
                        Console.WriteLine($"Period = {period}");
                        break;

                    case "2":
                        Console.Write("Enter the number of values to print (1-10000): ");
                        if (int.TryParse(Console.ReadLine(), out int count) && count > 0 && count <= 10000)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                Console.Write(lcg.Next() + "\t");
                                if ((i + 1) % 4 == 0) Console.WriteLine();
                            }

                            if (AskToSaveToFile())
                            {
                                SaveToFile("numbers.txt", count, lcg);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number. Please enter a value between 1 and 10000.");
                        }
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
                Console.WriteLine("\nPress any key to return to main menu...");
                Console.ReadKey();
            }
        }

        static bool AskToSaveToFile()
        {
            Console.Write($"Do you want to save numbers to a file? (y/n): ");
            string response = Console.ReadLine();
            return response?.Trim().ToLower() == "y";
        }
        static (long a, long c, long seed, long m) GetConfigValues()
        {
            long m = UserInput.GetModulusInput();
            long a = UserInput.GetModulusInput(m);
            long c = UserInput.GetLongInput("Enter c (integer): ", m);
            long seed = UserInput.GetLongInput("Enter seed (integer): ", m);


            return (a, c, seed, m);
        }

        static void SaveToFile(string filepath, int count, LinearCongruentialGenerator lcg)
        {
            try
            {
                lcg.Reset();   
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    for (int i = 0; i < count; i++)
                    {
                        writer.Write(lcg.Next() + "\t");

                        if ((i + 1) % 4 == 0)
                        {
                            writer.WriteLine();
                        }
                    }
                }

                Console.WriteLine($"Results saved to {filepath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save to file: {ex.Message}");
            }
        }
    }
}
