using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public interface IGatherer : IControllable
    {
        bool TryGather(IResource resource);
    }
}
