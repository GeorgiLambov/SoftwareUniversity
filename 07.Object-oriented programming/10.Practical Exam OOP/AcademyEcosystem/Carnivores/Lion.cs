using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int WolfSize = 6;
        public Lion(string name, Point location)
            : base(name, location, WolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (animal.Size <= this.Size * 2))
            {
                this.Size += 1;
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
