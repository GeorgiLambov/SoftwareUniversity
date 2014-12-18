namespace FarmersCreed.Simulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FarmersCreed.Interfaces;
    using FarmersCreed.Units;

    public class FarmSimulator
    {
        private const string LoopEndCommand = "END";

        protected IFarm farm;

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != LoopEndCommand)
            {
                this.ProcessInput(input);

                if (!input.StartsWith("status"))
                {
                    this.farm.UpdateFarmState();
                }
                input = Console.ReadLine();
            }
        }

        protected virtual void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "create":
                    {
                        string farmId = inputCommands[1];
                        this.farm = new Farm(farmId);
                    }
                    break;
                case "add":
                    {
                        this.AddObjectToFarm(inputCommands);
                    }
                    break;
                case "status":
                    {
                        this.PrintObjectStatus(inputCommands);
                    }
                    break;
                default:
                    break;
            }    
        }

        protected virtual void PrintObjectStatus(string[] inputCommands)
        {
            string objectType = inputCommands[1];

            switch (objectType)
            {
                case "farm":
                    {
                        Console.WriteLine(this.farm);
                    }
                    break;
                case "plant":
                    {
                        var plant = this.GetPlantById(inputCommands[2]);
                        Console.WriteLine(plant);
                    }
                    break;
                case "animal":
                    {
                        var animal = this.GetAnimalById(inputCommands[2]);
                        Console.WriteLine(animal);
                    }
                    break;
                case "product":
                    {
                        var product = this.GetProductById(inputCommands[2]);
                        if (product is Food)
                        {
                            Console.WriteLine(product as Food);
                        }
                        else
                        {
                            Console.WriteLine(product);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        protected virtual void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "Grain":
                    {
                        var food = new Food(id, ProductType.Grain, FoodType.Organic, 10, 2);
                        this.farm.AddProduct(food);
                    }
                    break;
                default:
                    break;
            }
        }

        protected Animal GetAnimalById(string id)
        {
            return this.farm.Animals.First(x => x.Id == id);
        }

        protected Plant GetPlantById(string id)
        {
            return this.farm.Plants.First(x => x.Id == id);
        }

        protected Product GetProductById(string id)
        {
            return this.farm.Products.First(x => x.Id == id);
        }
    }
}
