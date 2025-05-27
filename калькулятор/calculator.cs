  using System;

namespace AdvancedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DisplayMenu();

                try
                {
                    ProcessCalculation();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введено нечисловое значение!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                }

                if (!AskForContinue())
                    break;
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("=== КАЛЬКУЛЯТОР ===");
            Console.WriteLine("1. Сложение (+)");
            Console.WriteLine("2. Вычитание (-)");
            Console.WriteLine("3. Умножение (*)");
            Console.WriteLine("4. Деление (/)");
            Console.WriteLine("5. Остаток от деления (%)");
            Console.WriteLine("6. Инкремент (++)");
            Console.WriteLine("7. Декремент (--)");
            Console.WriteLine("8. Возведение в степень (^)");
            Console.WriteLine("9. Квадратный корень (sqrt)");
            Console.WriteLine("0. Выход");
            Console.WriteLine("====================");
        }

        static void ProcessCalculation()
        {
            Console.Write("Выберите операцию: ");
            string operation = Console.ReadLine().Trim().ToLower();

            if (operation == "0" || operation == "exit")
                Environment.Exit(0);

            bool isUnary = operation == "6"  operation == "++"  
                          operation == "7"  operation == "--" 
                          operation == "9" || operation == "sqrt";

            double num1 = ReadNumber("Введите число: ");
            double num2 = 0;
            
            if (!isUnary)
            {
                num2 = ReadNumber("Введите второе число: ");
            }

            var result = Calculate(operation, num1, num2);

            if (result.Success)
                Console.WriteLine($"\nРезультат: {result.Value}");
            else
                Console.WriteLine($"\nОшибка: {result.ErrorMessage}");
        }

        static double ReadNumber(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToDouble(Console.ReadLine());
        }

        static (bool Success, double Value, string ErrorMessage) Calculate(string operation, double num1, double num2)
        {
            switch (operation)
            {
                case "1": case "+":
                    return (true, num1 + num2, null);
                
                case "2": case "-":
                    return (true, num1 - num2, null);
                
                case "3": case "*":
                    return (true, num1 * num2, null);
                
                case "4": case "/":
                    return num2 != 0 
                        ? (true, num1 / num2, null) 
                        : (false, 0, "Деление на ноль!");
                
                case "5": case "%":
                    return (true, num1 % num2, null);
                
                case "6": case "++":
                    return (true, num1 + 1, null);
                
                case "7": case "--":
                    return (true, num1 - 1, null);
                
                case "8": case "^":
                    return (true, Math.Pow(num1, num2, null));
                
                case "9": case "sqrt":
                    return num1 >= 0 
                        ? (true, Math.Sqrt(num1), null) 
                        : (false, 0, "Корень из отрицательного числа!");
                
                default:
                    return (false, 0, "Неизвестная операция!");
            }
        }

        static bool AskForContinue()
        {
            Console.Write("\nПродолжить? (y/n): ");
            var key = Console.ReadKey();
            return key.Key == ConsoleKey.Y;
        }
    }
}
