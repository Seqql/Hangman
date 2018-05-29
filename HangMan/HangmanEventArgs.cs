using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan
{
    class HangmanEventArgs: EventArgs
    {
        public int index { get; set; }

        public HangmanEventArgs(int index) => this.index = index;


    }
}
