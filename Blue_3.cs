using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public Blue_3(string input) : base(input) { _output = null; }

        public (char, double)[] Output => _output;

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = Array.Empty<(char, double)>();
                return;
            }



            var separators = new[] { ' ', '.', '!', '?', ',', ':', '"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            var words = Input.Split(separators)
                           .Where(w => !string.IsNullOrEmpty(w) && char.IsLetter(w[0]))
                           .Select(w => w.ToLower());

            int totalWords = words.Count();
            if (totalWords == 0)
            {
                _output = Array.Empty<(char, double)>();
                return;
            }

            var letterGroups = words.GroupBy(w => w[0])
                                  .Select(g => new
                                  {
                                      Letter = g.Key,
                                      Count = g.Count(),
                                      Percentage = Math.Round(g.Count() * 100.0 / totalWords, 4)
                                  })
                                  .OrderByDescending(x => x.Percentage)
                                  .ThenBy(x => x.Letter)
                                  .Distinct();//  для устранения дубликатов

            _output = letterGroups.Select(x => (x.Letter, x.Percentage)).ToArray();
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return "";

            return string.Join("\n", _output.Select(x => $"{x.Item1} - {x.Item2:F4}")) + "\n";
        }
    }
}