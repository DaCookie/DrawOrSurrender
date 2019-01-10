namespace DrawOrSurrender
{
    /// <summary>
    /// Represent an adventure that happens in a chapter.
    /// </summary>
    abstract class Adventure
    {

        /// <summary>
        /// Called when a chapter that contains this adventure is played.
        /// </summary>
        public abstract void ApplyEffect(GameManager gameManager);

        /// <summary>
        /// Displays the details of the adventure
        /// </summary>
        public abstract void DisplayAdventureInfos(GameManager gameManager);

    }
}
