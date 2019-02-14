using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = File.ReadAllText(@"C:\Users\user\Desktop\Week2\input.txt");
            string[] str1 = str.Split();
            using (StreamWriter output = new StreamWriter(@"C:\Users\user\Desktop\Week2\output.txt"))
            {
                foreach (string num in str1)
                {
                    int x = Convert.ToInt32(num);
                    if (x == 2 || x == 3)
                    {

                        output.Write(x + " ");
                    }

                    if (x > 2 && (x % 6 == 1 || x % 6 == 5))
                    {

                        output.Write(x + " ");

                    }
                }
            }
        }
    }
}
