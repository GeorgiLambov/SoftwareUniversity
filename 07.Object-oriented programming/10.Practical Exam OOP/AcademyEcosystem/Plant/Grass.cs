using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        private const int GrassSize = 2;
        public Grass(Point location)
            : base(location, GrassSize)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }

            base.Update(time);
        }
    }
}
