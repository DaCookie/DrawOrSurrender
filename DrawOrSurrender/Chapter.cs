using System;

namespace DrawOrSurrender
{
    /// <summary>
    /// Represents a step in a Story.
    /// </summary>
    class Chapter
    {

        public string title = string.Empty;
        public string text = string.Empty;
        public Adventure[] adventures = { };

        /// <summary>
        /// Plays this chapter:
        ///     - displays its informations
        ///     - display all adventures
        ///     - apply the effects of all adventures
        /// </summary>
        public void Play(GameManager gameManager)
        {
            DisplayChapterInfos();
            Console.WriteLine("");

            foreach (Adventure adventure in adventures)
            {
                adventure.DisplayAdventureInfos(gameManager);
                adventure.ApplyEffect(gameManager);
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Displays this chapter infos.
        /// </summary>
        public void DisplayChapterInfos()
        {
            Console.WriteLine(title);
            Console.WriteLine(text);
        }

    }
}
