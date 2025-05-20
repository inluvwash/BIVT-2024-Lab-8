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
        public string Output => _output;
        public Blue_2(string input, string series) : base(input)
        {
            _output = null;
            _series = series;

        }



        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = string.Empty;
                return;
            }

            var result = new StringBuilder();
            int i = 0;
            int length = Input.Length;
            int seriesLength = _series.Length;

            while (i < length)
            {
                //нужно ли удалять подстроку
                if (seriesLength > 0 && i <= length - seriesLength &&
                    Input.Substring(i, seriesLength) == _series)
                {
                    i += seriesLength; //пропускаем подстроку
                    continue;
                }

                char currentChar = Input[i];

                //обработка запятых в числах
                if (currentChar == ',' && i > 0 && char.IsDigit(Input[i - 1]))
                {
                    result.Append(currentChar);
                    i++;

                    // пропуск пробел после запятой в числе(ну если он есть)
                    if (i < length && Input[i] == ' ')
                        i++;
                    continue;
                }

                //basic символы
                result.Append(currentChar);
                i++;
            }

            _output = result.ToString();
        }

        public override string ToString()
        {
            return _output;
        }
    }
}