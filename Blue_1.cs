using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        public string[] Output => _output;

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] words = Input.Split(' ');
            string[] temp = new string[words.Length];
            int lineCount = 0;
            string currentLine = "";

            foreach (string word in words)
            {
                if (word == "")
                    continue;

                if (currentLine == "")
                {
                    currentLine = word;
                }
                else if (currentLine.Length + 1 + word.Length <= 50)
                {
                    currentLine += " " + word;
                }
                else
                {
                    temp[lineCount] = currentLine;
                    lineCount++;
                    currentLine = word;
                }
            }

            if (currentLine != "")
            {
                temp[lineCount] = currentLine;
                lineCount++;
            }

            _output = new string[lineCount];
            for (int i = 0; i < lineCount; i++)
            {
                _output[i] = temp[i];
            }
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            return string.Join(Environment.NewLine, _output);
        }
    }
}