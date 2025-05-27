using System;

namespace _1coderun
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] xy = Console.ReadLine().Split();
            byte x = Convert.ToByte(xy[0]);
            byte y = Convert.ToByte(xy[1]);

            Console.WriteLine(x + y);

        }
    }
}
