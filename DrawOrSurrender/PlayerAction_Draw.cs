using System;

namespace DrawOrSurrender
{
    class PlayerAction_Draw : PlayerAction
    {

        public PlayerAction_Draw()
            : base("Draw", "Draws a new chapter.", "D", ConsoleKey.D)
        { }

        public override bool CanDoAction(GameManager gameManager)
        {
            // Can execute action if there's at least one chapter to draw.
            return gameManager.story.remainingChapters > 0;
        }

        public override void DisplayRequirements()
        {
            Console.Write("The story deck is empty!");
        }

        public override void OnExecuteAction(GameManager gameManager)
        {
            Chapter chapter = gameManager.story.PickNextChapter(true);
            Console.Clear();
            chapter.Play(gameManager);
        }

    }
}
