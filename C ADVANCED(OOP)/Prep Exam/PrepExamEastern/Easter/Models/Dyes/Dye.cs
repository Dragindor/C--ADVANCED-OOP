using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                if (value < 0)
                {
                    power = 0; ;
                }
                this.power = value;
            }
        }

        public bool IsFinished()
        {
            if (power==0)
            {
                return true;
            }
            return false;
        }

        public void Use()
        {
            Power -= 10;
        }

        public static implicit operator List<object>(Dye v)
        {
            throw new NotImplementedException();
        }
    }
}
