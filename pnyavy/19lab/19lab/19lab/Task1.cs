using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19lab
{
    class UnsignedClass<T>
    {
        private UInt16 _value;
        public UInt16 Value { get { return _value; } }

        public UnsignedClass(T value)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                _value = Convert.ToUInt16(value);
            }
            catch (Exception ex)
            {
                new Menu().DrawError(ex.Message);

            }
        }

        public static UInt16 operator +(UnsignedClass<T> a) => a._value;

        public static FloatClass<UInt16> operator -(UnsignedClass<T> a) => new FloatClass<UInt16>(a._value);
    }

    class FloatClass<T>
    {
        private float _value;
        public float Value { get { return _value; } }

        public FloatClass(T value)
        {
            try
            {
                if (value?.ToString() != null)
                {
                    #pragma warning disable CS8604 // Possible null reference argument.
                    _value = float.Parse(value.ToString());
                    #pragma warning restore CS8604 // Possible null reference argument.
                }

            }
            catch (Exception ex)
            {
                new Menu().DrawError(ex.Message);
            }
        }

        public static UnsignedClass<float> operator -(FloatClass<T> a) => new UnsignedClass<float>(a._value);
    }
    class Task1
    {
        public void DrawTask()
        {

            Menu menu = new Menu();
            menu.DrawHeader("Task 1",ConsoleColor.Green);

            menu.DrawLine("Input a number");
            menu.PrepareForInput(ConsoleColor.Green);
            string? userInput = Console.ReadLine();

            if (userInput != null)
            {
                UnsignedClass<string> unsignedNode = new UnsignedClass<string>(userInput);
                UInt16 n = +unsignedNode;

                menu.DrawLine("\n\tConvert from class to UInt16\n");

                menu.DrawOutput($"Instance of {unsignedNode.GetType().Name}, value : {unsignedNode.Value}", "Output");
                menu.DrawOutput($"Instance of {n.GetType().Name}, value : {n}","Output");
            }

            menu.DrawLine("Input a number");
            menu.PrepareForInput(ConsoleColor.Green);
            userInput = Console.ReadLine();
            if (userInput != null)
            {
                FloatClass<int> floatNode = new FloatClass<int>(Convert.ToUInt16(userInput));
                UnsignedClass<float> n2 = -floatNode;

                menu.DrawLine("\n\tConvert from FloatClass to UnsignedClass\n");

                menu.DrawOutput($"Instance of {floatNode.GetType().Name}, value : {floatNode.Value}", "Output");
                menu.DrawOutput($"Instance of {n2.GetType().Name}, value : {n2.Value}", "Output");
            }

            menu.DrawEnd();
        }
    }
}
