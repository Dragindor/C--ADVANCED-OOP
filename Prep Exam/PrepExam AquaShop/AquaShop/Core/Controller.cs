using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {

        private List<IAquarium> aquariums;
        private DecorationRepository decorations;
        public Controller()
        {
            aquariums = new List<IAquarium>();
            decorations = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {            
            if (aquariumType== "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                
                decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                decorations.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded,decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            string aquariumType = aquarium.GetType().Name;
            if ((aquariumType== "FreshwaterAquarium" && fishType== "SaltwaterFish") || (aquariumType == "SaltwaterAquarium" && fishType == "FreshwaterFish"))
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }
            

            IFish fish;

            if (fishType== "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName,fishSpecies,price);
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium,fishType,aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sum = aquarium.Fish.Sum(x=>x.Price)+ aquarium.Decorations.Sum(x => x.Price);
            return string.Format(OutputMessages.AquariumValue,aquariumName,Math.Round(sum,2));
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed,aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration found = decorations.FindByType(decorationType);
            if (found==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }
            IAquarium aquarium = aquariums.FirstOrDefault(x=>x.Name==aquariumName);
            aquarium.AddDecoration(found);
            decorations.Remove(found);
            return string.Format(OutputMessages.EntityAddedToAquarium,decorationType,aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.Append(aquarium.GetInfo()+Environment.NewLine);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
