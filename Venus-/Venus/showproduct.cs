using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venus
{
    public partial class showproduct : Form
    {
        static Store stock;
        object temp;
        Order Itemorder;
        static Product[] prods = new Product[0];

        public showproduct(Image box, object obj)//trans the product
        {
            InitializeComponent();
            pictureBox1.Image = box;
            Nameofp.Text = ($"Code:{((Product)obj).ID} Name:{((Product)obj).Name} Price:{((Product)obj).Price}$");
            temp = obj;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            Itemorder = new Order();
        }

        private void showproduct_Load(object sender, EventArgs e)//box size
        {
            if (temp is Shoes)
            {
                comboBox2.Visible = true;
            }
            else if (temp is Shirts)
            {
             comboBox1.Visible = true;
            }
            else if (temp is Pants)
            {
                comboBox2.Visible = true;
            }

        }
        public void CheckStock(object obj)//get the stock
        {

            stock = (Store)obj;
        }
        private void button1_Click(object sender, EventArgs e)//enter to grid and check availble
        {
           
            if (temp is Shoes)
            {     
              ((Shoes)temp).Size = int.Parse(comboBox2.Text);
              Itemorder.InsertItem((Shoes)temp);
                AddProduc(ref prods, (Shoes)temp);
                for (int i = 0; i < stock.Allshoes.Length; i++)
                {
                    if (((Shoes)temp).ID == stock.Allshoes[i].ID && ((Shoes)temp).Size == stock.Allshoes[i].Size)
                    {
                        if (!((Shoes)temp).CheckOutOfStcok())
                        {
                            MessageBox.Show("Not Available");
                            break;
                        } 
                    }
                }

            }
            else if(temp is Shirts)
            {
                ((Shirts)temp).Size =char.Parse( comboBox1.Text);
                Itemorder.InsertItem((Shirts)temp);
                AddProduc(ref prods, (Shirts)temp);
                for (int i = 0; i < stock.AllShirts.Length; i++)
                {
                    if (((Shirts)temp) == stock.AllShirts[i])
                    {
                        if (((Shirts)temp).CheckOutOfStcok())
                        {
                            MessageBox.Show("Available");
                        }
                    }
                }

            }
            else if (temp is Pants)
            {
                ((Pants)temp).Size = int.Parse(comboBox2.Text);
                Itemorder.InsertItem((Pants)temp);
                AddProduc(ref prods, (Pants)temp);
                for (int i = 0; i < stock.AllPants.Length; i++)
                {
                    if (((Pants)temp) == stock.AllPants[i])
                    {
                        if (((Pants)temp).CheckOutOfStcok())
                        {
                            MessageBox.Show("Available");
                        }
                    }
                }
            }

            MessageBox.Show($"Item Added To The Cart!");
            Close();
        }

        private void AddProduc(ref Product[] allprods, Product item)//put all the order on arr to remove from store stock
        {
            Product[] tempArr = new Product[allprods.Length + 1];
            for (int i = 0; i < allprods.Length; i++)
            {
                tempArr[i] = allprods[i];
            }
            tempArr[allprods.Length] = item;
            allprods = tempArr;
        }

        public static void RemoveItem()//update at real time thestore stcok and rest the prods
        {
            Form1.RemoveProducts(prods);
            prods = new Product[0];
        }

      
    }
}
