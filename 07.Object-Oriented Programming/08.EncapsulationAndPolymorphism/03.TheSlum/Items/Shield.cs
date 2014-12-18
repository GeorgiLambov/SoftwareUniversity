namespace TheSlum
{
    public class Shield : Item
    {
        public Shield(string id, int healthEffect = 0, int defenseEffect = 50, int attackEffect = 0)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }
    }
}
