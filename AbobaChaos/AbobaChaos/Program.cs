﻿
namespace AbobaChaos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 9 + 20;
            Console.WriteLine(x + " asdfasdf?!");

            Console.WriteLine("Hello, World!");

            var nazario = new NazarioClass();
            Console.WriteLine(nazario.Nazario);

            var aboba = new Class1();
            Console.WriteLine(aboba.GetHelloWorld());
        }
    }


    public class NazarioClass
    {
        public string Nazario { get; set; }

        public NazarioClass()
        {
            Nazario = "Nazario";
        }
    }
}
