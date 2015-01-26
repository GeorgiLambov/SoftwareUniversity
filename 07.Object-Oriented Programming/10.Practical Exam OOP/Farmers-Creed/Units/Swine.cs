namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public class Swine : Animal
    {
        private const int SwineBasehealth = 20;
        private const ProductType SwineProductType = ProductType.PorkMeat;
        private const FoodType SwineFoodType = FoodType.Meat;
        private const int SwineHealthEffect = 5;
        private const int SwineProductQuantity = 1;

        public Swine(string id)
            : base(id, SwineBasehealth, SwineProductQuantity)
        {
        }

        public override void Starve()
        {
            for (int i = 0; i < 3; i++)
            {
                base.Starve();
            }
        }

        public override void Eat(IEdible food, int quantity)
        {
            switch (food.FoodType)
            {
                case FoodType.Organic:
                case FoodType.Meat:
                    this.Health += food.HealthEffect * quantity * 2;
                    break;
                default:
                    break;
            }
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Dead swines cannot produce!");
            }

            base.Die();
            return new Food(this.Id + ProductIdSuffix, SwineProductType, SwineFoodType,
                SwineProductQuantity, SwineHealthEffect);
        }
    }
}
