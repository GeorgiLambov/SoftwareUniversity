using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.GameEngine
{
    public class ExtendedEngine : Engine
    {
        public override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    PrintCharactersStatus(characterList);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
                case "create":
                    CreateCharacter(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            string id = inputParams[2];
            int positionX = int.Parse(inputParams[3]);
            int positionY = int.Parse(inputParams[4]);

            Team team = inputParams[5] == "Blue" ? Team.Blue : Team.Red;

            switch (inputParams[1].Trim())
            {
                case "warrior":
                    characterList.Add(new Warrior(id, positionX, positionY, team));
                    break;
                case "mage":
                    characterList.Add(new Mage(id, positionX, positionY, team));
                    break;
                case "healer":
                    characterList.Add(new Healer(id, positionX, positionY, team));
                    break;
            }

        }

        protected new void AddItem(string[] inputParams)
        {
            Character characterToAcceptIthem = GetCharacterById(inputParams[1]);
            string itemId = inputParams[3];
            Item itemToAdd;

            switch (inputParams[2].Trim())
            {
                case "axe":
                    itemToAdd = new Axe(itemId);
                    characterToAcceptIthem.AddToInventory(itemToAdd);
                    break;
                case "pill":
                    itemToAdd = new Pill(itemId);
                    characterToAcceptIthem.AddToInventory(itemToAdd);
                    break;
                case "shield":
                    itemToAdd = new Shield(itemId);
                    characterToAcceptIthem.AddToInventory(itemToAdd);
                    break;
                case "injection":
                    itemToAdd = new Injection(itemId);
                    characterToAcceptIthem.AddToInventory(itemToAdd);
                    break;
            }
        }
    }
}
