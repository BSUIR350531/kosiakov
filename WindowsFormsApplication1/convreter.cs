using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class converterClass
    {
        private int byte2 = 256;
        private int byte3 = 65536;
        private int byte4 = 16777216;
        private string errorMessage = "Cannot convert";
        public int byteToInt(byte[] bytes)
        {
            if (bytes.Length != 4)
            {
                throw new Exception(errorMessage);
            }
            return bytes[0] + bytes[1] * byte2 + bytes[2] * byte3 + bytes[3] * byte4;
        }
        public byte[] intToByte(int number)
        {
            if (number > 0)
            {
                int temp = number,
                    i;
                byte[] bytes= new byte[4];
                for(i = 0; i < 4; i++)
                {
                    bytes[i] = (byte)(temp % 256);
                    temp /= 256;
                }
                return bytes;
            } else
            {
                throw new Exception(errorMessage);
            }
        }
    }
}
