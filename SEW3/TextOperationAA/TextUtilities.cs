using System;
using System.Text.RegularExpressions;

namespace TextOperationAA
{
    
    public enum TextOperation
    {
        ToUpper,
        ToLower,
        Reverse,
        ReplaceVowels,
        CountWords
    }

    
    public static class TextUtilities
    {
        
        public static string ApplyOperation(string text, TextOperation operation)
        {
            // Nullprüfung, um Abstürze zu verhindern
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            // switch prüft, welche Operation ausgeführt werden soll
            switch (operation)
            {
                case TextOperation.ToUpper:
                    // Text in Großbuchstaben umwandeln
                    return text.ToUpper();

                case TextOperation.ToLower:
                    // Text in Kleinbuchstaben umwandeln
                    return text.ToLower();

                case TextOperation.Reverse:
                    // Text rückwärts ausgeben
                    return Reverse(text);

                case TextOperation.ReplaceVowels:
                    // Vokale durch * ersetzen
                    return ReplaceVowels(text);

                case TextOperation.CountWords:
                    // Anzahl der Wörter zählen und als String zurückgeben
                    return CountWords(text).ToString();

                default:
                    // Falls kein Fall passt, Text unverändert zurückgeben
                    return text;
            }
        }

        // Hilfsmethode: Text rückwärts drehen
        private static string Reverse(string text)
        {
            // Text in char-Array umwandeln
            char[] chars = text.ToCharArray();

            // Array umdrehen
            Array.Reverse(chars);

            // Neues String-Objekt aus dem Array erzeugen
            return new string(chars);
        }

        // Hilfsmethode: Vokale durch * ersetzen
        private static string ReplaceVowels(string text)
        {
            // Liste aller Vokale (inkl. Umlaute)
            string vowels = "aeiouAEIOUäöüÄÖÜ";

            // Ergebnis-Array vorbereiten
            char[] result = new char[text.Length];

            // Jeden Buchstaben prüfen
            for (int i = 0; i < text.Length; i++)
            {
                // Wenn Vokal → *, sonst Originalbuchstabe
                result[i] = vowels.Contains(text[i]) ? '*' : text[i];
            }

            // Neues String-Objekt zurückgeben
            return new string(result);
        }

        // Hilfsmethode: Wörter zählen
        private static int CountWords(string text)
        {
            // Split nach Leerzeichen, leere Einträge entfernen
            string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Anzahl der Wörter zurückgeben
            return parts.Length;
        }

        // Variante von ApplyOperation, die null akzeptiert
        public static string? ApplyOperationNullable(string? text, TextOperation operation)
        {
            // Wenn null → null zurückgeben
            if (text is null)
                return null;

            // Ansonsten normale Operation ausführen
            return ApplyOperation(text, operation);
        }

        // Normalisiert Text direkt (ref = Original wird verändert)
        public static void NormalizeText(ref string text)
        {
            // Nullprüfung
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            // Entfernt führende und nachfolgende Leerzeichen
            text = text.Trim();

            // Ersetzt doppelte Leerzeichen durch einfache
            while (text.Contains("  ")) // zwei Leerzeichen
            {
                text = text.Replace("  ", " ");
            }
        }

        // Normalisiert Text, gibt aber eine Kopie zurück (Original bleibt unverändert)
        public static string NormalizeTextCopy(string text)
        {
            // Nullprüfung
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            // Kopie erstellen und trimmen
            string copy = text.Trim();

            // Mehrere Leerzeichen durch eines ersetzen
            while (copy.Contains("  "))
            {
                copy = copy.Replace("  ", " ");
            }

            // Neue, bereinigte Version zurückgeben
            return copy;
        }
    }
}
