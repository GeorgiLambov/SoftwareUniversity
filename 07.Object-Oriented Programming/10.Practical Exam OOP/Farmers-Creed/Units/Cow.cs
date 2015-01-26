namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public class Cow : Animal
    {
        private const int CowBaseHealth = 15;
        private const int CowProductHealthEffect = 4;
        private const int CowProductQuantity = 6;
        private const int CowHealthLossPerProduction = 2;

        public Cow(string id)
            : base(id, CowBaseHealth, CowProductQuantity)
        {
        }

        public override void Eat(IEdible food, int quantity)
        {
            switch (food.FoodType)
            {
                case FoodType.Organic:
                    this.Health += food.HealthEffect * quantity;
                    break;
                case FoodType.Meat:
                    this.Health -= food.HealthEffect * quantity;
                    break;
                default:
                    break;
            }
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Dead cows cannot produce!");
            }

            this.Health -= CowHealthLossPerProduction;

            return new Food(this.Id + ProductIdSuffix, ProductType.Milk,
                FoodType.Organic, CowProductQuantity, CowProductHealthEffect);
        }
    }
}
