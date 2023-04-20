using System;
using System.Data;
using System.Net.Security;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace One_time_pad
{
    public class OneTimePad
    {
        public static byte[] textToBytes(string text)
        {
            byte[] bytes = new byte[text.Length * 2];
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                bytes[i * 2] = (byte)(c >> 8);
                bytes[i * 2 + 1] = (byte)c;
                //Console.WriteLine("textToBytes {0} = {1},{2}", Convert.ToString(c,2), Convert.ToString(bytes[i * 2],2), Convert.ToString(bytes[i * 2 + 1],2));
            }

            return bytes;
        }

        public static string bytesToText(byte[] bytes)
        {
            char[] charArray = new char[bytes.Length / 2];

            for (int i = 0;i < charArray.Length;i++)
            {
                //charArray[i] = (char)((bytes[i * 2] << 8) | (bytes[i * 2 + 1] & 0xFF));
                charArray[i] = (char)((bytes[i * 2] << 8) | (bytes[i * 2 + 1]));
                //Console.WriteLine("{0}={1}",charArray[i],(char)((bytes[i * 2] << 8) | (bytes[i * 2 + 1])));
            }

            return new string(charArray);
        }
        
    }
}