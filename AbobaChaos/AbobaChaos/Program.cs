namespace AbobaChaos
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
