using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public abstract class MovingObject : WorldObject
    {
        public MovingObject(Point position, int owner)
            : base(position, owner)
        {
        }

        public void GoTo(Point destination)
        {
            this.Position = destination;
        }
    }
}
