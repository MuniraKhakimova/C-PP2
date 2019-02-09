using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());// преобразует к типу int
            int[] arr = new int[n];
            
            for (int i=0; i<n; i++)
            {
               arr[i] = int.Parse(Console.ReadLine());
             
            }
            for (int i = 0; i < n; i++)
            { for (int j=0; j<2; j++)
                {
                    Console.Write(arr[i] + " ");
                }
                
            }
            //Console.WriteLine(arr[i]); 



        }
    }
}
