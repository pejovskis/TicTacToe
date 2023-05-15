using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        //Feilds
        private string name;
        private bool alive;
        private char symbol;

        //Board
        private static string[] boardFields = new string[9];
        private static string[] board = new string[9];

        //Notifications
        private String notification = "Notifications: \n";

        //Constructor
        public Player(string name, bool alive, char symbol)
        {
            this.name = name;
            this.alive = alive;
            this.symbol = symbol;
        }

        /*Welcome Screen and name enter*/
        public static void WelcomeScreen(Player player1, Player player2)
        {
            Console.WriteLine("Welcome. Enter first player name: ");
            player1.SetName(Console.ReadLine());
            Console.WriteLine("Welcome. Enter second player name: ");
            player2.SetName(Console.ReadLine());

        }

        //Born players and initialize Board 
        public static void bornPlayers(Player player1, Player player2)
        {
            // Table initialize
            for (int i = 0; i < boardFields.Length; i++)
            {
                string x = Convert.ToString(i);
                boardFields[i] = x;
            }

            // Initialize board
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = " "; // Initialize with empty strings
            }

            // Player born
            player1.SetAlive(true);
            player2.SetAlive(true);


            player1.gameLayout();
        }

        //Board generate
        public void Board()
        {
            Console.WriteLine("Example board:");
            for (int i = 0; i < boardFields.Length; i++)
            {
                Console.Write(boardFields[i]);
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("----------");
                }
                else
                {
                    Console.Write(" | ");
                }
            }

            Console.WriteLine();

            Console.WriteLine("Current board status:");
            for (int i = 0; i < board.Length; i++)
            {
                Console.Write(board[i]);
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("----------");
                }
                else
                {
                    Console.Write(" | ");
                }
            }
        }

        //Game Layout
        public void gameLayout()
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Toe \n");
            Board();
            Console.WriteLine(notification);
        }

        //Gameplay
        public void gamePlay()
        {

            // Declaring player's turn
            notification += name + "'s (" + symbol + ") turn: \n";
            gameLayout();
            int playerMove = 0;

            // Checking if the player gave the correct input || used a busy field and throw error n try again if not.
            try
            {
                playerMove = Convert.ToInt32(Console.ReadLine());

                if ((!(board[playerMove].Equals("X")) && !(board[playerMove].Equals("O"))))
                {
                    board[playerMove] = Convert.ToString(symbol);
                }
                else
                {
                    notification += "Field already used. Try another one. \n";
                    gamePlay();
                }

                notification += name + " chose: " + playerMove + "\n";
                alive = gameStatusCheck(board, symbol);

                if (!(alive))
                {
                    notification += "Game OVER! " + name + " Won the game! \n";
                }
            }
            catch (Exception e)
            {
                notification += "Input should be in the range from 0 to 8. No letters or special characters. \n";
                gamePlay();
            }
            notification = "Notifications: \n";
        }

        //Status Check
        static bool gameStatusCheck(string[] arrayIn, char symbol)
        {
            // Check rows
            if ((arrayIn[0] == arrayIn[1] && arrayIn[1] == arrayIn[2] && arrayIn[0] == Convert.ToString(symbol)) ||
                (arrayIn[3] == arrayIn[4] && arrayIn[4] == arrayIn[5] && arrayIn[3] == Convert.ToString(symbol)) ||
                (arrayIn[6] == arrayIn[7] && arrayIn[7] == arrayIn[8] && arrayIn[6] == Convert.ToString(symbol)))
            {
                return false;
            }

            // Check columns
            if ((arrayIn[0] == arrayIn[3] && arrayIn[3] == arrayIn[6] && arrayIn[0] == Convert.ToString(symbol)) ||
                (arrayIn[1] == arrayIn[4] && arrayIn[4] == arrayIn[7] && arrayIn[1] == Convert.ToString(symbol)) ||
                (arrayIn[2] == arrayIn[5] && arrayIn[5] == arrayIn[8] && arrayIn[2] == Convert.ToString(symbol)))
            {
                return false;
            }

            // Check diagonals
            if ((arrayIn[0] == arrayIn[4] && arrayIn[4] == arrayIn[8] && arrayIn[0] == Convert.ToString(symbol)) ||
                (arrayIn[2] == arrayIn[4] && arrayIn[4] == arrayIn[6] && arrayIn[2] == Convert.ToString(symbol)))
            {
                return false;
            }

            return true;
        }



        //Setter & Getter
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAlive(bool alive)
        {
            this.alive = alive;
        }
        public string GetName()
        {
            return this.name;
        }
        public bool GetAlive()
        {
            return this.alive;
        }
        public char GetSymbol()
        {
            return this.symbol;
        }



    }
}
