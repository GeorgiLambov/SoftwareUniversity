namespace FurnitureManufacturer.Engine
{
    using System;
    using System.Collections.Generic;

    using Interfaces.Engine;

    public class Command : ICommand
    {
        private const string NullOrEmptyNameErrorMessage = "Name cannot be null or empty";
        private const string NullCollectionOfParameters = "Collection of parameteres cannot be null";

        private const char SplitCommandSymbol = ' ';

        private string name;
        private IList<string> parameters;

        private Command(string input)
        {
            this.TranslateInput(input);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NullOrEmptyNameErrorMessage);
                }

                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return new List<string>(this.parameters);
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(NullCollectionOfParameters);
                }

                this.parameters = value;
            }
        }

        public static Command Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);

            this.Name = input.Substring(0, indexOfFirstSeparator);
            this.Parameters = input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
