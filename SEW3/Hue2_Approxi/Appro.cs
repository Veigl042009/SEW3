using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hue2_Approxi
{
    internal class ApproximateMatchingString
    {
        private readonly string word;
        private readonly HashSet<string> wordList;

        // Konstruktor: lädt Wörterliste
        public ApproximateMatchingString(string word, string wordListFile = "german_unsorted.txt")
        {
            this.word = (word ?? "").ToLower();
            wordList = new HashSet<string>();

            // Datei-Existenz prüfen
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, wordListFile);
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Wörterliste nicht gefunden: " + filePath);
                return; // Konstruktor abbrechen
            }

            // Datei einlesen
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string cleanWord = line.Trim().ToLower();
                if (!string.IsNullOrEmpty(cleanWord))
                    wordList.Add(cleanWord);
            }

            Console.WriteLine("Wörterliste geladen: " + wordList.Count + " Wörter.");
        }

        public List<string> Suggestions
        {
            get
            {
                List<string> results = new List<string>();
                results.AddRange(Insertion());
                results.AddRange(Deletion());
                results.AddRange(Replace());
                results.AddRange(Transposition());

                List<string> finalResults = results.Distinct().OrderBy(s => s).ToList();
                return finalResults;
            }
        }

        private List<string> Insertion()
        {
            List<string> results = new List<string>();
            for (int i = 0; i <= word.Length; i++)
                for (char c = 'a'; c <= 'z'; c++)
                {
                    string w = word.Insert(i, c.ToString());
                    if (wordList.Contains(w)) results.Add(w);
                }
            return results;
        }

        private List<string> Deletion()
        {
            List<string> results = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                string w = word.Remove(i, 1);
                if (wordList.Contains(w)) results.Add(w);
            }
            return results;
        }

        private List<string> Replace()
        {
            List<string> results = new List<string>();
            for (int i = 0; i < word.Length; i++)
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (word[i] == c) continue;
                    string w = word.Substring(0, i) + c + word.Substring(i + 1);
                    if (wordList.Contains(w)) results.Add(w);
                }
            return results;
        }

        private List<string> Transposition()
        {
            List<string> results = new List<string>();
            for (int i = 0; i < word.Length - 1; i++)
            {
                char[] chars = word.ToCharArray();
                char temp = chars[i];
                chars[i] = chars[i + 1];
                chars[i + 1] = temp;

                string w = new string(chars);
                if (wordList.Contains(w)) results.Add(w);
            }
            return results;
        }
    }
}
   