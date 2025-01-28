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
            
            var simplio = new SimplioClass();
            Console.WriteLine(simplio.Simplio);
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
    public class SimplioClass
    {
        public string Simplio { get; set; }

        public SimplioClass()
        {
            Simplio = "Simplio";
        }
    }
}
