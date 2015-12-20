﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication1
{

    class HaffmanClass
    {
        private converterClass convert = new converterClass();
        public void Zip(string readFile, string writeFile)
        {
            //vars
            int i, j;
            byte writeByte, pow;
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
            FileStream writeStream = new FileStream(writeFile, FileMode.Create, FileAccess.Write);
            //write occurances length
            byte[] countInByte = convert.intToByte(symbolOccurrences.Count);
            for (i = 0; i < 4; i++)
            {
                writeStream.WriteByte(countInByte[i]);
            }
            //write occurances
            foreach (var occur in symbolOccurrences)
            {
                writeStream.WriteByte(occur.Key);
                byte[] occurInByte = convert.intToByte(occur.Value);
                for (i = 0; i < 4; i++)
                {
                    writeStream.WriteByte(occurInByte[i]);
                }
            }

            //3) create tree from occurances: create Tree class
            TreeClass tree = TreeClass.createTree(symbolOccurrences);

            //4) create code for each element from occurance dictionary
            Dictionary<byte, string> codes = tree.getByteCodeTable();
            StringBuilder resultString = new StringBuilder("");
            len = input.Count;
            for (i = 0; i < len; i++)
            {
                resultString.Append(codes[input[i]].ToString());
            }
            //5) write symbol's code to output file
            writeStream.WriteByte(Convert.ToByte(resultString.Length % 8));
            len = resultString.Length;
            writeByte = 0;
            j = 0;
            pow = 1;
            for (i = 0; i < len; i++)
            {
                if(resultString[i] == '1')
                {
                    writeByte += pow;
                }
                if(j == 7)
                {
                    writeStream.WriteByte(writeByte);
                    pow = 1;
                    writeByte = 1;
                } else
                {
                    pow *= 2;
                }
                j = (j + 1) % 8;
            }
            if(resultString.Length % 8 != 0)
            {
                writeStream.WriteByte(writeByte);
            }
            writeStream.Close();
        }

        public void Unzip(string readFile, string writeFile)
        {
            byte[] byteArr = new byte[4];
            byte tableKey;
            int i, j, len = 4, tableSize;


            //1) read file, length of occurances and fill up occurances
            FileStream readStream = new FileStream(readFile, FileMode.Open, FileAccess.Read);

            Dictionary<byte, int> symbolOccurrences = new Dictionary<byte, int>();
            for (i = 0; i < len; i++)
            {
                byteArr[i] = (byte)readStream.ReadByte();
            }
            tableSize = convert.byteToInt(byteArr);

            byteArr = new byte[4];
            for (i = 0; i < tableSize; i++)
            {
                tableKey = (byte)readStream.ReadByte();
                for  (j = 0; j < len; j++)
                {
                    byteArr[j] = (byte)readStream.ReadByte();
                }
                symbolOccurrences.Add(tableKey, convert.byteToInt(byteArr));
            }
            //2) create tree using occurances and then recognize file text
            TreeClass tree = TreeClass.createTree(symbolOccurrences);
            //3) write to output file
        }
    }
}
