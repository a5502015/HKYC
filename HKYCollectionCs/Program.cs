using System;

namespace HKYCollectionCs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HKYCollection hc = new HKYCollection();

            hc.search();

            Console.WriteLine("done");
            Console.ReadKey(true);
        }
    }
}
