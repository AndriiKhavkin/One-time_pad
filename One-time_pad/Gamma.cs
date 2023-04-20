using System;
using  System.Security.Cryptography;

namespace One_time_pad
{
    public class Gamma
    {
        private static string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя 0123456789";
        
        
        private static Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public static string GetKey()
        {
            string key="";
            for (int i = 0; i < alphabet.Length; i++)
            {
                int value = rnd.Next(0,alphabet.Length);
                key += alphabet[value];
            }
            Console.WriteLine(key);  
            return key;
        }
        
        public static string GammaCipher(string data, string key)
        {
            int dataLen = data.Length;
            int keyLen = key.Length;
            char[] output = new char[dataLen];

            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(data[i] ^ key[i % keyLen]);
            }

            return new string(output);
        }
    }
}