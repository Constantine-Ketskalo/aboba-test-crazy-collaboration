using System;

namespace AbobaChaos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Elephant elephant = new Elephant("Dumbo", 10);
            elephant.DisplayInfo();
            Console.WriteLine("Hello, World!");
        }
    }
}
