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
            for (int i = startIndex; i < startIndex + random.Next(lastsIndexs); i++)
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

            Console.WriteLine("3 APP");
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();

            // 1 task
            for (int i = 0; i < random.Next(100); i++)
            {
                l1.Add(random.Next(100));
            }


            // 3 task
            l1.Sort();

            l1.Reverse();

            // 4 task
            l1.ForEach(x => Console.WriteLine(x));

            // 5 and 6 task
            int sort = random.Next(100);
            Console.WriteLine($"Bigger than {sort} :");
            foreach(int x in l1)
            {
                if(x > sort)
                {
                    l2.Add(x);
                    Console.WriteLine(x);
                }
            }

            // 7 task

            l2.ForEach(x => Console.WriteLine(x));


        }


    }
}