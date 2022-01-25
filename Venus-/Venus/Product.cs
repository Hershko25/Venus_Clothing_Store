using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus
{
    abstract class Product : IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(int id, string name, double price, int stock)
        {
            ID = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public bool CheckOutOfStcok()
        {
            return Stock >= 0;
        }
        public void UpdateStock(int amount)
        {
            Stock += amount;
        }


        public override int GetHashCode()
        {
            return ID;
        }
        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                return GetHashCode() == ((Product)obj).GetHashCode();
            }
            return false;
        }
        public int CompareTo(object obj)
        {
            if (obj is Product)
            {
                return Price.CompareTo((obj as Product).Price);
            }
            return -100;
        }

        public override string ToString()
        {
            return $"ID : {ID} Name : {Name} Price : {Price} Type : {GetType().Name} stock:{Stock} ";
        }



    }
}
