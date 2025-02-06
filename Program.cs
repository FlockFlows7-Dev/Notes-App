using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        string[] Notes = new string[100];
        int index = 0;
        string filePath = "notes.txt";

        LoadNotes();

        void LoadNotes()
        {
            if (File.Exists(filePath))
            {
                string[] loadedNotes = File.ReadAllLines(filePath);
                for (int i = 0; i < loadedNotes.Length; i++)
                {
                    Notes[i] = loadedNotes[i];
                    index++;
                }
            }
        }

        void SaveNotes()
        {
            File.WriteAllLines(filePath, Notes);
        }

        void newNote()
        {
            Console.WriteLine("Write your note below:");
            Notes[index] = Console.ReadLine();
            index++;
            SaveNotes();
            Console.Clear();
            Start();
        }

        void SeeNotes()
        {
            if (index == 0)
            {
                Console.WriteLine("No Notes (Press Enter to go back)");
                Console.ReadLine();
                Start();
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine($"{i + 1}. {Notes[i]}");
                }
                Console.WriteLine("Press Enter to go back");
                Console.ReadLine();
                Console.Clear();
                Start();
            }
        }

        void Start()
        {
            Console.WriteLine("(NotesApp)");
            Console.WriteLine("");
            Console.WriteLine("(New Note Press 1)");
            Console.WriteLine("(See Notes Press 2)");
            Console.WriteLine("(Clear Notes Press 3)");
            choice();
        }

        void choice()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.D1)
            {
                Console.Clear();
                newNote();
            }
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                Console.Clear();
                SeeNotes();
            }
            else if (keyInfo.Key == ConsoleKey.D3)
            {
                Console.Clear();
                index = 0;
                SaveNotes();
                Start();
            }
        }

        Start();
    }
}
