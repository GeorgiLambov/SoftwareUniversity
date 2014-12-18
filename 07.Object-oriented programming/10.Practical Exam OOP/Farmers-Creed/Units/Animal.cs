namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public class Animal : FarmUnit
    {
        public Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public void Eat(IEdible food, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
