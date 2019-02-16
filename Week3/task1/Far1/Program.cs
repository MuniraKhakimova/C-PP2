using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace far1
{
    class Layer
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }

        int selectedItem;   
        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (value < 0)
                {
                    selectedItem = Content.Length - 1;
                }
                else if (value >= Content.Length)
                {
                    selectedItem = 0;
                }
                else
                {
                    selectedItem = value;
                }
            }
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Content[i].Name);
            }
        }
    }

    enum FarMode
    {
        FileView,
        DirectoryView
    }

    class Program
    {
        static bool PathExists(string path, FarMode mode) // Проверка пути
        {
            if ((mode == FarMode.DirectoryView && new DirectoryInfo(path).Exists) || (mode == FarMode.FileView && new FileInfo(path).Exists))
                return true;
            else
                return false;
        }

            static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\");
            Stack<Layer> history = new Stack<Layer>();
            FarMode farMode = FarMode.DirectoryView;

            history.Push(
                new Layer
                {
                    Content = root.GetFileSystemInfos(),
                    SelectedItem = 0
                });

            while (true)
            {
                if (farMode == FarMode.DirectoryView)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { Content = d.GetFileSystemInfos(), SelectedItem = 0 });
                        }
                        else
                        {
                            farMode = FarMode.FileView;
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (farMode == FarMode.DirectoryView)
                        {
                            history.Pop();
                        }
                        else if (farMode == FarMode.FileView)
                        {
                            farMode = FarMode.DirectoryView;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Delete:
                        int x2 = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().Content = d.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo f = fileSystemInfo2 as FileInfo;
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().Content = f.Directory.GetFileSystemInfos();
                        }
                        history.Peek().SelectedItem--;
                        break;

                    /*case ConsoleKey.A:
                        int x3 = history.Peek().SelectedItem;
                        int x4 = int.Parse(Console.ReadLine());
                        FileSystemInfo fileSystemInfo3 = history.Peek().Content[x3];
                        FileSystemInfo fileSystemInfo4 = history.Peek().Content[x4];
                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo3 as DirectoryInfo;
                            Directory.Move(fileSystemInfo3.FullName, fileSystemInfo4.FullName);
                            history.Peek().Content = d.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo f = fileSystemInfo3 as FileInfo;
                            File.Delete(fileSystemInfo3.FullName);
                            history.Peek().Content = f.Directory.GetFileSystemInfos();
                        }
                        history.Peek().SelectedItem--;
                        break;*/
                }
            }
        }
    }
}
