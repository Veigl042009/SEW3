using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AANotizManagerLibrary
{
    public class NotizManager

    {
        // Property für den Text der Notiz
        public string NotizText { get; set; }

        // Konstruktor: startet mit leerem Text
        public NotizManager()
        {
            NotizText = "";
        }

        // Zählt die Wörter in der Notiz
        public int ZaehleWoerter()
        {
            if (string.IsNullOrWhiteSpace(NotizText))
                return 0;

            string[] woerter = NotizText.Split(' ', '\n', '\t');
            return woerter.Length;
        }

        // Speichert den Text in einer Datei und gibt true zurück, wenn erfolgreich
        public bool SpeichereInDatei(string dateipfad)
        {
            try
            {
                File.WriteAllText(dateipfad, NotizText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Lädt den Text aus einer Datei und gibt ihn zurück
        public string LadeAusDatei(string dateipfad)
        {
            if (File.Exists(dateipfad))
            {
                NotizText = File.ReadAllText(dateipfad);
            }
            else
            {
                NotizText = "";
            }

            return NotizText;
        }

        // Ersetzt Text und gibt den neuen Text zurück
        public string ErsetzeText(string alt, string neu)
        {
            NotizText = NotizText.Replace(alt, neu);
            return NotizText;
        }

    }
}


