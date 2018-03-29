using System;

namespace chooser
{
    class SingleService 
    {
        private static string serviceTitle = "StockService";
        private static SingleServiceItem[] subServices = {};
        
        public SingleService() {

        }
        public SingleService(string title, SingleServiceItem[] itemArray) {
            serviceTitle = title;
            subServices = itemArray;
        }

        public string getServiceTitle() {
            return serviceTitle;
        }

        public void setServiceTitle(string newTitle) {
            serviceTitle = newTitle;
        }

        public void addItem(SingleServiceItem item) {
            int newSize = subServices.Length + 1;
            SingleServiceItem[] newSubServices = new SingleServiceItem[subServices.Length + 1];

        }



        public override string ToString(){
            string str =  "The \"" + serviceTitle + "\" has such subservices: [";

            for (int i=0; i < subServices.Length; i++) {

                string shortStr = subServices[i].toShortString();
                str += shortStr;
                if (i != subServices.Length - 1) {
                    str+=",";
                }

            }

            str+= "].";

            return str;
        }  

    }
}