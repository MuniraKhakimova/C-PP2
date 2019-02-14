using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string pth = @"C:\Users\user\Desktop\Week2\pth.txt";
            string pth1 = @"C:\Users\user\Desktop\Week2";
            DirectoryInfo dirI = new DirectoryInfo(pth1);
            FileInfo file = new FileInfo(pth);
            if (file.Exists && dirI.Exists)
            {
                file.CopyTo(pth1 + @"\pth1.txt", true);
                file.Delete();
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
