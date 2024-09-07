namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (long a, long c, long seed, long m) = GetConfigValues();

            var lcg = new LinearCongruentialGenerator(a, c, m, seed);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(lcg.Next());
            }
        }

        static (long a, long c, long seed, long m) GetConfigValues()
        {
            long m = UserInput.GetModulusInput();
            long a = UserInput.GetModulusInput(m);
            long c = UserInput.GetLongInput("Enter c (integer): ", m);
            long seed = UserInput.GetLongInput("Enter seed (integer): ", m);


            return (a, c, seed, m);
        }
    }
}
