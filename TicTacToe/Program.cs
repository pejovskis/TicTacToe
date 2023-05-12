using System;

namespace TicTacToe
{
    class Program
    {

        static string[] tab = {"0", "1", "2", "3", "4", "5", "6", "7", "8"};
        static bool game = true;
        static string playerOne;
        static string playerTwo;


        static void Main(string[] args)
        {

            /*Welcome Screen and name enter*/
            Console.WriteLine("Welcome. Enter first player name: ");
            playerOne = Console.ReadLine();
            Console.WriteLine("Welcome. Enter second player name: ");
            playerTwo = Console.ReadLine();

            

            Tabelle();

            gamePlay();


        }

        static void Tabelle()
        {
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i]);
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

        static void gamePlay()
        {
            while(game)
            {
                Console.WriteLine("First player's turn: ");
                int firstPlayerMove = Convert.ToInt32(Console.ReadLine());

                if (!(tab[firstPlayerMove].Equals("X")) && !(tab[firstPlayerMove].Equals("O")))
                {
                    tab[firstPlayerMove] = "X";
                }

                Tabelle();
                Console.WriteLine("Player one choosed: " + firstPlayerMove);

                game = gameStatusCheck(tab);

                if (!(game))
                {
                    Console.WriteLine("Game OVER! Player " + playerOne + " Won the game!");
                }

                Console.WriteLine("Second player's turn");
                int secondPlayerMove = Convert.ToInt32(Console.ReadLine());

                if (!(tab[secondPlayerMove].Equals("X")) && !(tab[secondPlayerMove].Equals("O")))
                {
                    tab[secondPlayerMove] = "O";
                }

                Tabelle();
                Console.WriteLine("Player one choosed: " + secondPlayerMove);

                game = gameStatusCheck(tab);

                if(!(game))
                {
                    Console.WriteLine("Game OVER!" + playerTwo + " Won the game!");
                }

            }
        }

        static bool gameStatusCheck(string[] arrayIn)
        {
            
            if(arrayIn[0].Equals("X") && arrayIn[1].Equals("X") && arrayIn[2].Equals("X"))
            {
                return false;
            }
            else if(arrayIn[0].Equals("X") && arrayIn[3].Equals("X") && arrayIn[6].Equals("X"))
            {
                return false;
            }
            else if(arrayIn[0].Equals("X") && arrayIn[4].Equals("X") && arrayIn[8].Equals("X"))
            {
                return false;
            }
            else if (arrayIn[0].Equals("O") && arrayIn[1].Equals("O") && arrayIn[2].Equals("O"))
            {
                return false;
            }
            else if (arrayIn[0].Equals("O") && arrayIn[3].Equals("O") && arrayIn[6].Equals("O"))
            {
                return false;
            }
            else if (arrayIn[0].Equals("O") && arrayIn[4].Equals("O") && arrayIn[8].Equals("O"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
