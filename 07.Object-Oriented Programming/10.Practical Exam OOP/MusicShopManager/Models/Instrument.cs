namespace MusicShop.Models
{
    using System;
    using MusicShopManager.Interfaces;
    using System.Text;

    public abstract class Instrument : Article, IInstrument
    {
        private string color;

        public Instrument(string make, string model, decimal price, string color)
            : base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = false;
        }

        public string Color
        {
            get { return this.color; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The color is required.");
                }

                this.color = value;
            }
        }

        public bool IsElectronic { get; protected set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Color: {0}", this.Color).AppendLine()
                .AppendFormat("Electronic: {0}", this.IsElectronic ? "yes" : "no");
            return result.ToString();
        }
    }
}
