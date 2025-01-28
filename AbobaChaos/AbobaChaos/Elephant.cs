namespace AbobaChaos
{
    class Elephant
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Elephant(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Elephant Name: {Name}, Age: {Age}");
        }
    }
}
