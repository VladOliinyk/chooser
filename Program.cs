using System;

namespace chooser
{
    class Program
    {
        static void Main(string[] args)
        {
            start();
            test();
        }

        static void start()
        {
            // TODO:
            // greetings();
            // showServices();
            // askForService();
            // while (isOneMoreServiceNeeded()) {
            //    askForService();
            // }
            // showTotalTable(calculateTotalTable());
        }

        static void test()
        {
            // creating simple array of singl service items
            SingleServiceItem[] array = {
                new SingleServiceItem("one", 1.0),
                new SingleServiceItem("two", 2.0),
                new SingleServiceItem("three", 3)};

            // creating own service
            SingleService myService = new SingleService("Custom Name", array);

            //ceck out cool output
            Console.WriteLine(myService);
        }
    }
}
