using System;

namespace DrawOrSurrender
{
    class PlayerAction_Surrender : PlayerAction
    {

        public PlayerAction_Surrender()
            : base("Surrender", "You lose.", "S", ConsoleKey.S)
        { }

        public override bool CanDoAction(GameManager gameManager)
        {
            return true;
        }

        public override void DisplayRequirements()
        {
            Console.Write("No requirements.");
        }

        public override void OnExecuteAction(GameManager gameManager)
        {
            gameManager.player.hasSurrender = true;
            Console.WriteLine($"{gameManager.player.name} surrenders...");
        }

    }
}
