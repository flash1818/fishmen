using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main()
        {
            const int tableSize = 10;
            PrintMultiplicationTable(tableSize);
            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        static void PrintMultiplicationTable(int size)
        {
            if (size <= 0)
            {
                Console.WriteLine("Ошибка: размер таблицы должен быть положительным числом.");
                return;
            }

            Console.Write(" \t");
            for (int i = 1; i <= size; i++)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine("\n" + new string('-', (size + 1) * 8));

            for (int row = 1; row <= size; row++)
            {
                Console.Write($"{row} |\t");
                for (int col = 1; col <= size; col++)
                {
                    Console.Write($"{row * col}\t");
                }
                Console.WriteLine();
            }
        }
    }
}