using System;

namespace TicTacToe {
    class Field {

        private string[,] field;
        
        public Field()
        {
            field = new string[3, 3];
        }

        public void CreateField() // It just sets every item on the field to be a " ". ( aesthetic purposes )
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int column = 0; column < field.GetLength(1); column++)
                {
                    field[row, column] = " ";
                }
            }
        }

        public void CreateFakeField() // It creates a fake field for ( testing / developing purposes )
        {
            field[0, 0] = "X";
            field[0, 1] = "X";
            field[0, 2] = "O";
            field[1, 0] = "O";
            field[1, 1] = "X";
            field[1, 2] = "O";
            field[2, 0] = "O";
            field[2, 1] = "X";
            field[2, 2] = "X";
        }

        public void ShowField() // It prints out the entire field, and every time the column loop gets finished it jumps a line
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int column = 0; column < field.GetLength(1); column++)
                {
                    Console.Write(field[row, column] + " | "); // + " | " ( aesthetic purposes )
                }
                Console.WriteLine(); // ( aesthetic purposes )
                // it creates a field like this ->  X | O | X      instead of ->   X | O | X | O | X | O | O | O | X
                //                                  O | X | O
                //                                  O | O | X
            }
        }

        public void Play(int positionInTheField, string player) // player = " X OR O "
        {
            switch(positionInTheField) // Nice field to play, instead of using the 0 ~ 8 array method
            { // Instead of the user playing with the 0 index ( 0 ~ 8 ), the user will play with the ( 1 ~ 9 ) method
                // This whole thing could be simplified ( i keeped it ( for aesthetic and pratical purpouses ) )
                case 1:
                    if(PositionIsAvailable(0, 0)) { field[0, 0] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                case 2:
                    if (PositionIsAvailable(0, 1)) { field[0, 1] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                case 3:
                    if (PositionIsAvailable(0, 2)) { field[0, 2] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                case 4:
                    if (PositionIsAvailable(1, 0)) { field[1, 0] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                case 5:
                    if (PositionIsAvailable(1, 1)) { field[1, 1] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                case 6:
                    if (PositionIsAvailable(1, 2)) { field[1, 2] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                case 7:
                    if (PositionIsAvailable(2, 0)) { field[2, 0] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                case 8:
                    if (PositionIsAvailable(2, 1)) { field[2, 1] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                case 9:
                    if (PositionIsAvailable(2, 2)) { field[2, 2] = player; }
                    else { Console.WriteLine("Invalid play"); }
                    break;
                default: Console.WriteLine("Invalid number in the field!");
                    break;
            }
        }

        public bool PositionIsAvailable(int row, int column) // A quick method used in the Play method
        { // It checks whether the position is actually playable ( if it is blank )
            if(field[row, column] != " ") { return false; }
            return true;
        }

        public bool CheckGameStatus() // This is kind of important
        { // It checks the game status ( if someone won ( X or O ) )
            for(int i = 0; i < field.GetLength(0); i++) // I decided to make the entire thing using math
            { // In a older version of this game ( made in java ) i made it using if statements ( approximately 40 )
                int playerX_score_verticalLines = 0; // It wasn't really smart ...
                int playerO_score_verticalLines = 0;

                int playerX_score_horizontalLines = 0;
                int playerO_score_horizontalLines = 0;

                int playerX_score_crossedLines = 0;
                int playerO_score_crossedLines = 0;
                
                for(int j = 0; j < field.GetLength(1); j++) // Vertical loop
                {
                    if(field[i, j] == "X") { playerX_score_verticalLines++; }
                    else if(field[i, j] == "O") { playerO_score_verticalLines++; }
                }

                for(int k = 0; k < field.GetLength(1); k++) // Horizontal loop
                {
                    if(field[k, i] == "X") { playerX_score_horizontalLines++; }
                    else if(field[k, i] == "O") { playerO_score_horizontalLines++; }
                }

                int row = 0; // { 1, 5, 9 }, { 9, 5, 1}
                int invertedRow = 2; // { 7, 5, 3 }, { 3, 5, 7 }
                for(int l = 0; l < field.GetLength(1); l++) // Crossed loop
                {
                    if(field[l, row] == "X") { playerX_score_crossedLines++; }
                    else if(field[invertedRow, l] == "X") { playerX_score_crossedLines++; }
                    
                    if(field[l, row] == "O") { playerO_score_crossedLines++; }
                    else if(field[invertedRow, l] == "O") { playerO_score_crossedLines++; }
                    row++;
                    invertedRow--;
                }

                if (playerX_score_verticalLines >= 3 || playerX_score_horizontalLines >= 3 || playerX_score_crossedLines >= 3)
                {
                    ShowField(); // Updates the field one more time, to show how did the player win
                    Console.WriteLine("The \"X\" player won!!!");
                    return true;
                }
                else if (playerO_score_verticalLines >= 3 || playerO_score_horizontalLines >= 3 || playerO_score_crossedLines >= 3)
                {
                    ShowField();
                    Console.WriteLine("The \"O\" player won!!!");
                    return true;
                }
            }

            return false;
        }
    }
}
