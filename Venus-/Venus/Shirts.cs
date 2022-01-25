using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus
{
    class Shirts : Product
    {
        public char Size { get; set; }

        public Shirts(int id, string name, double price, int stock, char size) : base(id, name, price, stock)
        {
            Size = size;
        }

        public override string ToString()
        {
            return base.ToString() + $"Size : {Size}";
        }
    }
}
