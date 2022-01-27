using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_generation_app
{

    internal class Generator
    {
        string Password;
        Random rnd = new Random();
         string symbols;


        public string PasswordGenerate(int size, bool num, bool sym, bool UpA, bool LowA)
        {
            Password = null;
            string buf = null;

            if (num == true)
            {

            }
            if (sym == true)
            {

            }
            if (UpA == true)
            {

            }
            if (LowA == true)
            {

            }

            for (int i = 0; i < size; i++)
            {
                Password += buf[rnd.Next(buf.Length)];

            }


            return Password;

        }
        public string PasswordGenerate(int size, string symbols)
        {
            Password = null;
            for (int i = 0; i < size; i++)
            {
                Password += symbols[rnd.Next(symbols.Length)];
            }

            return Password;
        }
    }
}
