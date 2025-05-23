﻿namespace Ceasar_Cipher
{
    public class Cipher
    {
        public string Enrc(string toEnrc, int shift)
        {
            if (string.IsNullOrEmpty(toEnrc))
            {
                throw new Exception("String is empty");
            }
            string Encript = "";
            shift = (shift % 26 + 26) % 26; 
            foreach (char c in toEnrc)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char charact = (char)(((c - offset + shift) % 26) + offset);
                    Encript += charact;
                }
                else if (char.IsNumber(c))
                {
                    int number = (int)char.GetNumericValue(c);
                    int newNumber = (number + shift) % 10;
                    Encript += newNumber.ToString();
                } else
                {
                       Encript += c;
                }
                
            }
            return Encript;
        }
        public string Decrypt(string toDecrypt, int shift)
        {
            if (string.IsNullOrEmpty(toDecrypt))
            {
                throw new Exception("String is empty");
            }
            string Decript = "";
            shift = (shift % 26 + 26) % 26; 
            foreach (char c in toDecrypt)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char charact = (char)(((c - offset - shift + 26) % 26) + offset);
                    Decript += charact;
                }
                else if (char.IsNumber(c))
                {
                    int number = (int)char.GetNumericValue(c);
                    int newNumber = (Math.Abs(number - shift)) % 10;
                    Decript += newNumber.ToString();
                } else
                {
                       Decript += c;
                }
                
            }
            return Decript;
        }
    }
}
