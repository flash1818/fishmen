using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите сумму вклада: ");
                decimal initialDeposit = GetValidDecimalInput();

                Console.Write("Введите количество месяцев: ");
                int months = GetValidIntInput();

                if (initialDeposit <= 0 || months <= 0)
                {
                    Console.WriteLine("Ошибка: сумма и срок должны быть положительными числами.");
                    return;
                }

                decimal finalAmount = CalculateCompoundInterest(initialDeposit, months, 0.07m);

                Console.WriteLine($"Конечная сумма вклада: {finalAmount:F2}");
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
        }

        static decimal CalculateCompoundInterest(decimal initialAmount, int months, decimal monthlyRate)
        {
            decimal currentAmount = initialAmount;
            int counter = 0;

            while (counter < months)
            {
                currentAmount += currentAmount * monthlyRate;
                counter++;
            }

            return currentAmount;
        }

        static decimal GetValidDecimalInput()
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                    return result;
                
                Console.Write("Некорректный ввод. Пожалуйста, введите число: ");
            }
        }

        static int GetValidIntInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;
                
                Console.Write("Некорректный ввод. Пожалуйста, введите целое число: ");
            }
        }
    }
}