namespace _21lab
{
    struct UserType
    {
        public int CustomInt1;
        public int CustomInt2;
        public UserType(int customInt1, int customInt2)
        {
            CustomInt1 = customInt1;
            CustomInt2 = customInt2;
        }

    }
    class Program
    {
        static void Main()
        {
            // 1 APP

            // 1 task
            List<int> container = new List<int>();
            Random random = new Random();

            for (int i = 0; i < random.Next(100); i++)
            {
                container.Add(random.Next(100));
            }


            // 2 task
            Console.WriteLine("2 task \nContainer : ");
            container.ForEach( x => Console.WriteLine(x));

            // 3 task
            Console.WriteLine("3 task \nContainer : ");
            container[random.Next(container.Count)] = random.Next(100); // replace random node
            container.Remove(container[random.Next(container.Count)]); // remove random node
            container.ForEach(x => Console.WriteLine(x));

            // 4 task
            Console.WriteLine("4 task \nContainer : ");
            for (int i = 0; i < container.Count; i++)
            {
                Console.WriteLine(container[i]);
            }

            // 5 task
            List<int> containerNew = new List<int>();

            for (int i = 0; i < random.Next(20); i++)
            {
                containerNew.Add(random.Next(100));
            }

            // 6 task
            int startIndex = random.Next(container.Count); // random start index
            int lastsIndexs = container.Count - startIndex; // how many nodes from left
            for (int i = startIndex; i < startIndex + random.Next(lastsIndexs)-1; i++)
            {
                container.RemoveAt(i);
            }

            containerNew.ForEach(x => container.Add(x)); // add 2 container to 1

            Console.WriteLine("6 task \n1 Container : ");
            container.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("6 task \n2 Container : ");
            containerNew.ForEach(x => Console.WriteLine(x));



            // 2 APP

            List<UserType> userTypes = new List<UserType>();

            // 1 task

            for (int i = 0; i < random.Next(100); i++)
            {
                userTypes.Add(new UserType(random.Next(100), random.Next(100)));
            }

            // 2 task
            Console.WriteLine("2 task \nContainer : ");
            userTypes.ForEach(x => Console.WriteLine($"{x.CustomInt1} , {x.CustomInt2}"));

            // 3 task
            Console.WriteLine("3 task \nContainer : ");
            userTypes[random.Next(userTypes.Count)] = new UserType(random.Next(100),random.Next(100)); // replace random node
            userTypes.Remove(userTypes[random.Next(userTypes.Count)]); // remove random node
            userTypes.ForEach(x => Console.WriteLine($"{x.CustomInt1} , {x.CustomInt2}"));

            // 4 task
            Console.WriteLine("4 task \nContainer : ");
            for (int i = 0; i < userTypes.Count; i++)
            {
                Console.WriteLine($"{userTypes[i].CustomInt1} , {userTypes[i].CustomInt2}");
            }

            // 5 task
            List<UserType> userTypesNew = new List<UserType>();

            for (int i = 0; i < random.Next(20); i++)
            {
                userTypesNew.Add(new UserType(random.Next(100), random.Next(100)));
            }

            // 6 task
            startIndex = random.Next(userTypes.Count); // random start index
            lastsIndexs = userTypes.Count - startIndex; // how many nodes from left
            for (int i = startIndex; i < startIndex + random.Next(lastsIndexs); i++)
            {
                userTypes.RemoveAt(i);
            }

            userTypesNew.ForEach(x => userTypes.Add(x)); // add 2 container to 1

            Console.WriteLine("6 task \n1 Container : ");
            userTypes.ForEach(x => Console.WriteLine($"{x.CustomInt1} , {x.CustomInt2}"));
            Console.WriteLine("6 task \n2 Container : ");
            userTypesNew.ForEach(x => Console.WriteLine($"{x.CustomInt1} , {x.CustomInt2}"));


            // 3 APP

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n ----------------- 3 APP -----------------\n");
            Dictionary<int,int> l1 = new Dictionary<int,int>();
            Dictionary<int,int> l2 = new Dictionary<int,int>();
            Dictionary<int,int> l3 = new Dictionary<int, int>();

            // 1 task

            for (int i = 0; i < random.Next(100); i++)
            {
                int rIndex = random.Next(100);
                while (l1.ContainsKey(rIndex))
                {
                    rIndex = random.Next(100);
                }
                l1.Add(rIndex, random.Next(100));
            }


            // 3 task
            l1 = l1.OrderBy(key => key.Key).ToDictionary(x => x.Key, x=>x.Value);

            l1 = l1.Reverse().ToDictionary(x => x.Key, x=>x.Value);

            // 4 task
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n REVESRE SORT MAP \n");
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var node in l1)
            {
                Console.WriteLine($"    LIST 1 : Key : {node.Key} , Value : {node.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n ----------------------- \n");


            // 5 and 6 task
            int sort = random.Next(100);
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\nADD TO L2 NODES THAT node.Value LESS THAN {sort} :\n");
            foreach(var node in l1)
            {
                if(node.Value < sort)
                {
                    l2.Add(node.Key,node.Value);
                }
            }


            // 7 task
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var node in l2)
            {
                Console.WriteLine($"    Key : {node.Key} , Value : {node.Value}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n ----------------------- \n");

            // 8 task
            l1 = l1.OrderBy(key => key.Key).ToDictionary(x => x.Key, x => x.Value);
            l2 = l2.OrderBy(key => key.Key).ToDictionary(x => x.Key, x => x.Value);

            // 9 task

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\nSORTED 1 LIST \n");
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var node in l1)
            {
                Console.WriteLine($"    Key : {node.Key} , Value : {node.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n --- \n");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\nSORTED 2 LIST \n");
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var node in l2)
            {
                Console.WriteLine($"    Key : {node.Key} , Value : {node.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n ----------------------- \n");


            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\n3 LIST \n");

            // 10 task
            foreach (var node1 in l1)
            {
                if (l3.ContainsKey(node1.Key))
                {
                    int key1 = node1.Key;
                    while (l3.ContainsKey(key1))
                    {
                        key1++;
                    }
                    l3.Add(key1, node1.Value);
                }else
                {
                    l3.Add(node1.Key, node1.Value);
                }
            }
            foreach (var node2 in l2)
            {
                if (l3.ContainsKey(node2.Key))
                {
                    int key2 = node2.Key;
                    while (l3.ContainsKey(key2))
                    {
                        key2++;
                    }
                    l3.Add(key2, node2.Value);
                }else
                {
                    l3.Add(node2.Key, node2.Value);
                }
            }

            // 11 task
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var node in l3)
            {
                Console.WriteLine($"    Key : {node.Key} , Value : {node.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n ----------------------- \n");

            // 12 and 13 task

            sort = random.Next(100);
            int n = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\n Count NODES THAT node.Value LESS THAN {sort} IN 3 LIST:\n");
            foreach (var node in l3)
            {
                if (node.Value < sort)
                {
                    n++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            if (n == 0)
            {
                Console.WriteLine("    No elements");
            } else
            {
                Console.WriteLine($"    {n} elements");
            }
            Console.ResetColor();
        }


    }
}