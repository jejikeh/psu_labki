using System;
using System.Collections.Generic;

public class MainClass
{
    private static Dictionary<int,int> FillList(){ 
        string[] input = Console.ReadLine().Split(' '); 
        Dictionary<int,int> list = new Dictionary<int,int>();
        for(int i = 1; i <= int.Parse(input[0]); i++){
            list.Add(int.Parse(input[i]), i);
        }
        
        return list;
    }
    
    private static Dictionary<int,int> FillListUn(){ 
        string[] input = Console.ReadLine().Split(' '); 
        Dictionary<int,int> list = new Dictionary<int,int>();
        for(int i = 1; i <= int.Parse(input[0]); i++){
            list.Add(i, int.Parse(input[i]));
        }
        
        return list;
    }
    public static void Main()
    {
        Dictionary<int,int> x = FillList();
        Dictionary<int,int> y = FillListUn();
        
        foreach(KeyValuePair<int,int> i in y){
            if (x.ContainsKey(i.Value)){
                Console.Write($"{x[i.Value]} ");
            }
            else
            {
                Console.Write("-1 ");
            }
        }
    }
}