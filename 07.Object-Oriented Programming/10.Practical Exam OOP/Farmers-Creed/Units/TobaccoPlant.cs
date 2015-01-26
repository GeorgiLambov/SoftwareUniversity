namespace FarmersCreed.Units
{
    using System;

    public class TobaccoPlant : Plant
    {
        private const int TobaccoBasehealth = 12;
        private const int TobaccoGrowTime = 4;
        private const int TobaccoProductionQuantity = 10;
        private const ProductType TobaccoProductType = ProductType.Tobacco;

        public TobaccoPlant(string id)
            : base(id, TobaccoBasehealth, TobaccoProductionQuantity, TobaccoGrowTime)
        {
        }

        public override void Grow()
        {
            for (int i = 0; i < 2; i++)
            {
                base.Grow();
            }
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("You cannot exploit dead tobacco plants!");
            } 
            else if (!this.HasGrown)
            {
                throw new InvalidOperationException("Tobacco cannot be epxloited while growing!");
            }

            return new Product(this.Id + ProductIdSuffix, ProductType.Tobacco, this.ProductionQuantity);
        }
    }
}
