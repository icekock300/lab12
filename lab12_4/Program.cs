using LibraryLab10;
 namespace lab12_4;

class Program
{
    static void Main(string[] args)
    {
        MyCollection<MusicalInstrument> m1 = new MyCollection<MusicalInstrument>(10);
        foreach (MusicalInstrument m in m1)
        {
            Console.WriteLine(m);
        }
    }
}

