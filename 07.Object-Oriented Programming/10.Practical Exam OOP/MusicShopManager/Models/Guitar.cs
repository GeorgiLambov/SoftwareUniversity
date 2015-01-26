namespace MusicShop.Models
{
    using System;
    using System.Text;
    using MusicShopManager.Interfaces;

    public abstract class Guitar : Instrument, IGuitar
    {
        private string bodyWood;
        private string fingerboardWood;
        private int numberOfStrings = 6;

        public Guitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
            : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
            this.IsElectronic = false;
        }

        public string BodyWood
        {
            get { return this.bodyWood; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The bodyWood is required.");
                }

                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get { return this.fingerboardWood; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The fingerboardWood is required.");
                }

                this.fingerboardWood = value;
            }
        }

        public int NumberOfStrings
        {
            get { return this.numberOfStrings; }
            protected set { this.numberOfStrings = value; }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Strings: {0}", this.NumberOfStrings).AppendLine()
                .AppendFormat("Body wood: {0}", this.BodyWood).AppendLine()
                .AppendFormat("Fingerboard wood: {0}", this.FingerboardWood);

            return result.ToString();
        }
    }
}
