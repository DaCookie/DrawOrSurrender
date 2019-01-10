using System;

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
            Story story = new Story("Title of my story", "Context of my story...");

            // Init chapters
            Chapter basicChapter = new Chapter()
            {
                title = "A step ahead",
                text = "You keep walking in this endless land of silence and darkness."
            };

            // Add chapters to the story
            story.AddChapter(basicChapter, 5);

            story.Shuffle();
            return story;
        }
    }
}
