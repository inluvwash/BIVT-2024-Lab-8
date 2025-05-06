using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;

        public int Output
        {
            get { return _output; }
        }

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            string currentNumber = "";
            bool inNumber = false;

            foreach (char c in Input)
            {
                if (IsDigit(c))
                {
                    currentNumber += c;
                    inNumber = true;
                }
                else if (inNumber)
                {
                    if (currentNumber.Length > 0)
                    {
                        _output += ConvertNumber(currentNumber);
                        currentNumber = "";
                    }
                    inNumber = false;
                }
                else
                {
                    inNumber = false;
                }
            }

            if (inNumber && currentNumber.Length > 0)
            {
                _output += ConvertNumber(currentNumber);
            }
        }

        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private int ConvertNumber(string numStr)
        {
            int result = 0;
            foreach (char c in numStr)
            {
                result = result * 10 + (c - '0');
            }
            return result;
        }

        public override string ToString()
        {
            return $"{_output}";
        }
    }
}
