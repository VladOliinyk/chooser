using System;

namespace chooser
{
    class SingleServiceItem
    {

        private static string serviceItemTitle = "StockServiceItemName";
        private static double serviceItemPrice = 0.0;

        public SingleServiceItem(string title, double price) {
            serviceItemTitle = title;
            serviceItemPrice = price;
        }

        public static string getItemTitle() {
            return serviceItemTitle;
        }

        public static double getItemPrice() {
            return serviceItemPrice;
        }

        public static void setItemPrice(double newPrice) {
            serviceItemPrice = newPrice;
        }

        public static void setItemTitle(string newTitle) {
            serviceItemTitle = newTitle;
        }

        public override string ToString(){
            return "The \"" + serviceItemTitle + "\" costs $" + serviceItemPrice + "." ;
        }  
    }
}