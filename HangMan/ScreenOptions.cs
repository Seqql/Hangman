using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan
{
    class ScreenOptions
    {
        public ScreenOptions()
        {
            Draw += hangman.drawhangman;
        }
        public event EventHandler Draw;
        public List<Wort> Buchstabe = new List<Wort>();
        public  List<string> Used = new List<string>();
        public  HangMan hangman = new HangMan(-1);
        
        //index.hangman =*
        //0.0 =|     | Correct
        //1.0 =|-----| Correct
        //2.1 =   |
        //3.1 =   |/
        //4.2 =   |------|
        //5.3 =   |/     O
        //6.4 =   |     \|/
        //7.5 =   |     / \ 


        public void read()
        {
            Wort w;
            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            Console.Clear();
            Console.WriteLine("  ");

            while (keyinfo.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                w = new Wort(Convert.ToString(keyinfo.Key));
                Buchstabe.Add(w);
                Console.WriteLine("");

                foreach (Wort item in Buchstabe)
                {
                    Console.Write("  " + item.Buchstabe);
                }

                keyinfo = Console.ReadKey();
            }



            if (keyinfo.Key != ConsoleKey.Enter)
            {
                Environment.Exit(0);
            }

            Console.Clear();
            Console.WriteLine("");

            for (int i = 0; i < Buchstabe.Count; i++)
            {
                Console.Write("  _");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");

        }

        public void check(ref bool? gewonnen)
        {
            //Prüft ob schon alle Buchstaben erraten sind
            if (check_all())
            {
                gewonnen = true;
                return;
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            bool inWord = false;
            string s = Convert.ToString(keyInfo.Key);
            //Prüft ob der Buchstabe in dem Wort vorkommt
            foreach (var item in Buchstabe)
            {
                if (item.Buchstabe == s)
                {
                    item.IsCheck = true;
                    inWord = true;
                }
            }

            //Dokumentiert die genutzten Buchstaben (aber nur wenn sie nich im Wort vorkommen)
            if (!inWord)
            {
                if (Used.Count == 0)
                    Used.Add(s);
                else if(check_used(s))
                    Used.Add(s);
                hangman.counter++;

            }
            
            Console.Clear();
            Console.Write("  " + space(Used.Count));
            draw_event(4);
            Console.Write(Environment.NewLine);

            //Schreibt die geschrieben Buchstaben 
            foreach (var item in Buchstabe)
            {
                if(item.IsCheck == true)
                    Console.Write("  " + item.Buchstabe);
                else
                    Console.Write("  _");
            }
            Console.Write("  " + space(Used.Count).Substring(0, space(Used.Count).Length - (Buchstabe.Count * 3)));
            draw_event(3);
            draw_event(5);
            Console.Write(Environment.NewLine);
            Console.Write("  " + space(Used.Count));
            draw_event(2);
            draw_event(6);
            Console.Write(Environment.NewLine);
            //Schreibt die schon genutzten Buchstaben
            foreach (var item in Used)
            {               
                Console.Write("  " + item);
            }


            Console.Write("  " + space(Used.Count).Substring(0, space(Used.Count).Length - (Used.Count * 3)));
            draw_event(2);
            draw_event(7);
            Console.Write(Environment.NewLine);
            Console.Write("  " + space(Used.Count));
            draw_event(1);
            Console.Write(Environment.NewLine);
            Console.Write("  " + space(Used.Count));
            draw_event(0);
            Console.Write(Environment.NewLine);


            if (hangman.counter > 4)           
                gewonnen = null;
                
            
        }

        private bool check_all()
        {
            bool b = true;
            foreach (var item in Buchstabe)
            {
                if (!item.IsCheck){                
                    b = false;
                    break;
                }                                
            }
            return b;
        }
        private bool check_used(string s)
        {
            
            foreach (var item in Used)
            {
                if (item == s)
                    return false;
            }
            return true;
        }
        private string draw_event(int index)
        {
            if (Draw != null)
                Draw(this, new HangmanEventArgs(index));

            return "";
        }
        
        private string space(int min)
        {
            string s = "";

            for (int i = 0; i < min * 3 + 10; i++)
            {
                s += " ";
            }

            if (s.Length <= 15)
            {
                s = "";
                for (int i = 0; i < 15; i++)
                {
                    s += " ";
                }
            }
            return s;
        }
    }
    }

