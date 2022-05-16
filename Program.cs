using System;

namespace Program.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
          List<char> board = new List<char>{'1', '2', '3', '4', '5', '6', '7', '8', '9'};
           
           // Display Board
           DisplayBoard(board);

           char currentPlayer = 'x';
           int turn_counter = 0;

            // Main
            while(!IsGameOver(board, turn_counter))
            {
 
                Console.Write($"{currentPlayer}'s turn to choose a square: ");
                
                int choice = GetMoveChoice(currentPlayer);

                MakeMove(board, choice, currentPlayer);
                DisplayBoard(board);

                currentPlayer = GetNextPlayer(currentPlayer);
                turn_counter += 1;
            }
        }

        static void DisplayBoard(List<char> board)
        {
            Console.WriteLine(board[0] + "|" + board[1] + "|" + board[2]);
            Console.WriteLine("-+-+-");
            Console.WriteLine(board[3] + "|" + board[4] + "|" + board[5]);
            Console.WriteLine("-+-+-");
            Console.WriteLine(board[6] + "|" + board[7] + "|" + board[8]);
        }
        static char GetNextPlayer(char currentPlayer)
        {
            char NextPlayer = 'x';

            if(currentPlayer == 'x')
            {
                NextPlayer = 'o';
            }
            return NextPlayer;
        }
        static int GetMoveChoice(char currentPlayer)
        {
            string move_string = Console.ReadLine();

            int choice = int.Parse(move_string);
            return choice;
        }
        static void MakeMove(List<char> board, int choice, char currentPlayer)
        {
            int index = choice - 1;

            board[index] = currentPlayer;
        }
        static void UpdateBoard(List<char> board, char currentPlayer, int index)
        {
            board[index-1] = currentPlayer;
        }
        static bool DetermineWinner(List<char> board, char currentPlayer)
        {
            bool DetermineWinner = false;

            if ((currentPlayer == board[0] && currentPlayer == board[1] && currentPlayer == board[2])
            || (currentPlayer == board[3] && currentPlayer == board[4] && currentPlayer == board[5])
            || (currentPlayer == board[6] && currentPlayer == board[7] && currentPlayer == board[8])
            || (currentPlayer == board[0] && currentPlayer == board[3] && currentPlayer == board[6])
            || (currentPlayer == board[1] && currentPlayer == board[4] && currentPlayer == board[7])
            || (currentPlayer == board[2] && currentPlayer == board[5] && currentPlayer == board[8])
            || (currentPlayer == board[0] && currentPlayer == board[4] && currentPlayer == board[8])
            || (currentPlayer == board[2] && currentPlayer == board[4] && currentPlayer == board[6]))
            {
                DetermineWinner = true;
                Console.WriteLine("Winner!");
            }
            return DetermineWinner;
        }

        static bool IsGameOver(List<char> board, int turn_counter)
        {
            bool IsGameOver = false;
            
            if(DetermineWinner(board, 'x') || DetermineWinner(board, 'o') ||
            IsTie(turn_counter))
            {
                IsGameOver = true;
            }

            return IsGameOver;
        }

        static bool IsTie(int turn_counter)
        {
           bool IsGameOver = false;

           if(turn_counter == 9)
           {
               IsGameOver = true;
               Console.WriteLine("Tie!");
           }
           return IsGameOver;
        }
    
    }
}