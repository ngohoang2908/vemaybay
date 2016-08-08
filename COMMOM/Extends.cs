using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMMOM
{
    public class Extends
    {
        static Random rand = new Random();
        public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }

        public static string SubString(string str, int size)
        {
            if (str.Length > size)
            {
                string rs = str.Substring(0, size);
                return rs.Substring(0, rs.LastIndexOf(' ')) + "Content/themes/Admin.";
            }
            else
                return str;
        }

        public static string GenerateRandomPassword(int length)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
            char[] chars = new char[length];
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }
    }
}
