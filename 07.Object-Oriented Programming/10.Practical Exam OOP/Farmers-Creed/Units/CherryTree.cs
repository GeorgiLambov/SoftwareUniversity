namespace FarmersCreed.Units
{
    using System;

    public class CherryTree : FoodPlant
    {
        private const int CherryBaseHealth = 14;
        private const int CherryGrowTime = 3;
        private const int CherryProductionQuantity = 4;
        private const ProductType CherryProductType = ProductType.Cherry;
        private const FoodType CherryFoodType = FoodType.Organic;
        private const int CherryHealthEffect = 2;

        public CherryTree(string id)
            : base(id, CherryBaseHealth, CherryProductionQuantity, CherryGrowTime, CherryHealthEffect)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("You cannot exploit dead cherries!");
            }

            return new Food(this.Id + ProductIdSuffix, CherryProductType,
                CherryFoodType, this.ProductionQuantity, CherryHealthEffect);
        }
    }
}
