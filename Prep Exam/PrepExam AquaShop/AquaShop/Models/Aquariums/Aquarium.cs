using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium

    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(x=>x.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        protected Aquarium(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }
        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (Capacity<=Fish.Count+1)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            Fish.Add(fish);
            
        }

        public void Feed()
        {
            foreach (IFish fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.name} ({this.GetType().Name}):");
            if (Fish.Count==0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                   sb.AppendLine($"Fish: {string.Join(", ",this.Fish.Select(x=>x.Name))}");
            }
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            IFish found = Fish.FirstOrDefault(x=>x.Equals(fish));
            if (found==null)
            {
                return false;
            }
            Fish.Remove(found);
            return true;

        }
    }
}
