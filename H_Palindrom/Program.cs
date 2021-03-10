using System;
using System.Linq;

namespace Palindrom8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Text mit ggf. Palindrom?:");
            string text = Console.ReadLine();

            bool gotPalindrom = checkPalindrom(text);
            Console.WriteLine(gotPalindrom);
        }

        private static bool checkPalindrom(string text)
        {
            string[] toRemove = {",", ".", "!", ":", "?"};
            foreach (var c in toRemove)
            {
                if (text.IndexOf(c) != -1)
                {
                    text = text.Remove((text.IndexOf(c)), 1);
                }
            }
            text = text.Trim().ToUpper();
            
            char[] a = text.ToCharArray();
            char[] b = a;
            b.Reverse();

            if (a.Equals(b))
            {
                return true;
            }

            return false;
        }
    }
}