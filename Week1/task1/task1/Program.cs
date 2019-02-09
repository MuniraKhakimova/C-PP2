
using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            int n = int.Parse(line1);
            string[] numsStr = line2.Split();

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(numsStr[i]);
                if (x == 2 || x==3)
                {
                    
                    Console.Write(x + " ");
                }
               
                   if (x>2 && (x%6==1 || x%6==5) )
                {
                    
                    Console.Write(x + " ");

                }
            }

        }
    }
}
 
