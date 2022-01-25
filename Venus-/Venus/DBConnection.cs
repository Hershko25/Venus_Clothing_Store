using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus
{
    class DBConnection
    {
        string strCon = @"Data Source=LAPTOP-NP92ISGK\SQLEXPRESS;Initial Catalog=TBItem;Integrated Security=True";
        string strCmd;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter Commandadptr;
        DataSet ds;
        static DataTable dt;
        public DBConnection()
        {
            con = new SqlConnection(strCon);
            Commandadptr = new SqlDataAdapter("Seletct * From TBItems", con);


        }

        public DataTable ItemsTable()
        {
            try
            {
                strCmd = "select * from TBItems";
                cmd = new SqlCommand(strCmd, con);
                Commandadptr = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Clear();
                ds = new DataSet();
                Commandadptr.Fill(ds, "Items");

                dt = ds.Tables["Items"];
                dt.Clear();
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable InsertItem(Product I)
            {
            try
            {
                DataRow dr = dt.NewRow();
                if (I is Shoes)
                {

                    dr["ID"] = I.ID;
                    dr["Name"] = I.Name;
                    dr["Price"] = I.Price;
                    dr["Size"] = ((Shoes)I).Size;
                }
                if (I is Shirts)
                {

                    dr["ID"] = I.ID;
                    dr["Name"] = I.Name;
                    dr["Price"] = I.Price;
                    dr["Size"] = ((Shirts)I).Size;
                }
                if (I is Pants)
                {

                    dr["ID"] = I.ID;
                    dr["Name"] = I.Name;
                    dr["Price"] = I.Price;
                    dr["Size"] = ((Pants)I).Size;
                }

                dt.Rows.Add(dr);
                return dt;
            }
            catch (Exception)
            {

                return null;
            }
           
                
            
            }
        public DataTable DeleteItem(int ID)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ID"].ToString() == ID.ToString())
                    {
                        dt.Rows[i].Delete();
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public void UpdateDB(DataTable table)
        {
            new SqlCommandBuilder(Commandadptr);
            Commandadptr.Update(dt);
        }
    }
}
