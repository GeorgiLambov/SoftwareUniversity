namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public class Food : Product, IEdible
    {
        public Food(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, quantity)
        {
            this.HealthEffect = healthEffect;
            this.FoodType = foodType;
        }

        public FoodType FoodType { get; set; }

        public int HealthEffect { get; set; }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Food Type: {0}, Health Effect: {1}",
                this.FoodType, this.HealthEffect);
        }
    }
}
