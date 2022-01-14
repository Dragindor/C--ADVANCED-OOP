using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories.Contracts
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;
        public IReadOnlyCollection<IDecoration> Models => decorations;
        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }
        public void Add(IDecoration model)
        {
            decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration Found = decorations.FirstOrDefault(x=>x.GetType().Name==type);
            return Found;
        }

        public bool Remove(IDecoration model)
        {
            IDecoration Found = decorations.FirstOrDefault(x => x.Equals(model));
            if (Found == null)
            {
                return false;
            }
            decorations.Remove(Found);
            return true;
        }
    }
}
