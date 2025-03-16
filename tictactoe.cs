using System;

class Program
{
    static char[,] matrix = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
    static char player = 'X';
    static int n = 0;

    static void Draw()
    {
        Console.Clear();
        Console.WriteLine("!!!!El Roego De la Abuelita!!!!");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("      " + matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Input()
    {
        Console.Write("It's " + player + " turn. Press the number of the field: ");
        int a;
        if (!int.TryParse(Console.ReadLine(), out a) || a < 1 || a > 9)
        {
            Console.WriteLine("Invalid input, try again!");
            Input();
            return;
        }

        int row = (a - 1) / 3;
        int col = (a - 1) % 3;

        if (matrix[row, col] == (char)('0' + a))
        {
            matrix[row, col] = player;
        }
        else
        {
            Console.WriteLine("Field is already in use, try again!");
            Input();
        }
    }

    static void TogglePlayer()
    {
        player = (player == 'X') ? 'O' : 'X';
    }

    static char Win()
    {
        for (int i = 0; i < 3; i++)
        {
            if (matrix[i, 0] == player && matrix[i, 1] == player && matrix[i, 2] == player) return player;
            if (matrix[0, i] == player && matrix[1, i] == player && matrix[2, i] == player) return player;
        }
        if (matrix[0, 0] == player && matrix[1, 1] == player && matrix[2, 2] == player) return player;
        if (matrix[0, 2] == player && matrix[1, 1] == player && matrix[2, 0] == player) return player;

        return '/';
    }

    static void Main()
    {
        Draw();
        while (true)
        {
            n++;
            Input();
            Draw();
            if (Win() == 'X')
            {
                Console.WriteLine("X wins!!!");
                break;
            }
            else if (Win() == 'O')
            {
                Console.WriteLine("O wins!!!");
                break;
            }
            else if (n == 9)
            {
                Console.WriteLine("Draw :(");
                break;
            }
            TogglePlayer();
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    }
}