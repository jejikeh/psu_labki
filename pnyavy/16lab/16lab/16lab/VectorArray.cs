using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16lab
{
    /*
     * 
     * Class Node
     * 
     */

    abstract class AbstractNode // Абстрактный класс узла
    {
        // Поле значения
        public int Value;
        // Поле индекса
        public int Index;

        public int GetValue { get {  return Value; } }
        // Метод вывода с реализацией
        public void Print()
        {
            Console.WriteLine("Value -> " + Value + " at " + Index + " index");
        }

        // Абстрактный метод добавления значения без реализации
        public abstract void Add(int value);
    }

    class Node : AbstractNode // Узел
    {
        public Node(int value, int index)
        {
            Value = value;
            Index = index;
        }

        public override void Add(int value) // Добавление значения к узлу
        {
            Value += value;
        }
        
    }

    /*
     * 
     * Class Array
     * 
     */

    abstract class AbstractVectorArray // 
    {
        public int CurrentSize = -1;
        public abstract int GetMaxSize { get; set; } //  Автосвойство
        public Node[] Node_Array;

        public void Add(int value)
        {
            CurrentSize++;
            if (CurrentSize < GetMaxSize) 
            {
                Node_Array[CurrentSize] = new Node(value, CurrentSize); // Новый узел
            }
            else
            {
                Console.WriteLine("Max Size");
                System.Environment.Exit(0); // Если масссив переполнен
            }
        }

        public Node? Root()
        {
            if(Node_Array?[0] != null) // (?) сокращенное условие Node_array != null ? true : false 
            {
                return Node_Array[0];
            }else
            {
                return null;
            }
        }

        public void PrintAll() // Вывод всех элементов
        {
            for (int i = 0; i <= CurrentSize; i++)
            {
                Node_Array?[i].Print();
            }
        }
        public void PrintNode(Node? node) // Вывод определенного узла
        {
            node?.Print();
        }
        public void PrintByIndex(int index) // Вывод определенного элемента по индексу
        {
            if (index <= CurrentSize) // Если номер искомого элемента не выходит за рамки размера массива
            {
                Node_Array?[index].Print();
            }
            else
            {
                Console.WriteLine("Big number");
            }
        }

        public void CheckEqual() // Проверка на неравенство
        {
            int repeatedTimes = 0;
            for (int i = 0; i <= CurrentSize; i++)
            {
                for (int l = 0; l <= CurrentSize; l++)
                {
                    if (Node_Array?[i].GetValue == Node_Array?[l].GetValue)
                    {
                        repeatedTimes++; // Считаем сколько раз каждый элемент повторяется в массиве
                    }

                }
                if (repeatedTimes == 1)
                {
                    Console.WriteLine(Node_Array?[i].GetValue + " non equal");
                }
                repeatedTimes = 0;
            }
        }

        // Абстрактная функция добавления значения элементов
        abstract public void AddValueToAll(int value);
    }

    class VectorArray : AbstractVectorArray // Класс массива
    {
        private int _maxSize;
        
        public override int GetMaxSize // Автосвойство доступа к приватному полю _maxSize
        {
            get => _maxSize;
            set => _maxSize = value;
        }
        
        public VectorArray(int maxSizeOfArray) // Конструктор массива
        {
            Node_Array = new Node[maxSizeOfArray];
            _maxSize = maxSizeOfArray;
        }


        public override void AddValueToAll(int value) // Реализация абстрактного метода
        {
            for (int i = 0; i <= CurrentSize; i++) // прибавление значение к каждому элементу
            {
                Node_Array[i].Add(value);
            }
        }

    }
}
