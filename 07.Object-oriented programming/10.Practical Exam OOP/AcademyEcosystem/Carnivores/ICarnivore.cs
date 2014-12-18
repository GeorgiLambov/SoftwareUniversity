using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public interface ICarnivore
    {
        int TryEatAnimal(Animal animal);
    }
}
