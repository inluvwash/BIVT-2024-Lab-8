using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output = string.Empty;
        private string _series;

        public Blue_2(string input, string series) : base(input)
        {
            _output = null;
            _series = series;
            
        }

        public string Output => _output;

        public override void Review()
        {
            _output = ""; 

            if (Input == null || Input.Length == 0)
                return;

            string current = "";
            bool wordValid = true;
            bool first = true;

            for (int i = 0; i < Input.Length; i++)
            {
                char c = Input[i];

                if (c == ' ')
                {
                    if (current.Length > 0 && wordValid)
                    {
                        if (!first)
                            _output += " ";
                        _output += current;
                        first = false;
                    }

                    current = "";
                    wordValid = true;
                    continue;
                }

                current += c;

                if (wordValid && _series.Length > 0)
                {
                    bool match = true;
                    for (int j = 0; j < _series.Length; j++)
                    {
                        if (i + j >= Input.Length || Input[i + j] != _series[j])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                        wordValid = false;
                }
            }

            if (current.Length > 0 && wordValid)
            {
                if (!first)
                    _output += " ";
                _output += current;
            }
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
