using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public interface IFighter : IControllable
    {
        int AttackPoints
        {
            get;
        }

        int DefensePoints
        {
            get;
        }

        int GetTargetIndex(List<WorldObject> availableTargets);
    }
}
