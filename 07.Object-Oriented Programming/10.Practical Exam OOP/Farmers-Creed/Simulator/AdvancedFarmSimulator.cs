namespace FarmersCreed.Simulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FarmersCreed.Units;
    using FarmersCreed.Interfaces;

    public class AdvancedFarmSimulator : FarmSimulator
    {
        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "TobaccoPlant":
                    {
                        var tobaccoPlant = new TobaccoPlant(id);
                        this.farm.Plants.Add(tobaccoPlant);
                    }
                    break;
                case "CherryTree":
                    {
                        var cherryTree = new CherryTree(id);
                        this.farm.Plants.Add(cherryTree);
                    }
                    break;
                case "Swine":
                    {
                        var swine = new Swine(id);
                        this.farm.Animals.Add(swine);
                    }
                    break;
                case "Cow":
                    {
                        var cow = new Cow(id);
                        this.farm.Animals.Add(cow);
                    }
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }

        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');
            string action = inputCommands[0];

            switch (action)
            {
                case "water":
                    {
                        string plantId = inputCommands[1];

                        var plant = this.GetPlantById(plantId);
                        this.farm.Water(plant);
                    }
                    break;
                case "feed":
                    {
                        string animalId = inputCommands[1];
                        string productId = inputCommands[2];
                        int quantity = int.Parse(inputCommands[3]);

                        var animal = this.GetAnimalById(animalId);
                        var product = this.GetProductById(productId) as IEdible;

                        this.farm.Feed(animal, product, quantity);
                    }
                    break;
                case "exploit":
                    {
                        string unitType = inputCommands[1];
                        string id = inputCommands[2];

                        if (unitType == "animal")
                        {
                            var animal = this.GetAnimalById(id);
                            this.farm.Exploit(animal);
                        }
                        else
                        {
                            var plant = this.GetPlantById(id);
                            this.farm.Exploit(plant);
                        }
                    }
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }
        }
    }
}
