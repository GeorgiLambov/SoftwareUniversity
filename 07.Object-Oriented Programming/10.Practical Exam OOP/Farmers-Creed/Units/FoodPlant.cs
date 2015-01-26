namespace FarmersCreed.Units
{
    using System;

    public abstract class FoodPlant : Plant
    {
        private const int FoodPlantBaseWaterEffect = 1;

        protected FoodPlant(string id, int health, int producedQuantity, int growTime, int healthEffect)
            : base(id, health, producedQuantity, growTime)
        {
            this.ProductHealthEffect = healthEffect;
        }

        public int ProductHealthEffect { get; set; }

        public override void Water()
        {
            this.Health += FoodPlantBaseWaterEffect;
        }

        public override void Wither()
        {
            for (int i = 0; i < 2; i++)
            {
                base.Wither();
            }
        }
    }
}
