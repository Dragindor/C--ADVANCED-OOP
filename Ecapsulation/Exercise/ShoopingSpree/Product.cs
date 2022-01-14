using System;
using System.Collections.Generic;
using System.Text;

namespace ShoopingSpree
{
    public class Product
    {
        public string name;
        public double money;
        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value==null|| value==string.Empty || value==" ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public double Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public Product(string name,double money)
        {
            Name = name;
            Money = money;
        }



    }
}
