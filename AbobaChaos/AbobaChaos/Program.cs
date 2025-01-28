
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

            string jokerMonolog = "You see, their morals," +
                 " their code... it's a bad joke. Dropped at " +
                 "the first sign of trouble. They're only as good as" +
                 " the world allows them to be. I'll show you. When the chips are down, these... uh," +
                 " 'civilized people'? They'll eat each other. See, I'm not a monster. I'm just ahead of the curve.";

            Console.WriteLine(jokerMonolog);
        }
    }
}
