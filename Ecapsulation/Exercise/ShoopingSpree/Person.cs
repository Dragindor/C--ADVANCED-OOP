using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShoopingSpree
{
    public class Person :IEnumerable
    {
        public List<Product> products;
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
                if (value == null || value == string.Empty || value == " ")
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
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }
        public bool CanBuy(Person person,Product product )
        {
            if (person.Money>=product.Money)
            {
                products.Add(product);
                person.Money -= product.Money;
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)products).GetEnumerator();
        }
    }
}
