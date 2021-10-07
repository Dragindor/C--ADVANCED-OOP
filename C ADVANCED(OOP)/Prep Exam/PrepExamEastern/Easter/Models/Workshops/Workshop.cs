using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && bunny.Dyes.Any())
            {
                IDye currDye = bunny.Dyes.First();

                while (!currDye.IsFinished() && !egg.IsDone() && bunny.Energy > 0)
                {
                    bunny.Work();
                    egg.GetColored();
                    currDye.Use();
                }

                if (currDye.IsFinished())
                {
                    bunny.Dyes.Remove(currDye);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
