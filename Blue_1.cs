﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;

        public string[] Output
        {
            get
            {
                if (_output == null) return null;

                string[] copy = new string[_output.Length];

                Array.Copy(_output, copy, _output.Length);


                return copy;
            }
        }
        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        

        public override void Review()
        {
            if (String.IsNullOrEmpty(Input)) return;

            var words = Input.Split(' ');
            string[] temp = new string[500];
            int lineCount = 0;
            var currentLine = new StringBuilder();

            foreach (var word in words)
            {
                if (currentLine.Length + word.Length + 1 <= 50)
                {
                    if (currentLine.Length > 0) currentLine.Append(' ');
                    
                    currentLine.Append(word);
                }
                else
                {
                    temp[lineCount] = currentLine.ToString();


                    lineCount++;

                    currentLine.Clear();
                    currentLine.Append(word);
                }
            }

            if (currentLine.Length > 0)
            {
                temp[lineCount] = currentLine.ToString();
                lineCount++;
            }

            Array.Resize(ref temp, lineCount);
            _output = temp;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
                

            return string.Join(Environment.NewLine, _output);
        }
    }
}