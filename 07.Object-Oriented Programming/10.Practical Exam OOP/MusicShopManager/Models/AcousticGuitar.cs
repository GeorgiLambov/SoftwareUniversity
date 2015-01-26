namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using MusicShopManager.Models;
    using System.Text;

    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private bool caseIncluded;

        public AcousticGuitar(string make, string model, decimal price, string color,
             string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded
        {
            get { return this.caseIncluded; }
            private set { this.caseIncluded = value; }
        }

        public StringMaterial StringMaterial { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Case included: {0}", this.CaseIncluded ? "yes" : "no")
                .AppendLine()
                .AppendFormat("String material: {0}", this.StringMaterial);

            return result.ToString();
        }
    }
}
