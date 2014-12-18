namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Interfaces;

    public class Farm : GameObject, IFarm
    {
        public Farm(string id)
            : base(id)
        {
        }

        public List<Plant> Plants
        {
            get { throw new NotImplementedException(); }
        }

        public List<Animal> Animals
        {
            get { throw new NotImplementedException(); }
        }

        public List<Product> Products
        {
            get { throw new NotImplementedException(); }
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void Exploit(IProductProduceable productProducer)
        {
            throw new NotImplementedException();
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            throw new NotImplementedException();
        }

        public void Water(Plant plant)
        {
            throw new NotImplementedException();
        }

        public void UpdateFarmState()
        {
            // TODO: Process all animal and plant behavior
            throw new NotImplementedException();
        }
    }
}
