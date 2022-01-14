using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten,double wingsize) 
            : base(name, weight, foodEaten)
        {
            WingSize = wingsize;
        }
        public double WingSize { get;private set; }
    }
}