using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Part
{
    public class Part
    {
        private int PartID;
        private string Name;
        private string Number;
        private double Price;

        public Part(int PartID, string Name, string Number, double Price)
        {
            this.PartID = PartID;
            this.Name = Name;
            this.Number = Number;
            this.Price = Price;
        }

        public int GetPartID()
        {
            return PartID;
        }
        
        public string GetName()
        {
            return Name;
        }

        public string GetNumber()
        {
            return Number;
        }

        public double GetPrice()
        {
            return Price;
        }
    }
}
