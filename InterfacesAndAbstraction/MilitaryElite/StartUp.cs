using MilitaryElite.Classes;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISolder> result = new List<ISolder>();
            List<Private> Privates = new List<Private>();
            
            while (true)
            {
                string[] person = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (person[0]=="End")
                {
                    break;
                }
                int Id = int.Parse(person[1]);
                string FirstName = person[2];
                string LastName = person[3];
                if (person[0] == "Spy")
                {
                    int codenumber = int.Parse(person[4]);
                    var spy = new Spy(Id,FirstName,LastName,codenumber);
                    //Console.WriteLine(spy);
                    result.Add(spy);
                    continue;

                }
                decimal salary = decimal.Parse(person[4]);
                if (person[0] == "Private")
                {
                    var Private = new Private(Id, FirstName, LastName, salary);
                    //Console.WriteLine(Private);
                    result.Add(Private);
                    Privates.Add(Private);
                    
                    continue;
                }
                else if (person[0] == "LieutenantGeneral")
                {
                    List<Private> LieutenantPrivates = new List<Private>();
                    for (int i = 5; i < person.Length; i++)
                    {
                        var pRivate = Privates.FirstOrDefault(x=>x.Id==int.Parse(person[i]));
                        if (pRivate!=null)
                        {
                            LieutenantPrivates.Add(pRivate);
                        }
                    }
                    var Lientenant = new LieutenantGeneral(Id,FirstName,LastName,salary,LieutenantPrivates);
                    //Console.WriteLine(Lientenant);
                    result.Add(Lientenant);
                    continue;
                }
                else if (person[0] == "Commando")
                {
                    if (person[5]!= "Airforces" && person[5] != "Marines")
                    {
                        continue;
                    }
                    List<Mission> Missions = new List<Mission>();
                    for (int i = 6; i < person.Length; i+=2)
                    {
                        if (person[i+1]=="inProgress" || person[i + 1] == "Finished")
                        {                            
                            Missions.Add(new Mission(person[i], person[i + 1]));
                        }
                        
                    }
                    var Commando = new Commando(Id, FirstName, LastName, salary,person[5], Missions);
                    //Console.WriteLine(Commando);
                    result.Add(Commando);

                }
                else if (person[0] == "Engineer")
                {
                    if (person[5] != "Airforces" && person[5] != "Marines")
                    {
                        continue;
                    }
                    List<Repairs> Repairs = new List<Repairs>();
                    for (int i = 6; i < person.Length; i += 2)
                    {
                           Repairs.Add(new Repairs(person[i], int.Parse(person[i + 1])));
                    }
                    var engineer = new Engineer(Id, FirstName, LastName, salary, person[5], Repairs);
                    //Console.WriteLine(engineer);
                    result.Add(engineer);
                }

            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }


        }
    }
}
