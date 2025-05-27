using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _series;
        public string Output => _output;
        public Blue_2(string input, string series) : base(input)
        {
            _output = null;
            _series = series;

        }



        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_series))
            {
                _output = string.Empty;
                return;
            }

          
            _output = Input;
            int i = 0;
            int length = _output.Length;
            int seriesLength = _series.Length;

            while (i < length)
            {
                while ( i< _output.Length && !char.IsLetter(_output[i]))
                {
                    i++;
                }

                if (i >= _output.Length) break;

                //  начало и конец слова
                int start = i;
                while (i < _output.Length &&
                      (char.IsLetter(_output[i]) ||
                      _output[i] == '\'' ||
                      _output[i] == '-'))
                {
                    i++;
                }
                int end = i - 1;

               
                string currentWord = _output.Substring(start, end - start + 1);
                if (currentWord.IndexOf(_series, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // delete слово и лишние пробелы
                    _output = _output.Remove(start, end - start + 1);

                    // delete пробел перед или после слова(если есть)
                    if (start > 0 && char.IsWhiteSpace(_output[start- 1]))
                    {
                        _output = _output.Remove(start- 1, 1);
                        i = start- 1;
                    }
                    else if (start < _output.Length && char.IsWhiteSpace(_output[start]))
                    {
                        _output = _output.Remove(start, 1);
                        i = start;
                    }
                    else
                    {
                        i = start;
                    }
                }
                else
                {
                    i = end + 1;
                }
            }

            // чистим повторяющиеся пробелы
            StringBuilder finalText = new StringBuilder();
            bool spaceFound = false;

            foreach (char symbol in _output)
            {
                if (char.IsWhiteSpace(symbol))
                {
                    if (!spaceFound)
                    {
                        finalText.Append(' ');
                        spaceFound = true;
                    }
                }
                else
                {
                    finalText.Append(symbol);
                    spaceFound = false;
                }
            }
            _output = finalText.ToString().Trim();
        
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output))
            {
                return string.Empty;
            }
               
            return _output;
        }
    }
}