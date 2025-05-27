using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array3D = {
                { { 1, 2 }, { 3, 4 } },
                { { 4, 5 }, { 6, 7 } },
                { { 7, 8 }, { 9, 10 } },
                { { 10, 11 }, { 12, 13 } }
            };

            Print3DArray(array3D);
            Console.ReadKey();
        }

        static void Print3DArray(int[,,] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(i == 0 ? "{" : " {");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(j == 0 ? "{" : " {");
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i, j, k]);
                        if (k < array.GetLength(2) - 1)
                            Console.Write(", ");
                    }
                    Console.Write("}");
                    if (j < array.GetLength(1) - 1)
                        Console.Write(", ");
                }
                Console.Write("}");
                if (i < array.GetLength(0) - 1)
                    Console.Write("," + Environment.NewLine);
            }
            Console.WriteLine("}");
        }
    }
}
