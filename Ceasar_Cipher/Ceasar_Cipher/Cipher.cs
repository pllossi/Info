namespace Ceasar_Cipher
{
    public class Cipher
    {
        public string Enrc(string toEnrc,int shift)
        {
            string Encript = "";
            foreach(char c in toEnrc)
            {
                char charact = (char)(c + shift);
                Encript += charact;
                
            }
            return Encript;
        }
        public string Decrypt(string toDecrypt, int shift)
        {
            string Decript = "";
            foreach (char c in toDecrypt)
            {
                char charact = (char)(c - shift);
                Decript += charact;
            }
            return Decript;
        }
    }
}
