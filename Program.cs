using System;
using System.IO;

namespace EditorText
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("What do you want do? ");
            Console.WriteLine("1 - Open archive");
            Console.WriteLine("2 - Create a new archive");
            Console.WriteLine("0 - Exit");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }
        static void Open()
        {
            Console.Clear();
            Console.WriteLine("What path of archive: ");            
            string path = Console.ReadLine();

            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }
        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Type your text down ((ESC for exit): ");
            Console.WriteLine("-------------------");

            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);
            Save(text);
            Console.WriteLine(text);

        }
        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("What path for save to the archive? ");
            var path = Console.ReadLine();
            
            using(var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"The archive {path} save sucess");
            Menu();
        }
    }
}
