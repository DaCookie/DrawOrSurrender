using System;

namespace DrawOrSurrender
{
    /// <summary>
    /// Represents the player state.
    /// </summary>
    class Player
    {

        public string name = string.Empty;
        public int insanity = 0;
        public bool hasSurrender = false;

        /// <summary>
        /// Displays player informations.
        /// </summary>
        public void DisplayPlayerInfos()
        {
            Console.WriteLine($"{name.ToUpper()} STATS");
            Console.WriteLine("No stats to display");
        }

        /// <summary>
        /// Checks if the player can continue the story.
        /// </summary>
        public bool CanContinue()
        {
            return !hasSurrender;
        }

    }
}
