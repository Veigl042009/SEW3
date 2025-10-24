using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_1_String
{
    class CaesarVerschluesselung
    {
        public string Verschluesseln(string eingabe, int schluessel)
        {
            string ausgabe = "";
            for (int i = 0; i < eingabe.Length; i++)
            {
                char c = eingabe[i];
                ausgabe += (char)(c + schluessel);
            }
            return ausgabe;
        }
    }
}
