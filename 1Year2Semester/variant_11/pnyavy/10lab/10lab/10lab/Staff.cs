class Staff {
    private string _name;
    private int _number;
    private int _rank;
    public Staff(string name, int number, int rank){
        _name = name; 
        _number = number; 
        _rank = rank;
    }

    public void Print()
    {
        Console.WriteLine(_name);
        Console.WriteLine(_number);
        Console.WriteLine(_rank);
    }
}