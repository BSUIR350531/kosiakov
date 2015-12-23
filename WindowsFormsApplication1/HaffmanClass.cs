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
                //read byte from file
                byte readByte = (byte)readStream.ReadByte();
                //add it to hte input list
                input.Add(readByte);
                //increment counter for this byte in occurances table
                if (symbolOccurrences.ContainsKey(readByte))
                {
                    symbolOccurrences[readByte]++;
                } else
                {
                    symbolOccurrences.Add(readByte, 1);
                }
            }
            //close file
            readStream.Close();
            
            //2) write length of occurances and occurances to output file: create functions for convertion int to byte and back
            FileStream writeStream = new FileStream(writeFile, FileMode.Create, FileAccess.Write);
            //write occurances length
            //convert size of table to bytes and write those bytes to output file
            byte[] countInByte = convert.intToByte(symbolOccurrences.Count);
            for (i = 0; i < 4; i++)
            {
                writeStream.WriteByte(countInByte[i]);
            }
            //write occurances
            foreach (var occur in symbolOccurrences)
            {
                //write occurance to output file
                writeStream.WriteByte(occur.Key);
                //convert amount of occurances fot the bytes and write to file
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
            //use stringBuilder to create output string for writting to file
            StringBuilder resultString = new StringBuilder("");
            len = input.Count;
            for (i = 0; i < len; i++)
            {
                resultString.Append(codes[input[i]].ToString());
            }
            
            //5) write symbol's code to output file
            //write to file size of last row
            writeStream.WriteByte(Convert.ToByte(resultString.Length % 8));
            len = resultString.Length;
            writeByte = 0;
            j = 0;
            pow = 1;
            //write output string using easy logic
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
                    writeByte = 0;
                } else
                {
                    pow *= 2;
                }
                j = (j + 1) % 8;
            }
            //if last row not full -> write last byte
            if(resultString.Length % 8 != 0)
            {
                writeStream.WriteByte(writeByte);
            }
            //close output file
            writeStream.Close();
        }

        public void Unzip(string readFile, string writeFile)
        {
            byte[] byteArr = new byte[4];
            byte tableKey;
            int i, j, tableSize;
            long len = 4;


            //1) read file, length of occurances and fill up occurances
            FileStream readStream = new FileStream(readFile, FileMode.Open, FileAccess.Read);
            //create occurances table
            Dictionary<byte, int> symbolOccurrences = new Dictionary<byte, int>();
            //read 4 byte in conver it to occurance table size
            for (i = 0; i < len; i++)
            {
                byteArr[i] = (byte)readStream.ReadByte();
            }
            tableSize = convert.byteToInt(byteArr);

            byteArr = new byte[4];
            //read bytes  and fill up occurances table
            for (i = 0; i < tableSize; i++)
            {
                //read key first
                tableKey = (byte)readStream.ReadByte();
                //then read 4 bytes and covert it to int(amount of accorances)
                for  (j = 0; j < len; j++)
                {
                    byteArr[j] = (byte)readStream.ReadByte();
                }
                symbolOccurrences.Add(tableKey, convert.byteToInt(byteArr));
            }

            //2) create tree using occurances and then recognize file text
            TreeClass tree = TreeClass.createTree(symbolOccurrences);
            //read last row length from file
            byte lastRow = (byte)readStream.ReadByte();
            //calculate table size: file length - 4Bytes(table size) - 1Byte(length last row) - 5* table size(1Byte key + 4Bytes occurances)
            len = readStream.Length - 1 - 4 - tableSize * 5;
            //create stringBuilder to fill up all text
            StringBuilder input = new StringBuilder("");
            //use easy logic for reading text
            for (i = 0; i < len; i++)
            {
                tableKey = (byte)readStream.ReadByte();
                if (i == (readStream.Length - 2) && lastRow != 0)
                {
                    for (j = 0; j <= lastRow; j++)
                    {
                        input.Append((tableKey % 2).ToString());
                        tableKey /= 2;
                    }
                } else
                {
                    for (j = 0; j < 8; j++)
                    {
                        input.Append((tableKey % 2).ToString());
                        tableKey /= 2;
                    }
                }
            }
            //close file
            readStream.Close();

            //3) write to output file
            //parse text to get bytes of original text
            List<byte> text = tree.getByteText(input.ToString());
            //open output file for writting
            FileStream writeStream = new FileStream(writeFile, FileMode.Create, FileAccess.Write);
            //write original bytes to it
            writeStream.Write(text.ToArray(), 0, text.Count);
            //close output file
            writeStream.Close();
        }
    }
}
