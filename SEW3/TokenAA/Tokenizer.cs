using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenAA
{
    
    public enum TokenType
    {
        Word,        
        Number,      
        Whitespace,  
        Punctuation, 
        Unknown      
    }

    public static class Tokenizer
    {
        // Zerlegt einen Text in eine Liste von Token
        public static List<Token> Tokenize(string? text)
        {
            // Liste, in die alle gefundenen Token gespeichert werden
            var tokens = new List<Token>();

            // Wenn der Text null ist → leere Liste zurückgeben
            if (text is null)
                return tokens;

            int i = 0; // Laufindex durch den Text

            // Solange wir uns im Text befinden
            while (i < text.Length)
            {
                char current = text[i]; // aktuelles Zeichen
                // Fall 1: Wort (nur Buchstaben)
                
                if (char.IsLetter(current))
                {
                    var sb = new StringBuilder();

                    // Solange Buchstaben folgen → Wort aufbauen
                    while (i < text.Length && char.IsLetter(text[i]))
                    {
                        sb.Append(text[i]);
                        i++;
                    }

                    // Wort-Token hinzufügen
                    tokens.Add(new Token(TokenType.Word, sb.ToString()));
                }
                // Fall 2: Zahl (nur Ziffern)
                
                else if (char.IsDigit(current))
                {
                    var sb = new StringBuilder();

                    // Solange Ziffern folgen → Zahl aufbauen
                    while (i < text.Length && char.IsDigit(text[i]))
                    {
                        sb.Append(text[i]);
                        i++;
                    }

                    // Zahlen-Token hinzufügen
                    tokens.Add(new Token(TokenType.Number, sb.ToString()));
                }
                // Fall 3: Whitespace (Leerzeichen, Tab, etc.)
                else if (char.IsWhiteSpace(current))
                {
                    // Ein einzelnes Whitespace-Zeichen als Token speichern
                    tokens.Add(new Token(TokenType.Whitespace, current.ToString()));
                    i++; // weiter zum nächsten Zeichen
                }
                // Fall 4: Satzzeichen

                else if (".,!?;:".Contains(current))
                {
                    tokens.Add(new Token(TokenType.Punctuation, current.ToString()));
                    i++;
                }

                // Fall 5: Unbekanntes Zeichen

                else
                {
                    tokens.Add(new Token(TokenType.Unknown, current.ToString()));
                    i++;
                }
            }

            // Liste aller gefundenen Token zurückgeben
            return tokens;
        }
    }
}
