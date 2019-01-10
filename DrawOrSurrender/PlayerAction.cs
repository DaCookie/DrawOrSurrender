using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawOrSurrender
{
    /// <summary>
    /// Represents an available action for the player in the game.
    /// </summary>
    abstract class PlayerAction
    {

        private string _name = string.Empty;
        private string _description = string.Empty;
        // The string to display to show what key to press for this action
        private string _keyString = "1";
        // The key to press for this action
        private ConsoleKey _key = ConsoleKey.D1;

        public PlayerAction(string name, string description, string keyString, ConsoleKey key)
        {
            _name = name;
            _description = description;
            _keyString = keyString;
            _key = key;
        }

        /// <summary>
        /// Checks if this PlayerAction can be executed.
        /// </summary>
        public abstract bool CanDoAction(GameManager gameManager);

        /// <summary>
        /// Displays a string to display why this action can't be done (use Console.Write)
        /// Note that it's displayed only if the action is not available.
        /// </summary>
        public abstract void DisplayRequirements();

        /// <summary>
        /// Called when player press the key to trigger this action.
        /// </summary>
        public abstract void OnExecuteAction(GameManager gameManager);

        /// <summary>
        /// Displays the key, name and description of this action.
        /// </summary>
        public void DisplayActionInfos(GameManager gameManager)
        {
            bool canDoAction = CanDoAction(gameManager);

            if(!canDoAction)
            {
                Console.Write("/!\\ ");
            }

            Console.Write($"{_keyString} - {_name}: {_description}");
            Console.WriteLine("");

            if (!canDoAction)
            {
                Console.Write(" ");
                Console.Write(" ");
                Console.Write(" ");
                Console.Write(" ");
                DisplayRequirements();
            }
        }

        public string name
        {
            get { return _name; }
        }

        public ConsoleKey key
        {
            get { return _key; }
        }

    }
}
