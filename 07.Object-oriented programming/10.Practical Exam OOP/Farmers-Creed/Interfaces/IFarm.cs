namespace FarmersCreed.Interfaces
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Units;

    public interface IFarm 
    {
        List<Plant> Plants { get; }

        List<Animal> Animals { get; }

        List<Product> Products { get; }

        void AddProduct(Product product);

        void Exploit(IProductProduceable productProducer);

        void Feed(Animal animal, IEdible edibleProduct, int productQuantity);

        void Water(Plant plant);

        void UpdateFarmState();
    }
}
