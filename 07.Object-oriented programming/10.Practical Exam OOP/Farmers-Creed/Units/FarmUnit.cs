using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable 
    {
        public FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            throw new NotImplementedException();
        }

        public int Health
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsAlive
        {
            get { throw new NotImplementedException(); }
        }

        public int ProductionQuantity
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Product GetProduct()
        {
            throw new NotImplementedException();
        }
    }
}
