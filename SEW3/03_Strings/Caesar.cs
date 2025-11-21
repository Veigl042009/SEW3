using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Strings
{
    internal class Caesar
    {

        public string Verschluesseln(string eingabe, int schluessel)
        {
            string ausgabe = "";
            foreach (char c in eingabe)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    ausgabe += (char)((((c - baseChar) + schluessel) % 26) + baseChar);
                }
                else
                {
                    ausgabe += c; // andere Zeichen bleiben gleich
                }
            }
            return ausgabe;
        }

        public string Entschluesseln(string eingabe, int schluessel)
        {
            string ausgabe = "";
            foreach (char c in eingabe)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    ausgabe += (char)((((c - baseChar) - schluessel + 26) % 26) + baseChar);
                }
                else
                {
                    ausgabe += c; // andere Zeichen bleiben gleich
                }
            }
            return ausgabe;
        }
    }
}
