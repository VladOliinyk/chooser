using System;

namespace chooser
{
    class Program
    {
        static void Main(string[] args)
        {
            start();
        }

        static void start() {
            // TODO:
            // greetings();
            // showServices();
            // askForService();
            // while (isOneMoreServiceNeeded()) {
            //    askForService();
            // }
            // showTotalTable(calculateTotalTable());
        

        SingleServiceItem obja = new SingleServiceItem("one", 1.0);
        SingleServiceItem objb = new SingleServiceItem("two", 2.0);
        SingleServiceItem objc = new SingleServiceItem("three", 3);

        Console.WriteLine("a " + obja.getItemPrice());
        Console.WriteLine("b " + objb.getItemPrice());
        Console.WriteLine("c " + objc.getItemPrice());

        SingleServiceItem[] array = {obja, objc, objb};

        SingleService myService = new SingleService("name", array);

        Console.WriteLine(myService);
        }
    }
}
