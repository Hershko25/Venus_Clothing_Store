using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus
{
    class Order
    {
        DBConnection db;
        public Order()
        {
            db = new DBConnection();
        }

        public DataTable ItemsTable()
        {
            return db.ItemsTable();
        }
        public DataTable InsertItem(Product item)
        {
            return db.InsertItem(item);
        }
        public void Update(DataTable table)
        {
            db.UpdateDB(table);
        }
        public void Delete(int ID)
        {
            db.DeleteItem(ID);
        }


    }
}
