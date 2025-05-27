using System;

class Program
{
    static char[,] field;
    static int turns;
    static char player;
    static bool vsBot;
    static Random rand = new Random();

    static void Main()
    {
        while (true)
        {
            InitGame();

            while (true)
            {
                Console.Clear();
                ShowField();

                if (vsBot && player == 'O')
                {
                    BotMove();
                }
                else
                {
                    Console.Write($"Ход игрока {player}: выбери клетку (1-9) > ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int cell) || cell < 1 || cell > 9)
                    {
                        Console.WriteLine("выбери число от 1 до 9!!!!!!");
                        Console.ReadKey();
                        continue;
                    }

                    int row = (cell - 1) / 3;
                    int col = (cell - 1) % 3;

                    if (field[row, col] == 'X' || field[row, col] == 'O')
                    {
                        Console.WriteLine("нини, клетка занята");
                        Console.ReadKey();
                        continue;
                    }

                    field[row, col] = player;
                }

                turns++;

                if (CheckWin())
                {
                    Console.Clear();
                    ShowField();
                    Console.WriteLine($"игрок {player} победил! умничка!");
                    break;
                }
                else if (turns == 9)
                {
                    Console.Clear();
                    ShowField();
                    Console.WriteLine("ничья!");
                    break;
                }

                player = (player == 'X') ? 'O' : 'X';
            }

            Console.WriteLine("еще разок? (пиши yes/no)");
            string answer = Console.ReadLine().ToLower();
            if (answer != "yes") break;
        }

        Console.WriteLine("ну тада пока. жми любую кнопку чтоб уйти...");
        Console.ReadKey();
    }

    static void InitGame()
    {
        field = new char[3, 3]
        {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };
        turns = 0;
        player = 'X';

        Console.Clear();
        Console.WriteLine("выбери режим игры:");
        Console.WriteLine("1 - игрок против игрока");
        Console.WriteLine("2 - игрок против бота");

        string choice = Console.ReadLine();
        vsBot = choice == "2";
    }

    static void BotMove()
    {
        Console.WriteLine("бот продумывает мощнейшую тактику...");
        int row, col;
        do
        {
            int move = rand.Next(1, 10);
            row = (move - 1) / 3;
            col = (move - 1) % 3;
        } while (field[row, col] == 'X' || field[row, col] == 'O');

        field[row, col] = player;
        System.Threading.Thread.Sleep(500);
    }

    static void ShowField()
    {
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                char c = field[i, j];

                if (c == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (c == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.Write($" {c} ");
                Console.ResetColor();

                if (j < 2)
                    Console.Write("|");
            }

            Console.WriteLine();
            if (i < 2)
                Console.WriteLine("---+---+---");
        }
        Console.WriteLine();
    }



    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2]) return true;
            if (field[0, i] == field[1, i] && field[1, i] == field[2, i]) return true;
        }

        if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2]) return true;
        if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0]) return true;

        return false;
    }
}