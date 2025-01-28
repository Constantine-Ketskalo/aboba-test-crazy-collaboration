namespace AbobaChaos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "AbobaChaos";
            Console.WriteLine("Hello, " + name);
            int x = 9 + 20;
            Console.WriteLine(x + " asdfasdf?!");

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
}
