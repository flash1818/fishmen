using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main()
        {
            try
            {
                RunCalculator();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nНажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
        }

        static void RunCalculator()
        {
            Console.WriteLine("Калькулятор умножения (0-10)");
            Console.WriteLine("----------------------------");

            while (true)
            {
                int num1 = GetValidNumber("первое");
                int num2 = GetValidNumber("второе");

                if (AreNumbersValid(num1, num2))
                {
                    int result = MultiplyNumbers(num1, num2);
                    Console.WriteLine($"\nРезультат умножения: {num1} × {num2} = {result}");
                    return;
                }

                Console.WriteLine("Ошибка: числа должны быть от 0 до 10. Попробуйте снова.\n");
            }
        }

        static int GetValidNumber(string numberName)
        {
            while (true)
            {
                Console.Write($"Введите {numberName} число (0-10): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    return number;
                }

                Console.WriteLine("Ошибка: введите целое число.");
            }
        }

        static bool AreNumbersValid(int num1, int num2)
        {
            return num1 >= 0 && num1 <= 10 && num2 >= 0 && num2 <= 10;
        }

        static int MultiplyNumbers(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}