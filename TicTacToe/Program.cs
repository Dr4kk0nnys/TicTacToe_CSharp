using System;

namespace TicTacToe {
    class Program {
        static void Main(string[] args) {

            Field field = new Field();

            field.CreateField();
            //field.CreateFakeField();

            int countPlay = 1;

            while(true)
            {
                field.ShowField();

                Console.Write("Where do you want to play ? [ 1 - 9 ] : ");
                string play = Console.ReadLine();

                countPlay++;
                /*
                 The try / catch statement extends for whether the user actually typed a number
                 if it didn't it will fall into the while loop, and it will continue until the user type a number

                By the way, if the user typed an invalid number ( like 100 ), it will say ( " Invalid play " ), and the user will
                lose it's turn
                 */
                try { field.Play((Convert.ToInt32(play)), countPlay % 2 == 0 ? "X" : "O"); }
                catch
                {
                    while(true)
                    {
                        Console.WriteLine("Invalid play! Try again!");
                       try 
                        { 
                            field.Play(Convert.ToInt32(play), "X"); 
                            break; // If the user finally typed a number, it will break out of the loop
                        }
                        catch // If not ... It will continue forever ...
                        { 
                            Console.WriteLine("Invalid play! Try again!");
                            play = Console.ReadLine();
                        }
                    }
                }
                if (field.CheckGameStatus()) { break; }
            }
        }
    }
}
