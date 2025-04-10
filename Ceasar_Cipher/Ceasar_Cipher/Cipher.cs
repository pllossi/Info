namespace Ceasar_Cipher
{
    public class Cipher
    {
        public string Enrc(string toEnrc,int shift)
        {
            if (string.IsNullOrEmpty(toEnrc))
            {
                throw new Exception("String is empty");
            }
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
            if(string.IsNullOrEmpty(toDecrypt))
            {
                throw new Exception("String is empty");
            }
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
