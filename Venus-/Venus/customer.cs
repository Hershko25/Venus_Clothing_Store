using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus
{
    class Customer
    {
        static int numOfCustomers = 0;
        public int ID { get; set; }
        public string Full_Name { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string Shiping_Address { get; set; }
        public string Phone_Number { get; set; }
        public string Password { get; set; }


        public Customer(string fName, string gender, string Uname, string Shipadres, string phoneNum, string password)
        {
            numOfCustomers++;
            ID = numOfCustomers;
            Full_Name = fName;
            Gender = gender;
            UserName = Uname;
            Shiping_Address = Shipadres;
            Phone_Number = phoneNum;
            Password = password;
        }

        public override string ToString()
        {
            return $"ID : {ID} Full name : {Full_Name} Gender : {Gender} User name : {UserName} Shiping Address : {Shiping_Address} Phone number : {Phone_Number}";
        }

        public override int GetHashCode()
        {
            return ID;
        }
        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                return GetHashCode() == ((Product)obj).GetHashCode();
            }
            return false;
        }


    }
}
