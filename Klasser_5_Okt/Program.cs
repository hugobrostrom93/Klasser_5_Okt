namespace Klasser
{
    internal class Program
    {

        static void Main()
        {
            StaticProperty proj = new();
            proj.FirstName = "Bruce";
            proj.LastName = "Wayne";
            proj.Print();

            StaticProperty person1 = new() { FirstName = "Barbara1", LastName = "Gordon1" };
            StaticProperty person2 = new() { FirstName = "Barbara2", LastName = "Gordon2" };
            person1.Print();
            person2.Print();

            proj = null;
            person1 = null;
            person2 = null;

            proj = new() { FirstName = "Tim", LastName = "Afaw" }; 
            person1 = new() { FirstName = "Natasha", LastName = "Romanov" };
            person2 = new() { FirstName = "Bruce", LastName = "Banner" };
            proj.Print();
            person1.Print();
            person2.Print();

            proj.StaticPrint(); // Vet ej hur jag skall få detta att funka?

        }



        class StaticProperty
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public static int Counter { get; set; }

            public override string ToString()
            {
                return $"{Counter} - {FirstName} {LastName}";
            }

            public void Print()
            {
                Counter++;
                Console.WriteLine(ToString());
            }

            public static void StaticPrint(StaticProperty person)
            {
                person.Print();
                // Det är weird...
                // vi anropar en statisk metod med en icke statisk instans för att den
                // i sin tur ska anropa instansens statiska metod :-/
                // Crazy men det funkar... och tro mig, man har ofta statiska
                // metoder för att hantera instanser, det är inte ovanligt.
            }

        }
    }
}

