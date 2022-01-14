using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string BirthDate { get; set; }

        public Citizen(string name,int age,string id,string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthdate;
        }
    }
}
