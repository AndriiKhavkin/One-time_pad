using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace One_time_pad
{
    internal class Program
    { 
        public static void Main()
        {
            Stopwatch clockCaesar = new Stopwatch();
            Stopwatch clockGamma = new Stopwatch();
            Stopwatch clockOTP = new Stopwatch();
        
            string message = "Слово – найтонший дотик до серця; воно може стати і ніжною запашною квіткою, і живою водою, що повертає віру в добро, і гострим ножем, і розпеченим залізом, і брудом. Василь СУХОМЛИНСЬКИЙ";
            Console.WriteLine("Your string to encrypt is: " + message);  
  
            Console.WriteLine("\nEnter your Key:");  
            int keyCaesar = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("\nGenerating your Key for Gamma Cipher:");
            string keyGamma = Gamma.GetKey();
            
            string keyOTP = "110000 011110 010100 110010 010110 011110";
            Console.WriteLine("\nYour Key for One Time Pad Cipher: " + keyOTP);


           //Caesar
            clockCaesar.Start();
            string cipherText = Caesar.Encipher(message, keyCaesar);
            string decryptedText = Caesar.Decipher(cipherText, keyCaesar); 
            clockCaesar.Stop();
            
            Console.WriteLine("\nEncrypted Data for Caesar\n"); 
            Console.WriteLine(cipherText);  
            
            Console.WriteLine("\nDecrypted Data:\n");
            Console.WriteLine(decryptedText); 
            
            Console.WriteLine("Time spent for caesar cypher: " + clockCaesar.Elapsed);
            
            //Gamma
            clockGamma.Start();
            string cipherText2 = Gamma.GammaCipher(message, keyGamma);
            string decryptedText2 = Gamma.GammaCipher(cipherText2, keyGamma);  
            clockGamma.Stop();
            
            Console.WriteLine("\nEncrypted Data for Gamma\n"); 
            Console.WriteLine(cipherText2);
            Console.WriteLine("\nDecrypted Data:\n");
            Console.WriteLine(decryptedText2); 
            
            Console.WriteLine("Time spent for gamma cypher: " + clockGamma.Elapsed);
            
            
            //One time pad
            clockOTP.Start();
            string[] keyStrings = keyOTP.Split(' ');
            byte[] keyBytes = new byte[keyStrings.Length];
            for (int i = 0; i < keyStrings.Length; i++)
            {
                byte keyByte = Convert.ToByte(keyStrings[i], 2);
              keyBytes[i] = keyByte;
            }
            //
            byte[] messageBytes = OneTimePad.textToBytes(message);
            byte[] encryptedBytes = new byte[messageBytes.Length];
            for (int i = 0; i < messageBytes.Length; i += 1)
            {
                int keyIndex = i % keyBytes.Length;
            //  byte keyByte = keyBytes[keyIndex];
            //  byte messageByte = messageBytes[i];
            encryptedBytes[i] = (byte)(messageBytes[i] ^ keyBytes[keyIndex]);
            //Console.WriteLine("keyindex = {0}, keybyte={1}, messageByte={2}, encryptedByte={3}", keyIndex, Convert.ToString(keyBytes[keyIndex],2), Convert.ToString(messageBytes[i],2), Convert.ToString(encryptedBytes[i],2));
            }
            //Console.WriteLine(OneTimePad.bytesToText(messageBytes));
            string encryptedMessage = OneTimePad.bytesToText(encryptedBytes);
            Console.WriteLine("\nEncrypted message for One Time Pad: " + encryptedMessage);
            byte[] decryptedBytes = new byte[encryptedBytes.Length];
            for (int i = 0; i < messageBytes.Length; i += 1)
            {
                int keyIndex = i % keyBytes.Length;
                // Console.WriteLine("keyindex = {0}, keybyte={1}",keyIndex, keyBytes[keyIndex]);
                byte keyByte = keyBytes[keyIndex];
                byte messageByte = encryptedBytes[i];
                // Console.WriteLine("keyindex = {0}, keybyte={1}, messageByte={2}", keyIndex, keyBytes[keyIndex], messageBytes[i]);
                //Console.WriteLine( Convert.ToString(i), Convert.ToString(messageBytes[i], 2), Convert.ToString(keyByte,2));
                decryptedBytes[i] = (byte)(encryptedBytes[i] ^ keyBytes[keyIndex]);
                // Console.WriteLine("keyindex = {0}, keybyte={1}, decryptedByte={2}, encryptedByte={3}", keyIndex, Convert.ToString(keyBytes[keyIndex], 2), Convert.ToString(decryptedBytes[i], 2), Convert.ToString(encryptedBytes[i], 2));
            }

            string decryptedMessage = OneTimePad.bytesToText(decryptedBytes);
            Console.WriteLine("Decrypted message: " + decryptedMessage);
            clockOTP.Stop();
            
            Console.WriteLine("Time spent for One Time Pad cypher: " + clockOTP.Elapsed);
            
            Console.ReadKey();  
            Console.ReadKey(); 
        }
    }
}