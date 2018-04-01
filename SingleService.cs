using System;

namespace chooser
{
    class SingleService
    {
        private string serviceTitle = "StockService";
        private SingleServiceItem[] subServices = { };

        private int selectedOption = -1;

        public SingleService(SingleService other)//Deep copy constructor
        {
            this.serviceTitle = other.serviceTitle;
            this.subServices = other.subServices;
            this.selectedOption = other.selectedOption;
        }

        public SingleService(string title, SingleServiceItem[] itemArray)
        {
            serviceTitle = title;
            subServices = itemArray;
        }

        public void setOption(int option)
        {
            selectedOption = option;
        }

        public int getOption()
        {
            return selectedOption;
        }

        public string getServiceTitle()
        {
            return serviceTitle;
        }

        public SingleServiceItem[] getServiceItems()
        {
            return subServices;
        }

        public void setServiceTitle(string newTitle)
        {
            serviceTitle = newTitle;
        }

        public void addItem(SingleServiceItem item)
        {
            int newSize = subServices.Length + 1;
            SingleServiceItem[] newSubServices = new SingleServiceItem[subServices.Length + 1];

        }



        public override string ToString()
        {
            string str = "The \"" + serviceTitle + "\" has such subservices: [";

            for (int i = 0; i < subServices.Length; i++)
            {

                string shortStr = subServices[i].ToString();
                str += shortStr;
                if (i != subServices.Length - 1)
                {
                    str += ",";
                }

            }

            str += "].";

            return str;
        }





    }
}