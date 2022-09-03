namespace _19lab
{
    public class Program
    {
        static void Main()
        {
            Menu menu = new Menu();

            while (true)
            {
                try
                {
                    menu.DrawMenu();
                    menu.PrepareForInput(ConsoleColor.Green);
                    int? userTaskInput = Convert.ToInt16(Console.ReadLine());
                    if (userTaskInput == 1)
                    {
                        Console.Clear();
                        new Task1().DrawTask();
                    } else if (userTaskInput == 2)
                    {
                        Console.Clear();
                        new Task2().DrawTask();
                    }
                    else if (userTaskInput == 3)
                    {
                        Console.Clear();
                        new Task3().DrawTask();
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    menu.DrawError(ex.Message);
                }

            }


        }
    }
}