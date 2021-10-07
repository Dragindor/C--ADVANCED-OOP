using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Dyes;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Eggs;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }

            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny found = bunnies.FindByName(bunnyName);
            if (found==null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);

            }
            found.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded,power,bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName,energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded,eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);
            List<IBunny> readyBunnies = bunnies.Models.Where(x=>x.Energy>=0).OrderByDescending(x=>x.Energy).ToList();
            Workshop workshop = new Workshop();
            if (readyBunnies.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            while (readyBunnies.Any())
            {
                IBunny currentBunny = readyBunnies.First();

                while (true)
                {
                    if (currentBunny.Energy == 0 || currentBunny.Dyes.All(x => x.IsFinished()))
                    {
                        readyBunnies.Remove(currentBunny);
                        if (currentBunny.Energy == 0)
                        {
                            bunnies.Remove(currentBunny);
                        }
                        break;
                    }

                    workshop.Color(egg, currentBunny);


                    if (egg.IsDone())
                    {
                        break;
                    }
                }

                if (egg.IsDone())
                {
                    break;
                }
            }
            if (egg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            return string.Format(OutputMessages.EggIsNotDone,eggName);

        }

        public string Report()
        {
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{eggs.Models.Count(x=>x.IsDone()==true)} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var item in bunnies.Models)
            {
                sb.AppendLine($"Name: {item.Name}");
                sb.AppendLine($"Energy: {item.Energy}");
                sb.AppendLine($"Dyes: {item.Dyes.Count(x=>!x.IsFinished())} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
