namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Plant : FarmUnit
    {
        private const int PlantBaseGrowRate = 1;
        private const int PlantBaseWitherRate = 1;
        private const int PlantBaseWaterEffect = 2;

        private int growTime;

        protected Plant(string id, int health, int producedQuantity, int growTime)
            : base(id, health, producedQuantity)
        {
            //this.ProductionQuantity = producedQuantity;
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get { return this.GrowTime <= 0; }
        }

        public int GrowTime 
        {
            get { return this.growTime; }
            set { this.growTime = value; }
        }

        public virtual void Water()
        {
            this.Health += PlantBaseWaterEffect;
        }

        public virtual void Wither()
        {
            this.Health -= PlantBaseWitherRate;
        }

        public virtual void Grow()
        {
            this.GrowTime -= PlantBaseGrowRate;
        }

        public override string ToString()
        {
            StringBuilder plantInformation = new StringBuilder();
            
            if (this.IsAlive)
            {
                plantInformation.AppendFormat(", Grown: {0}",
                    this.HasGrown ? "Yes" : "No");

            }

            return base.ToString() + plantInformation.ToString();
        }
    }
}
