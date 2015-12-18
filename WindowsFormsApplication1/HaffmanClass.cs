using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication1
{

    class HaffmanClass
    {
        public void Zip(string readFile, string writeFile)
        {
            //vars
            int i; 
            long len;

            //1) read file and fill up occurances

            //open file for reading
            FileStream readStream = new FileStream(readFile, FileMode.Open, FileAccess.Read);

            //fill up occurance of elements dictionary
            Dictionary<byte, int> symbolOccurrences = new Dictionary<byte, int>();
            List<byte> input = new List<byte>();
            len = readStream.Length;
            for (i = 0; i < len; i++)
            {
                byte readByte = (byte)readStream.ReadByte();
                input.Add(readByte);
                if (symbolOccurrences.ContainsKey(readByte))
                {
                    symbolOccurrences[readByte]++;
                } else
                {
                    symbolOccurrences.Add(readByte, 1);
                }
            }
            readStream.Close();

            //2) write length of occurances and occurances to output file: create functions for convertion int to byte and back

            //3) create tree from occurances: create Tree class

            //4) create code for each element from occurance dictionary

            //5) write symbol's code to output file

        }

        public void Unzip(string readFile, string writeFile)
        {
            //1) read file, length of occurances and fill up occurances
            //2) create tree using occurances and then recognize file text
            //3) write to output file
        }
    }
}
