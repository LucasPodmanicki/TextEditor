using System;
using System.IO;

namespace TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Oque deseja realizar? ");
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar Arquivo");
            Console.WriteLine("0 - Sair");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Editor(); break;
                default: Menu(); break;
                
            }
        }

        public static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo? ");
            String path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                String text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        public static void Editor()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo  (ESC para sair)");
            Console.WriteLine("=======================");
            String text = "";


            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }

        public static void Save(String text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arqui?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path)) 
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} Salvo com Sucesso!");
            Console.ReadLine();
            Menu();
        }
    }

}
