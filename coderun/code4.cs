using System;

namespace _4coderun
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int a = int.Parse(Console.ReadLine());
            int[] tags = new int[a + 1];

            tags[1] = 1;
            if (a >= 2)
                tags[2] = 1;

            for (int i = 3; i <= a; i++)
            {
                tags[i] = tags[i - 1] + tags[i - 2];
            }

            int sum = 0;
            for (int i = 1; i <= a; i++)
            {
                sum += tags[i];
            }

            Console.WriteLine(sum);


        }
    }
}
