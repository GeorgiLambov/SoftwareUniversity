namespace FarmersCreed.Units
{
    using System;

    public class Plant : FarmUnit
    {
        public Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            throw new NotImplementedException();
        }

        public bool HasGrown
        {
            get { throw new NotImplementedException(); }
        }

        public int GrowTime
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void Water()
        {
            throw new NotImplementedException();
        }

        public void Wither()
        {
            throw new NotImplementedException();
        }

        public void Grow()
        {
            throw new NotImplementedException();
        }
    }
}
