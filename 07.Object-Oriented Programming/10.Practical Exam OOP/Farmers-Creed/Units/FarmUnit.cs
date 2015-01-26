namespace FarmersCreed.Units
{
    using System;
    using System.Text;
    using FarmersCreed.Interfaces;

    public abstract class FarmUnit : GameObject, IProductProduceable 
    {
        protected const string ProductIdSuffix = "Product";

        private int producedQuantity;

        protected FarmUnit(string id, int health, int producedQuantity)
            : base(id)
        {
            this.Id = id;
            this.Health = health;
            this.ProductionQuantity = producedQuantity;
        }

        public int Health { get; set; }

        public bool IsAlive
        {
            get { return this.Health > 0; }
        }

        public int ProductionQuantity
        {
            get
            {
                return this.producedQuantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product quantity cannot be negarive!");
                }
                this.producedQuantity = value;
            }
        }

        public abstract Product GetProduct();

        public override string ToString()
        {
            return base.ToString() +
                (this.IsAlive ? String.Format(", Health: {0}", this.Health) : ", DEAD");
        }

        protected virtual void Die()
        {
            this.Health = 0;
        }
    }
}
