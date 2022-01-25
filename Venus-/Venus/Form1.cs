using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Venus
{
    public partial class Form1 : Form
    {
        Order ItemOrder;
        static Store S;
        string XmlPath = "Users.xml";
        string Pathusername = "Users.text";
        string Pathpassword = "Passworrd.text";
        static ArrayList UserNames;
        static ArrayList Passwords;
        bool loginto = false;

        public Form1()
        {
            InitializeComponent();
            MenuCustom();
            ItemOrder = new Order();
            dataGridView1.DataSource = ItemOrder.ItemsTable();
            UserNames = new ArrayList();
            Passwords = new ArrayList();

        }

        private void Form1_Load(object sender, EventArgs e)//start makestore
        {
            S = MakeStore();
        }
        private void MenuCustom()//visible menu
        {

            SectionUser.Visible = false;
            SectionSingUp.Visible = false;
            CartSection.Visible = false;
            Zap.Visible = false;
            Loginpart.Visible = false;
            userinfo.Visible = false;
        }
        private void hidesection()//hide section
        {

            if (SectionSingUp.Visible == true)
            {
                SectionSingUp.Visible = false;
            }
            if (CartSection.Visible == true)
            {
                CartSection.Visible = false;
            }
            if (Zap.Visible == true)
            {
                Zap.Visible = false;
            }

            if (Loginpart.Visible == true)
            {
                Loginpart.Visible = false;
            }




        }
        private void showsection(Panel section)//show scection
        {
            if (section.Visible == false)
            {

                hidesection();
                section.Visible = true;
            }
            else
            {
                section.Visible = false;
            }

        }




        private void pictureBox2_Click(object sender, EventArgs e)//Read from text username and password
        {
            showsection(SectionUser);
            StringBuilder builder = new StringBuilder();
            StreamReader reader = new StreamReader(Pathusername);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {

                UserNames.Add(line);


            }
            reader.Close();
            builder = new StringBuilder();
            reader = new StreamReader(Pathpassword);
            line = "";
            while ((line = reader.ReadLine()) != null)
            {

                Passwords.Add(line);


            }
            reader.Close();
        }



        private void SingUp_Click(object sender, EventArgs e)//Show Singup Section
        {

            showsection(SectionSingUp);
        }


        private void pictureBox14_Click(object sender, EventArgs e)
        {
            showsection(CartSection);
        }//Show Cart
        //product region
        #region 

        private void button22_Click(object sender, EventArgs e)
        {


            Product Nikeshoe = new Shoes(1, "Nike Air Force", 350, 20, 36);
            showproduct frm = new showproduct(pictureBox6.Image, Nikeshoe);
            frm.CheckStock(S);
            frm.Show();

        }



        private void button6_Click_1(object sender, EventArgs e)
        {
            Product Cool_Shirts = new Shirts(5, "Cool Shirt", 30, 20, 's');
            showproduct frm = new showproduct(pictureBox10.Image, Cool_Shirts);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Product Nike_Old_Force = new Shoes(2, "Nike Old Force", 370, 20, 36);
            showproduct frm = new showproduct(pictureBox5.Image, Nike_Old_Force);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Product Women_low = new Shoes(3, "Women low shoe", 450, 20, 36);
            showproduct frm = new showproduct(pictureBox3.Image, Women_low);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Product Women_high = new Shoes(4, "Women high shoe", 144, 20, 36);
            showproduct frm = new showproduct(pictureBox4.Image, Women_high);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Product Polo = new Shirts(6, "Polo", 180, 20, 's');
            showproduct frm = new showproduct(pictureBox7.Image, Polo);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product Pants = new Pants(9, "gpants", 70, 20, 's');
            showproduct frm = new showproduct(pictureBox8.Image, Pants);
            frm.CheckStock(S);
            frm.Show();
        }


        private void button23_Click(object sender, EventArgs e)
        {
            Product jpants = new Pants(10, "jpants", 1000, 20, 's');
            showproduct frm = new showproduct(pictureBox9.Image, jpants);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Product adidsshirt = new Shirts(7, "Adidas", 1050, 20, 's');
            showproduct frm = new showproduct(shirtsq.Image, adidsshirt);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Product shirt = new Shirts(8, "C-Shirt", 780, 20, 's');
            showproduct frm = new showproduct(pictureBox13.Image, shirt);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Product Nikepants = new Pants(11, "Cool Nike Air Pants", 1000, 20, 's');
            showproduct frm = new showproduct(pictureBox12.Image, Nikepants);
            frm.CheckStock(S);
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Product Jordenpants = new Pants(12, "Cool Jorden Air Pants", 10500, 20, 's');
            showproduct frm = new showproduct(pictureBox11.Image, Jordenpants);
            frm.CheckStock(S);
            frm.Show();
        }
        #endregion//Product
        private void Order_Now_Click(object sender, EventArgs e)//Order and update sql
        {
            if (loginto)//check Login
            {
                MessageBox.Show("The Order Succeeded, You Will Pay to the delivery person");
                ItemOrder.Update((DataTable)dataGridView1.DataSource);
                dataGridView1.DataSource = ItemOrder.ItemsTable();
                showproduct.RemoveItem();
              
            }
            else
                MessageBox.Show("Login First");


        }
        public static void RemoveProducts(object temp)//remove product from stock
        {
            if (temp is Product[])
            {
                S.DecreaseProduct((Product[])temp);
            }
        }
        private Store MakeStore()//Make the stock
        {
            int[] sizes = new int[5] { 36, 37, 38, 39, 40 };
            string[] ShoesName = new string[4] { "Nike Air Force", "Nike Old Force", "Women low shoe", "Women high shoe" };
            int[] Prices = new int[4] { 350, 370, 450, 144 };
            int IDitem = 1;
            Store Items = new Store();
            for (int i = 0; i < ShoesName.Length; i++)
            {
                for (int j = 0; j < sizes.Length; j++)
                {
                    Items.ADDproduct(new Shoes(IDitem, ShoesName[i], Prices[i], 20, sizes[j]));
                }
                IDitem++;
            }
            string[] ShirtsName = new string[4] { "Cool Shirt", "Polo", "Adidas", "C-Shirt" };
            char[] ShirtsSize = new char[3] { 'S', 'M', 'L' };
            Prices = new int[4] { 30, 180, 1050, 780 };
            for (int i = 0; i < ShoesName.Length; i++)
            {
                for (int j = 0; j < ShirtsSize.Length; j++)
                {
                    Items.ADDproduct(new Shirts(IDitem, ShirtsName[i], Prices[i], 20, ShirtsSize[j]));
                }
                IDitem++;
            }
            string[] PantsName = new string[4] { "gpants", "jpants", "Cool Nike Air Pants", "Cool Jorden Air Pants" };
            int[] PantsSize = new int[5] { 36, 37, 38, 39, 40 };
            Prices = new int[4] { 70, 1000, 1000, 10500 };

            for (int i = 0; i < ShoesName.Length; i++)
            {
                for (int j = 0; j < PantsSize.Length; j++)
                {
                    Items.ADDproduct(new Pants(IDitem, PantsName[i], Prices[i], 20, PantsSize[j]));
                }
                IDitem++;
            }
            return Items;
        }

        private void button24_Click(object sender, EventArgs e)//Remove By ID Of Product
        {
            ItemOrder.Delete(int.Parse(textBox2.Text));
            MessageBox.Show("You Remove The Item");


        }

        private void Comper_price_by_code_Click(object sender, EventArgs e)
        {
            showsection(Zap);



        }//Open Zap

        private void Check_Click(object sender, EventArgs e)
        {
            try
            {
                Product temp = null;
                Product temp1 = null;

                if (comboBox2.Text == "Shoes")
                {
                    for (int i = 0; i < S.Allshoes.Length; i++)
                    {
                        if (S.Allshoes[i].ID == int.Parse(textBox3.Text))
                        {
                            temp = S.Allshoes[i];

                        }
                        else if (S.Allshoes[i].ID == int.Parse(textBox4.Text))
                        {
                            temp1 = S.Allshoes[i];
                        }


                    }


                }
                else if (comboBox2.Text == "Pants")
                {
                    for (int i = 0; i < S.AllPants.Length; i++)
                    {
                        if (S.AllPants[i].ID == int.Parse(textBox3.Text))
                        {
                            temp = S.AllPants[i];

                        }
                        else if (S.AllPants[i].ID == int.Parse(textBox4.Text))
                        {
                            temp1 = S.AllPants[i];
                        }


                    }
                }
                else if (comboBox2.Text == "Shirts")
                {
                    for (int i = 0; i < S.AllShirts.Length; i++)
                    {
                        if (S.AllShirts[i].ID == int.Parse(textBox3.Text))
                        {
                            temp = S.AllShirts[i];

                        }
                        else if (S.AllShirts[i].ID == int.Parse(textBox4.Text))
                        {
                            temp1 = S.AllShirts[i];
                        }


                    }
                }
                double price = temp.CompareTo(temp1);
                if (price == temp.Price)
                {
                    MessageBox.Show($"Code:{temp1.ID} Name:{temp1.Name}");
                }
                else
                    MessageBox.Show($"Code:{temp.ID} Name:{temp.Name}");
            }
            catch (Exception)
            {

                MessageBox.Show("Try Again");
            }

        }//ComperPriceZap
        static void SaveAsXmlFile(Customer customer, string path)//Xml customer
        {
            //IF EXISTS
            if (File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);
                XElement root = doc.Root;
                root.Add(new XElement("Customer",
                            new XElement("ID", customer.GetHashCode()),
                            new XElement("Full_Name", customer.Full_Name),
                            new XElement("Gender", customer.Gender),
                            new XElement("UserName", customer.UserName),
                            new XElement("Shiping_Address", customer.Shiping_Address),
                            new XElement("Phone_Number", customer.Phone_Number),
                            new XElement("Password", customer.Password)));
                doc.Save(path);
            }


            else
            {
                XDocument doc = new XDocument();
                XElement root = new XElement("Customers");
                doc.Add(root);
                root.Add(new XElement("Customer",
                            new XElement("ID", customer.GetHashCode()),
                            new XElement("Full_Name", customer.Full_Name),
                            new XElement("Gender", customer.Gender),
                            new XElement("UserName", customer.UserName),
                            new XElement("Shiping_Address", customer.Shiping_Address),
                            new XElement("Phone_Number", customer.Phone_Number),
                            new XElement("Password", customer.Password)));
                doc.Save(path);
            }
        }

        private void Join_Click_1(object sender, EventArgs e)//Join to the System
        {
            try
            {
                string Name = FullNamebox.Text;
                string Gender = comboBox1.Text;
                string username = UserNameBox.Text;
                string shipingadd = ShipingBox.Text;
                string phone = PhoneNumberbox.Text;
                string password = Passwordbox.Text;
                bool t = true;

                if (UserNames.Contains(username))
                {

                    MessageBox.Show("User Name is already taken");
                    t = false;
                }
                if (Name == string.Empty || username == string.Empty || shipingadd == string.Empty || phone == string.Empty || phone == string.Empty)
                {
                    MessageBox.Show("Please enter all the details");
                    t = false;

                }
                if (CheckNumberIsOk(phone) != true || phone.Length !=10 || CheckStringIsOk(Name) != true)
                {
                    MessageBox.Show($"Name must not contain digits\nPhone must be 10 numbers only");
                    t = false;

                }
                if (t)
                {
                    UserNames.Add(username);
                    Passwords.Add(password);
                    SaveAsXmlFile(new Customer(Name, Gender, username, shipingadd, phone, password), XmlPath);
                    File.AppendAllText(Pathusername, username + "\r\n");
                    File.AppendAllText(Pathpassword, password + "\r\n");
                    MessageBox.Show("You Sing Up - Now Login");

                }
            }
            catch (Exception)
            {

                MessageBox.Show("One of the valies is incorrect");
            }



        }

        private void Login_Click(object sender, EventArgs e)//Show Login Section
        {
            showsection(Loginpart);
        }

        private void Enter_Click(object sender, EventArgs e)//Enter to the System by login
        {
            try
            {
                string[] usernametemp = new string[UserNames.Count];
                string[] passwordtemp = new string[UserNames.Count];
                for (int i = 0; i < UserNames.Count; i++)
                {
                    usernametemp[i] = UserNames[i].ToString();
                    passwordtemp[i] = Passwords[i].ToString();
                }
                var check = from z in usernametemp
                            where z == checkuser.Text
                            select z;
                var check1 = from z in passwordtemp
                             where z == checkpassword.Text
                             select z;

                if (check.First() != null && check1.First() != null)
                {
                    hidesection();

                    userinfo.Text = $"Hello {checkuser.Text}";
                    userinfo.Visible = true;
                    if (SectionUser.Visible == true)
                    {
                        SectionUser.Visible = false;
                    }
                    MessageBox.Show($"Welcome Back {checkuser.Text}");
                    loginto = true;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Incorrecr Username or Password");
            }

        }
        public static bool CheckStringIsOk(string S)//check not number
        {
            foreach (char c in S)
            {
                if (c >= '0' && c <= '9')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckNumberIsOk(string S)//check only number
        {
            foreach (char c in S)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        
    }



}   

