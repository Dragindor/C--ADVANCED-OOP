using System;
using System.Collections.Generic;
using System.Text;

namespace ExEcapsulation
{
    public class Box
    {
        public double weight;
        public double length;
        public double height;
        public double Lenght
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Weight 
        {
            get
            {
                return this.weight; 
            }
                
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.weight = value;
            }
        }
       
        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Weight = width;
            
            Height = height;
        }
    }
}
