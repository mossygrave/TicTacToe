using System;

class Program
{
    static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };
    static char currentPlayer = 'X';

    static void Main()
    {
        int turns = 0;
        bool gameWon = false;

        while (!gameWon && turns < 9) //spots are open and no one has won yet
        {
            DisplayBoard();
            Console.WriteLine($"\nPlayer {currentPlayer}, enter a number to place your mark: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int position) && IsValidMove(position)) //takes the input, turns it into an int and checks the position
            {
                MakeMove(position);
                turns++;
                gameWon = CheckWin(); //checks for three in a row

                if (!gameWon)
                    SwitchPlayer();
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }

        DisplayBoard(); //prints who wins or if it is a draw
        if (gameWon)
        {
            Console.WriteLine($"\nPlayer {currentPlayer} wins!");
        }
        else
        {
            Console.WriteLine("\nIt's a draw!");
        }
    }

    static void DisplayBoard() //board setup with array related to places on the board
    {
        Console.Clear();
        Console.WriteLine("Tic Tac Toe");
        Console.WriteLine();
        Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
    }

    static bool IsValidMove(int position) //checks if the position is taken or not
    {
        int row = (position - 1) / 3;
        int col = (position - 1) % 3;
        return board[row, col] != 'X' && board[row, col] != 'O';
    }

    static void MakeMove(int position) //puts the sybol in the chosen spot based on the player
    {
        int row = (position - 1) / 3; 
        int col = (position - 1) % 3;
        board[row, col] = currentPlayer;
    }

    static void SwitchPlayer() //changes who's turn it is
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static bool CheckWin() //checks to see if there are three of the same symbol in a row
    {
        //check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
            {
                return true;
            }
        }

        //check diagonals
        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            return true;
        }

        return false;
    }
}
