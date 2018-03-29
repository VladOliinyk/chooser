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

        public string getItemTitle() {
            return serviceItemTitle;
        }

        public double getItemPrice() {
            return serviceItemPrice;
        }

        public void setItemPrice(double newPrice) {
            serviceItemPrice = newPrice;
        }

        public void setItemTitle(string newTitle) {
            serviceItemTitle = newTitle;
        }

        public override string ToString(){
            return "The \"" + serviceItemTitle + "\" costs $" + serviceItemPrice + "." ;
        }  

        public string toShortString() {
            return "" + serviceItemTitle + ":" + serviceItemPrice;
        }
    }
}