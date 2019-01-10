using System;
using System.Collections.Generic;

namespace DrawOrSurrender
{
    class Program
    {

        /// <summary>
        /// Entry point of the game.
        /// </summary>
        static void Main(string[] args)
        {
            Story story = MakeStory();

            GameManager gameManager = new GameManager(story);
            AddCustomActions(gameManager.playerController);

            // Starts Game loop
            while (gameManager.Update())
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Complete this method to add custom actions to the game.
        /// </summary>
        private static void AddCustomActions(PlayerController controller)
        {

        }

        /// <summary>
        /// Rewrite this method to make your own story.
        /// </summary>
        private static Story MakeStory()
        {
            // Init story
            Story story = new Story("The Gorm", "You are going to hunt for the Gorm. The air becomes thick and foul...");

            // Init chapters
            Chapter basicChapter = new Chapter()
            {
                title = "A step ahead",
                text = "You keep walking in this endless land of silence and darkness."
            };

            Chapter shadowEncounter = new Chapter()
            {
                title = "Unexpected encounter",
                text = "I don't know what can make sounds like that...",
                adventures = new Adventure[]
                {
                    new Adventure_FightMonster("a strange shadow force", 2)
                }
            };

            Chapter lionEncounter = new Chapter()
            {
                title = "White Lion",
                text = "The great white lion is never just here for a hug!",
                adventures = new Adventure[]
                {
                    new Adventure_FightMonster("a white lion", 1)
                }
            };

            // Add chapters to the story
            story.AddChapter(basicChapter, 8);
            story.AddChapter(shadowEncounter, 1);
            story.AddChapter(lionEncounter, 3);

            story.Shuffle();
            return story;
        }
    }
}
