using System;
using System.Collections.Generic;

namespace chooser
{
    class Program
    {
        private SingleService[] services;
        private List<SingleService> serviceList = new List<SingleService>();
        public void run()
        {
            start();
            test("");
        }

        void start()
        {
            services = initializeServices();

            greetings();
            showServices();
            askForService();
            processStackAndShowTotalTable();

        }

        void processStackAndShowTotalTable()
        {
            double summary = 0;

            //----------        output       -----------\\            
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("  So here is your total order table:\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("┌─────────────────────────────────────────────────────────────────────┐\n");
            Console.ResetColor();



            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("│");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0, 25}    ", "Option");
            Console.Write("{0, 25}    ", "Service");
            Console.Write("{0,8}  ", "Cost");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" │\n");
            Console.Write("├────────────────────────────┬────────────────────────────┬───────────┤\n");
            Console.ResetColor();
            foreach (var service in serviceList)
            {
                summary += service.getServiceItems()[service.getOption()].getItemPrice();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("│");
                Console.ResetColor();
                Console.Write("{0, 25}   ", service.getServiceTitle());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("│");
                Console.ResetColor();
                Console.Write("{0, 25}   ", service.getServiceItems()[service.getOption()].getItemTitle());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("│");
                Console.ResetColor();
                Console.Write("{0,8:N1}   ", service.getServiceItems()[service.getOption()].getItemPrice());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("│\n");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("├────────────────────────────┴────────────────────────────┼───────────┤\n");
            Console.Write("│");
            Console.ResetColor();
            Console.Write("                                               Summary:  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("│");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0,8}   ", summary);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("│\n");
            Console.Write("└─────────────────────────────────────────────────────────┴───────────┘\n");
            Console.ResetColor();

        }

