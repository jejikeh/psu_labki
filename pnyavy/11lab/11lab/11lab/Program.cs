namespace _11lab
{
    class Program
    {
        static private void Main()
        {
            Staff[] staffs = new Staff[4];

            staffs[0] = new Staff("Hello", 3, 5);
            staffs[0].Print();

            staffs[0].SetName();
            staffs[0].Print();

            staffs[1] = new Staff("HH");
            staffs[1].Print();

            staffs[2] = new Staff();
            staffs[2].Print();
        }
    }
}
