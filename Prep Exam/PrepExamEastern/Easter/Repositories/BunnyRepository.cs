using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;

        public BunnyRepository()
        {
            models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => models;

        public void Add(IBunny model)
        {
            models.Add(model);
        }

        public IBunny FindByName(string name)
        {
            IBunny found = models.FirstOrDefault(x => x.Name == name);
            return found;
        }

        public bool Remove(IBunny model)
        { 
            if (!models.Contains(model))
            {
                return false;
            }
            models.Remove(model);
            return true;
        }
    }
}
