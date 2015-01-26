namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Animal : FarmUnit
    {
        private const int AnimalBaseStarveRate = 1;

        protected Animal(string id, int health, int producedQuantity)
            : base(id, health, producedQuantity)
        {
        }

        public virtual void Starve()
        {
            this.Health -= AnimalBaseStarveRate;
        }

        public abstract void Eat(IEdible food, int Quantity);
    }
}
