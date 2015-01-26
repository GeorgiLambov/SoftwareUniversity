namespace MusicShop.Models
{
    using System;
    using MusicShopManager.Interfaces;
    using System.Text;
    public class ElectricGuitar : Guitar, IElectricGuitar
    {

        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets)
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
            this.IsElectronic = true;
            this.NumberOfStrings = 6;
        }

        public int NumberOfAdapters
        {
            get { return this.numberOfAdapters; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The numberOfAdapters must be positive.");
                }

                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get { return this.numberOfFrets; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The numberOfFrets must be positive.");
                }

                this.numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Adapters: {0}", this.NumberOfAdapters).AppendLine()
                .AppendFormat("Frets: {0}", this.NumberOfFrets);

            return result.ToString();
        }
    }
}
