using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJHerbariumLibrary
{
    internal class Plant
    {
        public int? Id { get; set; }
        public string? NameGerman { get; set; }
        public string? NameLatin { get; set; }
        public string? FamilyGerman { get; set; }
        public string? FamilyLatin { get; set; }
        public string? Location { get; set; }
        public DateOnly? Date { get; set; }
        public List<string> Images { get; set; } = new List<string>();
    }
}
