namespace One_time_pad
{
    public class Caesar
    {
        private static char Cipher(char ch, int key) {      
            if (!char.IsLetter(ch)) {
                return ch;  //Повертає символ якщо він не є літерою
            }
            char d = char.IsUpper(ch) ? 'А' : 'а';  
            return (char)((((ch + key) - d) % 33) + d);  
            
        }
        public static string Encipher(string input, int key) {  
            string output = string.Empty;
            foreach(char ch in input)  
                output += Cipher(ch, key);
            return output;  
        }  
  
        public static string Decipher(string input, int key) {  
            return Encipher(input, 33 - key);  
        }  
    }
}