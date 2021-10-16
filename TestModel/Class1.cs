using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel
{
    public class Product
    {
        public int id;
        public string code;
        public float weight;
        public float price;

        public Product(int id, string code, float weight, float price)
        {
            this.id = id;
            this.code = code;
            this.weight = weight;
            this.price = price;
        }
    }
}
