using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dought
    {
        public string type;
        public string baking;
        public double weight;
        public string Type 
        {
            get
            {
                return this.type;
            }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.type = value;
            }
        }
        public string Baking
        {
            get
            {
                return this.baking;
            }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.baking = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value<1 || value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        public Dought(string type,string baking,double weight)
        {
            Type = type;
            Baking = baking;
            Weight = weight;
        }
        public double DoughCallories()
        {
            double typeCallories = 0;
            double backingCallories = 0;
            if (Type.ToLower()=="white")
            {
                typeCallories = 1.5;
            }
            else 
            {
                typeCallories = 1.0;
            }
            if (Baking.ToLower()=="crispy")
            {
                backingCallories = 0.9;
            }
            else if (Baking.ToLower()=="chewy")
            {
                backingCallories = 1.1;
            }
            else
            {
                backingCallories = 1.0;
            }
            return typeCallories * backingCallories * weight * 2;
        }


    }
}