        void askForService(int isFirstAsk = 0)
        {

            // help mesages //
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <info: ");
            Console.ResetColor();
            if (isFirstAsk == 0)
            {
                Console.Write("Now you could choose the service you need.");
            }
            else
            {
                Console.Write("Choose one more service you need.");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <help: ");
            Console.ResetColor();
            Console.Write("Enter the ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("digit");
            Console.ResetColor();
            Console.Write(" number of service you want to choose.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <help: ");
            Console.ResetColor();
            Console.Write("Enter ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("0");
            Console.ResetColor();
            if (serviceList.Count == 0)
            {
                Console.Write(" to close program.");
            }
            else
            {
                Console.Write(" to cancel.");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <help: ");
            Console.ResetColor();
            Console.Write("Enter ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("#");
            Console.ResetColor();
            Console.Write(" to show list of services again.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();

            Console.WriteLine();

            // help mesages end //
            string userAnswer;
            Console.Write("  >");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" ");
            userAnswer = Console.ReadLine();
            Console.ResetColor();

            String[] correctAnswers = new String[] { "1", "2", "3", "0", "#" };

            while (!userStringIsCorrect(userAnswer, correctAnswers))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" <info: ");
                Console.ResetColor();
                Console.Write("Sorry. Your input is incorrect.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" > \n");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("  >");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                userAnswer = Console.ReadLine();
                Console.ResetColor();
            }

            // variable selected service

            int serviceOptionToSet = -1;

            /* i use switch here coz i can */
            SingleService selectedService;
            switch (userAnswer)
            {
                case "#": //  show list of services again
                    showServices();
                    askForService(1);
                    break;
                case "0": // close the program
                    return;
                default:
                    int userIntAnswer = Int32.Parse(userAnswer);

                    selectedService = new SingleService(services[userIntAnswer - 1]);
                    serviceOptionToSet = askForServiceOptions(userIntAnswer - 1);

                    if (serviceOptionToSet == -1)
                    {
                        return;
                    }
                    selectedService.setOption(serviceOptionToSet - 1);
                    serviceList.Insert(0, selectedService);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" <info: ");
                    Console.ResetColor();
                    Console.Write("Done! Option \"");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("{0,0}", selectedService.getServiceItems()[selectedService.getOption()].getItemTitle());
                    Console.ResetColor();
                    Console.Write("\" will be added to your order list.");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" > \n");
                    Console.ResetColor();

                    break;
            }

            // if here, so userAnswer is '0' or '1' or '2' or '3'
            if (oneMoreServiceIsNeeded())
            {
                showServices();
                askForService(1);
            }


        }

        private int askForServiceOptions(int serviceId)
        {
            int serviceOptionId = -1;

            showServiceOptions(services[serviceId]);
            serviceOptionId = askUserForServiceOption(services[serviceId]);

            while (serviceOptionId == -2)
            {
                showServiceOptions(services[serviceId]);
                serviceOptionId = askUserForServiceOption(services[serviceId]);
            }

            return serviceOptionId;
        }


        private int askUserForServiceOption(SingleService selectedService)
        {
            int answer = -1;

            // help mesages //
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <help: ");
            Console.ResetColor();
            Console.Write("Enter the ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("digit");
            Console.ResetColor();
            Console.Write(" number of service option you want to choose.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <help: ");
            Console.ResetColor();
            Console.Write("Enter ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("0");
            Console.ResetColor();
            Console.Write(" to cancel this service.");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <help: ");
            Console.ResetColor();
            Console.Write("Enter ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("#");
            Console.ResetColor();
            Console.Write(" to show list of service options again.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();
            Console.WriteLine();

            // help mesages end //


            string userAnswer;
            Console.Write("  >");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" ");
            userAnswer = Console.ReadLine();
            Console.ResetColor();



            String[] correctAnswers = new String[selectedService.getServiceItems().Length + 2];

            correctAnswers[0] = "#";
            correctAnswers[1] = "0";
            for (int i = 2; i < correctAnswers.Length; i++)
            {
                correctAnswers[i] = "" + (i - 1);
            }


            while (!userStringIsCorrect(userAnswer, correctAnswers))
            {
                Console.WriteLine();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" <help: ");
                Console.Write("Sorry. Your input is incorrect.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" > \n");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("  >");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                userAnswer = Console.ReadLine();
                Console.ResetColor();
            }

            switch (userAnswer)
            {
                case "#": //  show list of services again
                    answer = -2;
                    break;
                case "0": // close the program
                    answer = -1;
                    break;
                default: // add service #userAnswer to queue
                    answer = Int32.Parse(userAnswer);
                    break;
            }

            return answer;
        }
        private void showServiceOptions(SingleService selectedService)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("");
            Console.Write("───┐  ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0,0}", selectedService.getServiceTitle());
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" have such options:\n");
            Console.Write("   │\n");
            Console.Write("   │  {0, -5}{1, -30}{2, 7}\n", "ID", "Title", "Cost");

            Console.ResetColor();


            int size = selectedService.getServiceItems().Length;
            for (int i = 0; i < size; i++)
            {

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (i == size - 1)
                {
                    Console.Write("   └─ ");
                }
                else
                {
                    Console.Write("   ├─ ");
                }

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0,-5}", i + 1);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("{0,-30}", "\"" + selectedService.getServiceItems()[i].getItemTitle() + "\"");
                Console.ResetColor();
                Console.Write("{0,7:0.00}", selectedService.getServiceItems()[i].getItemPrice());
                Console.Write("\n");

            }

            Console.WriteLine();

        }

        private bool oneMoreServiceIsNeeded()
        {

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <help: ");
            Console.ResetColor();
            Console.Write("Enter ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("1");
            Console.ResetColor();
            Console.Write(" if you want to request for one more service.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <help: ");
            Console.ResetColor();
            Console.Write("Enter ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("0");
            Console.ResetColor();
            Console.Write(" if you want to calculate your total order.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" > \n");
            Console.ResetColor();

            Console.WriteLine();

            // help mesages end //
            string userAnswer;
            Console.Write("  >");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" ");
            userAnswer = Console.ReadLine();
            Console.ResetColor();

            String[] correctAnswers = new String[] { "1", "0" };
            while (!userStringIsCorrect(userAnswer, correctAnswers))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" <help: ");
                Console.ResetColor();
                Console.Write("Sorry. Your input is incorrect.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" > \n");
                Console.ResetColor();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" <help: ");
                Console.ResetColor();
                Console.Write("Enter ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("1");
                Console.ResetColor();
                Console.Write(" if you want to request for one more service.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" > \n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" <help: ");
                Console.ResetColor();
                Console.Write("Enter ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("0");
                Console.ResetColor();
                Console.Write(" if you want to calculate your total order.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" > \n");
                Console.ResetColor();

                Console.WriteLine();

                Console.Write("  >");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                userAnswer = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine();
            }

            if (userAnswer == "1")
            {
                return true;
            }

            return false;
        }

        bool userStringIsCorrect(string userStr, String[] rightAnswers)
        {
            for (int i = 0; i < rightAnswers.Length; i++)
            {
                if (userStr == rightAnswers[i])
                {
                    return true;
                }
            }

            return false;
        }
        void showServices()
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("");
            Console.Write("┐ In our studio we have such services:\n");
            Console.ResetColor();

            for (int i = 0; i < services.Length; i++)
            {
                var curService = services[i];
                var curServiceItems = curService.getServiceItems();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (i == services.Length - 1)
                {
                    Console.Write("└─ ");
                }
                else
                {
                    Console.Write("├─ ");
                }

                Console.ResetColor();
                Console.Write("Service #");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(i + 1);
                Console.ResetColor();
                Console.Write(" - ");
                Console.Write("\"");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(curService.getServiceTitle());
                Console.ResetColor();
                Console.Write("\"\n");
            }

            Console.WriteLine("");
        }

        SingleService[] initializeServices()
        {
            // service 1 = Complex webpage design
            SingleServiceItem[] service1items = {
                new SingleServiceItem("Landing page", 40.5),
                new SingleServiceItem("Personal website", 20),
                new SingleServiceItem("Online store", 125.5),
                new SingleServiceItem("Promo website", 45),
                new SingleServiceItem("Corporative website", 95.5)
            };
            SingleService service1 = new SingleService("Complex webpage design", service1items);


            // service 2 = Printed production
            SingleServiceItem[] service2items = {
                new SingleServiceItem("Visitcard", 10),
                new SingleServiceItem("Brochure", 7),
                new SingleServiceItem("Wall calendar", 3),
                new SingleServiceItem("Poster", 5)
            };
            SingleService service2 = new SingleService("Printed production", service2items);


            // service 3 = Photo editing
            SingleServiceItem[] service3items = {
                new SingleServiceItem("Colorization", 5),
                new SingleServiceItem("Retouch", 4),
                new SingleServiceItem("Restoration of old photos", 7)
            };
            SingleService service3 = new SingleService("Photo editing", service3items);

            return new SingleService[3] { service1, service2, service3 };
        }
        void greetings()
        {

            //     ╔══════════════════════════════════════╗
            //     ║               Greetings              ║
            //     ║                  in                  ║
            //     ║             OilMan Design            ║
            //     ╚══════════════════════════════════════╝

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("╔═════════════════════════════════════════════════════════════════════╗\n");

            Console.Write("║                              ");
            Console.ResetColor();
            Console.Write("Greetings");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                              ║\n");

            Console.Write("║                                 ");
            Console.ResetColor();
            Console.Write("in");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                                  ║\n");

            Console.Write("║                            ");
            Console.ResetColor();
            Console.Write("OilMan Design");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                            ║\n");

            Console.Write("╚═════════════════════════════════════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        void test(string test)
        {
            switch (test)
            {
                case "first":
                    // creating simple array of singl service items
                    SingleServiceItem[] array = {
                    new SingleServiceItem("one", 1.0),
                    new SingleServiceItem("two", 2.0),
                    new SingleServiceItem("three", 3)};

                    // creating own service
                    SingleService myService = new SingleService("Custom Name", array);

                    //ceck out cool output
                    Console.WriteLine(myService);
                    break;

                case "colorConsole":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("White on blue.");
                    Console.WriteLine("Another line."); // <-- This line is still white on blue.
                    Console.ResetColor();
                    break;
            }

        }

    }
}
