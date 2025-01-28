namespace AbobaChaos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 9 + 20;
            Console.WriteLine(x + " asdfasdf?!");
            Console.WriteLine(x + " asdfasdf?! - merged");
            Console.WriteLine("Aboba here!!!");
            Console.WriteLine("Hello, World!");

            var nazario = new NazarioClass();
            Console.WriteLine(nazario.Nazario);
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

    public class Aboba
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
