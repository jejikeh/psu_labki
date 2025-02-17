﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13lab
{
    class SienceApp : Application
    {
        private string _field_of;
        private int _cost;
        private bool _paralel_calculations;

        public SienceApp(string field_of, int cost, bool paralel_calculations, string developer, int version, int year) : base(developer, version, year)
        {
            _field_of = field_of;
            _cost = cost;
            _paralel_calculations = paralel_calculations;
        }

        override internal protected void PrintAll()
        {
            Console.WriteLine($"Cost {_cost}");
            Console.WriteLine($"Field {_field_of}");
            Console.WriteLine($"Paralel calculations of {_paralel_calculations}");
        }
    }
}
