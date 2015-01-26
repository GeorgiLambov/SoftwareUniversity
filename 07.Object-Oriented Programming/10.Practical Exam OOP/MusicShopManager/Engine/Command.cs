namespace MusicShopManager.Engine
{
    using System;
    using System.Collections.Generic;
    using MusicShopManager.Interfaces.Engine;

    public class Command : ICommand
    {
        private const char CommandNameSeparator = '[';
        private const char CommandParameterSeparator = ';';
        private const char CommandValueSeparator = ':';

        private string name;
        private IDictionary<string, string> parameters = new Dictionary<string, string>();

        public Command(string input)
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
                    throw new ArgumentNullException("The command name is required.");
                }

                this.name = value;
            }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The command parameters are required.");
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
            int parametersBeginning = input.IndexOf(CommandNameSeparator);

            this.Name = input.Substring(0, parametersBeginning);
            var parametersKeysAndValues = input.Substring(parametersBeginning + 1, input.Length - parametersBeginning - 2)
                .Split(new[] { CommandParameterSeparator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var parameter in parametersKeysAndValues)
            {
                var split = parameter.Split(new[] { CommandValueSeparator }, StringSplitOptions.RemoveEmptyEntries);
                this.Parameters.Add(split[0], split[1]);
            }
        }
    }
}