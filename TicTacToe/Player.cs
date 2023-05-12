using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        //Feilds
        string name;
        bool alive;
        char symbol;

        //Tabelle
        static string[] tab = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

        //Constructor
        public Player(string name, bool alive, char symbol)
        {
            this.name = name;
            this.alive = alive;
            this.symbol = symbol;
        }

        //Tabelle generate
        public void Tabelle()
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

        //Gameplay
        public void gamePlay()
        {
                Console.WriteLine(name + "'s turn");
                int playerMove = Convert.ToInt32(Console.ReadLine());

                if (!(tab[playerMove].Equals("X")) && !(tab[playerMove].Equals("O")))
                {
                    tab[playerMove] = Convert.ToString(symbol);
                }

                Tabelle();
                Console.WriteLine(name + " chose: " + playerMove);

                alive = gameStatusCheck(tab, symbol);

                if (!(alive))
                {
                    Console.WriteLine("Game OVER!" + name + " Won the game!");
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
