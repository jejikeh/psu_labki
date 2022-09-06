using System.Net;
using System.Xml.Linq;

struct Student
{
    public string Name { get; set; }
    public int Group { get; set; }
    public List<int> Ses { get; set; }

    public Student(string name, int group, List<int> ses)
    {
        Name = name;
        Group = group;
        Ses = ses;
    }

    public void Print()
    {
        Console.WriteLine("Student : ");
        Console.WriteLine($"\tname : {Name}");
        Console.WriteLine($"\tgroup : {Group}");
        Console.Write("\tses : { ");
        foreach(var n in Ses)
        {
            Console.Write(n.ToString() + " ");
        }
        Console.Write("}\n");
    }
}

static class Program
{
    static void Main()
    {
        List<Student> students = new();
        for(int i = 0; i < 3; i++)
        {
            Console.Write($"name \t");
            string name = Console.ReadLine();
            Console.Write($"group \t");
            int group = int.Parse(Console.ReadLine());
            Console.Write($"ses \t");


            List<int> sesArray = new();
            for(int k = 0; k < 5; k++)
            {
                sesArray.Add(int.Parse(Console.ReadLine()));
            }
            students.Add(new Student(name, group, sesArray));
        }

        var sortedStudents = students.OrderBy(a => a.Name);

        foreach(var s in sortedStudents.Where(x => x.Ses.Contains(2) ))
        {
            s.Print();
        }
    }
}

