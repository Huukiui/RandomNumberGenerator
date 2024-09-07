using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1
{
    public static class UserInput
    {
        public static long GetLongInput(string prompt, long m)
        {
            long result;
            Console.Write(prompt);
            while (!long.TryParse(Console.ReadLine(), out result) || result >= m)
            {
                Console.Write($"Invalid input. Please enter an integer that is >= zero and < {m}: ");
            }
            return result;
        }

        public static long GetModulusInput()
        {
            while (true)
            {
                Console.Write("Enter m (2^k ± n or any positive integer): ");
                string input = Console.ReadLine();

                var match = Regex.Match(input, @"^2\^(\d+)\s*([+-])\s*(\d+)$");

                if (match.Success)
                {
                    if (long.TryParse(match.Groups[1].Value, out long exponent) &&
                        long.TryParse(match.Groups[3].Value, out long n))
                    {
                        long powerOfTwo = (long)Math.Pow(2, exponent);
                        long result = (match.Groups[2].Value == "+") ? (powerOfTwo + n) : (powerOfTwo - n);

                        if (result > 0)
                        {
                            return result;
                        }
                        Console.WriteLine("Result must be greater than zero and not exceed long maximum value. Please try again.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid exponent or number. Please enter valid integers.");
                    }
                }
                else if (long.TryParse(input, out long value) && value > 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid format or a positive integer.");
                }
            }
        }

        public static long GetModulusInput(long m)
        {
            while (true)
            {
                Console.Write("Enter a (2^k or any positive integer): ");
                string? input = Console.ReadLine();

                var match = Regex.Match(input, @"^2\^(\d+)$");

                if (match.Success)
                {
                    if (long.TryParse(match.Groups[1].Value, out long exponent))
                    {
                        long result = (long)Math.Pow(2, exponent);

                        if (result >= 0 && result < m)
                        {
                            return result;
                        }
                        Console.WriteLine($"Result must be >= 0 and < {m}. Please try again.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid exponent or number. Please enter valid integers.");
                    }
                }
                else if (long.TryParse(input, out long value) && value > 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid format or a positive integer.");
                }
            }
        }
    }
}
