using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus
{

    class Shoes : Product
    {
        
        public int Size { get; set; }


        public Shoes(int id, string name, double price, int stock, int size) : base(id, name, price, stock)
        {
            Size = size;
         
        }

        public override string ToString()
        {
            return base.ToString() + $"Size : {Size}";
        }

    }
}
