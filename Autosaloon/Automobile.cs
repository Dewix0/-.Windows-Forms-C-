using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autosaloon
{
    public class Automobile
    {
        private string brand;
        private string model;
        private int cost;
        private int amount;

        public Automobile(string brand,string model,int cost, int amount)
        {
            this.brand = brand;
            this.model = model;
            this.cost = cost;
            this.amount = amount;
        }

        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public int Cost { get => cost; set => cost = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
