using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Domain
{
    public class PinPad
    {
        public List<PinKey> Keys { get; set; }
        public PinPad()
        {
            Keys = new List<PinKey>();
            List<int> neighbours = new List<int>();
            Keys.Add(new PinKey() { Number="0", NeighBours=new List<string>() { "0","8" } });
            Keys.Add(new PinKey() { Number = "1", NeighBours = new List<string>() { "1","2","4" } });
            Keys.Add(new PinKey() { Number = "2", NeighBours = new List<string>() { "1","2","3","5" } });
            Keys.Add(new PinKey() { Number = "3", NeighBours = new List<string>() { "2","3","6" } });
            Keys.Add(new PinKey() { Number = "4", NeighBours = new List<string>() { "1","4","5","7" } });
            Keys.Add(new PinKey() { Number = "5", NeighBours = new List<string>() { "2","4","5","6","8" } });
            Keys.Add(new PinKey() { Number = "6", NeighBours = new List<string>() { "3","5","6","9" } });
            Keys.Add(new PinKey() { Number = "7", NeighBours = new List<string>() { "4","7","8" } });
            Keys.Add(new PinKey() { Number = "8", NeighBours = new List<string>() { "5","7","8","9","0" } });
            Keys.Add(new PinKey() { Number = "9", NeighBours = new List<string>() { "6","8","9" } });
        }
        public List<string> GetCombination(string observed)
        {
            List<string> results = new List<string>();
            List<List<string>> allNeighbours = new List<List<string>>();
            foreach(char c in observed)
            {
                var curnum = c.ToString();
                var nb = Keys.First(c => c.Number == curnum).NeighBours;
                allNeighbours.Add(nb);
            }

            IEnumerable<string> combos = new[] { "" };

            foreach (var inner in allNeighbours)
            {
                combos = combos.SelectMany(r => inner.Select(x => r + x));
            }

            return combos.ToList();
        }
    }
    public class PinKey
    {
        public string? Number { get; set; }
        public List<string> NeighBours { get; set; } = new List<string>();
    }
}
