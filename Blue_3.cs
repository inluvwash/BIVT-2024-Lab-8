using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public Blue_3(string input) : base(input) { _output = null; }

        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;

                (char, double)[] copy = new (char, double)[_output.Length];

                Array.Copy(_output, copy, copy.Length);


                return copy;
            }
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            char[] s =  { ' ', '.', '!', '?', ',', ':', '"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            var words = Input.Split(s, StringSplitOptions.RemoveEmptyEntries);
                          

            int totalWords = 0;

            int[] charf = new int[char.MaxValue];
            

            foreach (string w in words)
            {
                if (w.Length == 0) continue;

                char initialChar = char.ToLower(w[0]);
                if (char.IsLetter(initialChar))
                {
                    charf[initialChar]++;
                    totalWords++;
                }
            }

            int distinctc = 0;
            for (int i = 0; i < charf.Length; i++)
            {
                if (charf[i] > 0) distinctc++;
            }

            _output = new (char Symbol, double Percentage)[distinctc];
            int currentIndex = 0;

            for (int i = 0; i < charf.Length; i++)
            {
                if (charf[i] > 0)
                {
                    double frequencyPercent = Math.Round(charf[i] * 100.0 / totalWords, 4);
                    _output[currentIndex++] = ((char)i, frequencyPercent);
                }
            }

            Array.Sort(_output, (first, second) =>
            {
                int f = second.Item2.CompareTo(first.Item2);
                return f != 0 ? f : first.Item1.CompareTo(second.Item1);;
            });



        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return "";

            var res = new StringBuilder();


            for (int i = 0; i < _output.Length; i++)
            {
                var elem = _output[i];

                res.Append($"{elem.Item1} - {elem.Item2:F4}");


                if (i < _output.Length - 1) res.AppendLine();

            }
            return res.ToString();
        }
    }
}