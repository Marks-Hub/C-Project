using System;
using System.IO;

namespace iml_machine
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the file name of the program to load:");
            string fileName = Console.ReadLine();
            try
            {
                StreamReader inFile = new StreamReader(fileName);
                IMLMachine machine = new IMLMachine(inFile);
                machine.Run();
                Console.WriteLine("\n\n" + machine);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Illegal file.");
            }
        }
    }
}
