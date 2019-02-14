using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = File.ReadAllText(@"C:\Users\user\Desktop\Week2\pldrm.txt");
            char[] str2 = str1.ToCharArray();
            Array.Reverse(str2);
            string str3 = new string(str2);

            if (str3 == str1)
            {
                Console.Write("Yes");
            }
            else
            {
                Console.Write("No");
            }

        }
    }
}
