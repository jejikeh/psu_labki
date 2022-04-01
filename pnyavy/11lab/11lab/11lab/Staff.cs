using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11lab
{
    class Staff
    {
        private string _name;
        private int    _number;
        private int    _rank;

        public Staff(string name)
        {
            _name = name;
        }
        public Staff(int number, int rank)
        {
            _name = "";
            _number = number;
            _rank = rank;
        }
        public Staff(string name, int number, int rank)
        {
            _name = name;
            _number = number;
            _rank = rank;
        }
        public Staff()
        {
            Console.WriteLine("Input name ->");
            string? name = Console.ReadLine();
            Console.WriteLine("Input number ->");
            int number = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Input rank ->");
            int rank = Convert.ToInt16(Console.ReadLine());
            if(name != null)
            {
                _name = name;
                _number = number;
                _rank = rank;
            }

        }
        public void SetName()
        {
           string? name = Console.ReadLine();
            if (name != null)
            {
                _name = name;
            } 
        }
        public void Print()
        {
            Console.WriteLine("Name : " + _name);
            Console.WriteLine("Number : " + _number);
            Console.WriteLine("Rank : " + _rank);
        }
    }
}
