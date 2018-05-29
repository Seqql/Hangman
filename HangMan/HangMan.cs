using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan
{
    class HangMan
    {
        public int counter { get; set; }

        public HangMan(int h) => counter = h;

        public void drawhangman(object sender, EventArgs e)
        {
            HangmanEventArgs he = (HangmanEventArgs)e;

            if (he.index == 0 && counter >= 0)//Correct
                Console.Write( "|     |");
            else if (he.index == 1 && counter >= 0)//Correct
                Console.Write ("|-----|");
            else if (he.index == 2 && counter >= 1) //Correct
                Console.Write ("   |");
            else if (he.index == 3 && counter >= 1) //Correct
                Console.Write ("   |/");
            else if (he.index == 4 && counter >= 2) //Correct
                Console.Write ("   |------|");
            else if (he.index == 5 && counter >= 3) //Correct
                Console.Write ("     O");
            else if (he.index == 6 && counter >= 4) //Correct
                Console.Write ("     \\|/");
            else if (he.index == 7 && counter >= 5) //Correct 
                Console.Write( "     / \\");
        }

    }
}
