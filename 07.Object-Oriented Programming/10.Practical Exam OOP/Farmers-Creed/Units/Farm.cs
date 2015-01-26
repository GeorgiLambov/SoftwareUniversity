namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FarmersCreed.Interfaces;

    public class Farm : GameObject, IFarm
    {
        public Farm(string id)
            : base(id)
        {
            this.Animals = new List<Animal>();
            this.Plants = new List<Plant>();
            this.Products = new List<Product>();
        }

        public List<Animal> Animals { get; set; }

        public List<Plant> Plants { get; set; }

        public List<Product> Products { get; private set; }

        public void AddProduct(Product product)
        {
            var existingProduct = this.Products
                .FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
            }
            else
            {
                this.Products.Add(product);
            }
        }

        public void Exploit(IProductProduceable productProducer)
        {
            var product = productProducer.GetProduct();
            this.AddProduct(product);
        }

        public void Feed(Animal animal, IEdible product, int quantity)
        {
            product.Quantity -= quantity;
            animal.Eat(product, quantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            foreach (var plant in this.Plants)
            {
                if (!plant.HasGrown)
                {
                    plant.Grow();
                }
                else
                {
                    plant.Wither();
                }
            }

            foreach (var animal in this.Animals)
            {
                animal.Starve();
            }
        }

        public override string ToString()
        {
            StringBuilder farmInfo = new StringBuilder();
            farmInfo.AppendLine();

            var sortedAnimals = this.Animals
                .Where(a => a.IsAlive)
                .OrderBy(a => a.Id);

            var sortedPlants = this.Plants
                .Where(p => p.IsAlive)
                .OrderBy(p => p.Health)
                .ThenBy(p => p.Id);

            var sortedProducts = this.Products
                .OrderBy(p => p.ProductType.ToString())
                .ThenByDescending(p => p.Quantity)
                .ThenBy(p => p.Id);

            foreach (var animal in sortedAnimals)
            {
                farmInfo.AppendLine(animal.ToString());
            }

            foreach (var plant in sortedPlants)
            {
                farmInfo.AppendLine(plant.ToString());
            }

            foreach (var product in sortedProducts)
            {
                farmInfo.AppendLine(product.ToString());
            }

            return base.ToString() + farmInfo.ToString();
        }
    }
}
