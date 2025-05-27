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
                decimal depositAmount = decimal.Parse(Console.ReadLine() ?? "0");

                Console.Write("Введите количество месяцев: ");
                int months = int.Parse(Console.ReadLine() ?? "0");

                if (depositAmount <= 0 || months <= 0)
                {
                    Console.WriteLine("Ошибка: сумма и срок должны быть больше нуля.");
                    return;
                }

                decimal interestRate = 0.07m; // 7% в месяц
                decimal finalAmount = CalculateFinalAmount(depositAmount, months, interestRate);

                Console.WriteLine($"Конечная сумма вклада: {finalAmount:F2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введены некорректные данные.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: слишком большое число.");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static decimal CalculateFinalAmount(decimal initialAmount, int months, decimal monthlyRate)
        {
            decimal currentAmount = initialAmount;
            for (int i = 0; i < months; i++)
            {
                currentAmount += currentAmount * monthlyRate;
            }
            return currentAmount;
        }
    }
}
