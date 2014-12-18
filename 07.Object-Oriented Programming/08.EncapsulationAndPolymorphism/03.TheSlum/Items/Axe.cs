namespace TheSlum
{
    public class Axe : Item
    {
        private string itemId;

        public Axe(string id, int healthEffect = 0, int defenseEffect = 0, int attackEffect = 75)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }
    }
}
