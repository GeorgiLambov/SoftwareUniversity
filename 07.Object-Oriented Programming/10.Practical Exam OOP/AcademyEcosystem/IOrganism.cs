using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public interface IOrganism
    {
        bool IsAlive { get; }

        Point Location { get; }

        int Size { get; }

        void Update(int timeElapsed);
    }
}
