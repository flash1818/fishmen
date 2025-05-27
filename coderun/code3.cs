using System;


namespace _3coderun
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] numbers = Console.ReadLine().Split();
            int count = 0;

            for (int i = 1; i < numbers.Length - 1; i++)
            {

                if (Convert.ToInt64(numbers[i]) > Convert.ToInt64(numbers[i - 1]) && Convert.ToInt64(numbers[i]) > Convert.ToInt64(numbers[i + 1]))
                    count++;
            }

            Console.WriteLine(count);


        }
    }
}
