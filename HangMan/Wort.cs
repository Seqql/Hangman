using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan
{
    class Wort
    {
       internal string Buchstabe { get; set; }
       internal bool IsCheck { get; set; }



       public Wort(string Buchstabe)
        {
            this.Buchstabe = Buchstabe;
            IsCheck = false;
        }


       
    }
}
