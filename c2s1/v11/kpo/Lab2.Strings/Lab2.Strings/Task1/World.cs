using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabL
{
    internal static class Predefined
    {
        internal static string Vowels = "aoyeiu" ;
    }

    internal struct World
    {
        public string Text;
        public int Vowels = 0;
        public string VowelsString = String.Empty;


        public World(string text)
        {
            Text = text;
            Vowels = CountVowels();
        }

        private int CountVowels()
        {
            int c = 0;
            foreach(char ch in Text.Where(x => Predefined.Vowels.Contains(x)))
            {
                c++;
                VowelsString += ch;
            }

            return c;
        }
    }
}
