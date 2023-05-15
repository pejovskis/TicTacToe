using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace TicTacToe
{
    public class Player
    {

        //Feilds
        private string name;
        private bool alive;
        public static bool boardFilled;
        private char symbol;
        private static int maxField;
        private int score = 0;
        //Board
        private static string[] boardExample = new string[9];
        private static string[] board = new string[9];
        //Notifications
        public static String notification = "Notifications: \n";


        //Constructor
        public Player(string name, char symbol)
        {
            this.name = name;
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
            // Example Board initialize
            for (int i = 0; i < boardExample.Length; i++)
            {
                string x = Convert.ToString(i);
                boardExample[i] = x;
            }

            // Actual board initialize
            for (int i = 0; i < board.Length; i++)
            {
                // Initialize with empty strings
                board[i] = " "; 
            }

            // Player born
            player1.SetAlive(true);
            player2.SetAlive(true);
            boardFilled = false;
            maxField = 9;

            player1.gameLayout();
        }

        //Gameplay
        public void gamePlay()
        {

            if(!(boardFilled))
            {
                // Declaring player's turn
                notification += name + "'s (" + symbol + ") turn: \n";
                gameLayout();
                int playerMove = 0;

                // Checking if the player gave the correct input || used a busy field and throw error n try again if not.
                try
                {
                    playerMove = Convert.ToInt32(Console.ReadLine());
                    notification = "Notifications: \n";

                    if ((!(board[playerMove].Equals("X")) && !(board[playerMove].Equals("O"))))
                    {
                        board[playerMove] = Convert.ToString(symbol);
                        notification += name + " chose: " + playerMove + "\n";
                    }
                    else
                    {
                        notification += "Field already used. Try another one. \n";
                        gamePlay();
                    }

                    //Call the gameStatusCheck Function and decrement maxField for 1
                    alive = gameStatusCheck(board, symbol);
                    maxField--;

                    if (maxField == 0)
                    {
                        boardFilled = true;
                    }

                    if (boardFilled)
                    {
                        notification += "Game OVER! No Winner!";
                        return;
                    }

                    if (!(alive))
                    {
                        notification += "Game OVER! " + name + " Won the game! \n";
                        score++;
                    }
                    
                }
                catch (Exception e)
                {
                    notification += "Input should be in the range from 0 to 8. No letters or special characters. \n";
                    gamePlay();
                }
            } 
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

        //Game Layout
        public void gameLayout()
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Toe \n");
            Console.WriteLine(name + " score: " + score);
            Board();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(notification);
            Console.ResetColor();
        }

        //Board generate
        public void Board()
        {
            Console.WriteLine("Example board:");
            for (int i = 0; i < boardExample.Length; i++)
            {
                Console.Write(boardExample[i]);
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

        //Setter & Getter
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAlive(bool alive)
        {
            this.alive = alive;
        }
        public bool GetAlive()
        {
            return this.alive;
        }

    }
}
