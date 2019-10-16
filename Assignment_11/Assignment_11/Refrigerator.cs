using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11
{
    public class Refrigerator
    {
        private double maxWeight { set; get; }
        List<int> items = new List<int>();
        List<double> weightPerUnit = new List<double>();


        public Refrigerator(int max)
        {
            this.maxWeight = max;
        }
        public bool Add(int item, double weight)
        {
            bool isAdded = false;
            this.items.Add(item);
            this.weightPerUnit.Add(weight);
            isAdded = true;
            return isAdded;
        }
        public double Current()
        {
            double temp=0;
            double currentWeight =0;
            for(int i= 0; i<items.Count();i++)
            {
                temp = items[i] * weightPerUnit[i];
                currentWeight += temp;

            }
            return currentWeight;
        }
        public bool Validation(double  addWeight)
        {
            bool isExeceeded = false;
            if(Current()+addWeight >maxWeight)
            {
                isExeceeded = true;
               
            }
            return isExeceeded;


        }
        public double RemainWeight()
        {
            return maxWeight - Current();
        }
        public string GetDetails()
        {
            string message;
            message = "\tNo of item\tWeight.unit\tTotal Weight\n";
            message += "--------------------------------------------------------------------------------------------\n";
            List<double> tempList = new List<double>();
            for (int i = 0; i < items.Count(); i++)
            {
                tempList.Add(this.items[i] * this.weightPerUnit[i]);
                message += "\t" + items[i] + "\t\t" + weightPerUnit[i] + "\t\t" + tempList[i] + "\n";
            }
            message += "____________________________________________________\n";
            message += "Total\t" + items.Sum() + "\t\t" + weightPerUnit.Sum() + "\t\t" + tempList.Sum();



            return message;
        }
    }
}
