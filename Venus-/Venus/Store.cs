using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus
{
    class Store
    {
        public  Shoes[] Allshoes;
        public Pants[] AllPants;
        public Shirts[] AllShirts;
       
        public Store()
        {
            Allshoes = new Shoes[0] { };
            AllPants = new Pants[0] { };
            AllShirts = new Shirts[0] { };
            
        }

        public void ADDproduct(Product item)
        {
            if (item is Shoes)
            {
                Shoes [] tempArr = new Shoes[Allshoes.Length + 1];
                for (int i = 0; i < Allshoes.Length; i++)
                {
                    tempArr[i] = Allshoes[i];
                }
                tempArr[Allshoes.Length] = (Shoes)item;
                Allshoes = tempArr;
            }
            else if (item is Pants)
            {
                Pants[] tempArr = new Pants[AllPants.Length + 1];
                for (int i = 0; i < AllPants.Length; i++)
                {
                    tempArr[i] = AllPants[i];
                }
                tempArr[AllPants.Length] = (Pants)item;
                AllPants = tempArr;
            }
            else if (item is Shirts)
            {
                Shirts[] tempArr = new Shirts[AllShirts.Length + 1];
                for (int i = 0; i < AllShirts.Length; i++)
                {
                    tempArr[i] = AllShirts[i];
                }
                tempArr[AllShirts.Length] = (Shirts)item;
                AllShirts = tempArr;
            }
           
        }

        public void DecreaseProduct(Product[] orderItems)
        {
            for (int i = 0; i < orderItems.Length; i++)
            {
                if (orderItems[i] is Shoes)
                {
                    for (int j = 0; j < Allshoes.Length; j++)
                    {
                        if (Allshoes[j].ID == orderItems[i].ID && Allshoes[j].Size == ((Shoes)orderItems[i]).Size)
                        {
                            Allshoes[j].UpdateStock(-1);
                        }
                    }
                }
                else if (orderItems[i] is Pants)
                {
                    for (int j = 0; j < AllPants.Length; j++)
                    {
                        if (AllPants[j].ID == orderItems[i].ID && AllPants[j].Size == ((Pants)orderItems[i]).Size)
                        {
                            AllPants[j].UpdateStock(-1);
                        }
                    }
                }
                else if (orderItems[i] is Shirts)
                {
                    for (int j = 0; j < AllShirts.Length; j++)
                    {
                        if (AllShirts[j].ID == orderItems[i].ID && AllShirts[j].Size == ((Shirts)orderItems[i]).Size)
                        {
                            AllShirts[j].UpdateStock(-1);
                        }
                    }
                }
        }
        }
    }
}
