using System;
using System.Collections.Generic;

namespace divisors
{
    public class DivisorsMajorityAnalyzer
    {
        static void Main()
        {
            Console.WriteLine("input darab");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                List<long> numbers = new List<long>();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"input {i + 1}:");
                    if (long.TryParse(Console.ReadLine(), out long number) && number > 0)
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("hiba");
                        i--;
                    }
                }

                Console.WriteLine("\noutput:");

                DivisorAnalysis divisorAnalysis = new DivisorAnalysis();

                foreach (var number in numbers)
                {
                    int result = divisorAnalysis.AnalyzeDivisorsMajority(number);
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("hiba");
            }
        }
    }

    public class DivisorAnalysis
    {
        public int AnalyzeDivisorsMajority(long num)
        {
            if (num <= 0)
            {
                return 0;
            }

            int evenDivisors = 0;
            int oddDivisors = 0;

            long sqrtNum = (long)Math.Sqrt(num);

            for (long i = 2; i <= sqrtNum; i++)
            {
                if (num % i == 0)
                {
                    if (i % 2 == 0)
                    {
                        evenDivisors++;
                    }
                    else
                    {
                        oddDivisors++;
                    }

                    if (i != sqrtNum && ((num / i) % 2 == 0))
                    {
                        evenDivisors++;
                    }
                    else if (i != sqrtNum)
                    {
                        oddDivisors++;
                    }
                }
            }

            if (num % 2 != 0)
            {
                oddDivisors++;
            }

            if (evenDivisors > oddDivisors)
            {
                return 2;
            }
            else if (oddDivisors > evenDivisors)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
