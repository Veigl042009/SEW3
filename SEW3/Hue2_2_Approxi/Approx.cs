using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hue2_2_Approxi
{
    internal class ApproximateMatchingString
    {
        private List<char> word;
        private string pathToWordList;
        public ApproximateMatchingString(List<char> word, string pathToWordList)
        {
            this.word = word;
            this.pathToWordList = pathToWordList;
        }




        public List<string> Suggestions(List<char> word)
        {
            List<string> result = new List<string>();

            result.AddRange(Insertion(word));
            result.AddRange(Deletion(word));
            result.AddRange(Replace(word));
            result.AddRange(Transposition(word));
            return result;
        }

        private List<string> Search(List<char> word)
        {
            string[] germanText = File.ReadAllLines(pathToWordList);
            List<string> result = new List<string>();
            string searchWord = string.Concat(word);
            for (int i = 0; i < germanText.Length; i++)
            {
                if (germanText[i] == searchWord)
                {
                    result.Add(germanText[i]);
                }
            }
            return result;

        }
        private List<string> Insertion(List<char> word)
        {
            List<string> result = new List<string>();

            for (int i = 0; i <= word.Count; i++)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    List<char> editedWord = new List<char>(word);
                    editedWord.Insert(i, c);
                    result.AddRange(Search(editedWord));
                }

                for (char c = 'a'; c <= 'z'; c++)
                {
                    List<char> editedWord = new List<char>(word);
                    editedWord.Insert(i, c);
                    result.AddRange(Search(editedWord));
                }
            }
            return result;
        }
        private List<string> Deletion(List<char> word)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < word.Count; i++)
            {
                List<char> editedWord = new List<char>(word);
                editedWord.RemoveAt(i);
                result.AddRange(Search(editedWord));
            }
            return result;
        }
        private List<string> Replace(List<char> word)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < word.Count; i++)
            {
                List<char> editedWord = new List<char>(word);
                for (int j = 0; j < 26; j++)
                {
                    if (editedWord[i] <= 'Z' && editedWord[i] >= 'A')
                    {
                        editedWord[i] = (char)(editedWord[i] + 1);
                    }
                    if (editedWord[i] > 'Z')
                    {
                        editedWord[i] = (char)(editedWord[i] - 26);
                    }
                    result.AddRange(Search(editedWord));
                }
                for (int j = 0; j < 26; j++)
                {
                    if (editedWord[i] <= 'z' && editedWord[i] >= 'a')
                    {
                        editedWord[i] = (char)(editedWord[i] + 1);
                    }
                    if (editedWord[i] > 'z')
                    {
                        editedWord[i] = (char)(editedWord[i] - 26);
                    }
                    result.AddRange(Search(editedWord));
                }
            }
            return result;
        }
        private List<string> Transposition(List<char> word)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < word.Count - 1; i++)
            {
                List<char> editedWord = new List<char>(word);
                char temp = editedWord[i];
                editedWord[i] = editedWord[i + 1];
                editedWord[i + 1] = temp;
                result.AddRange(Search(editedWord));
            }
            return result;
        }
    }
}
