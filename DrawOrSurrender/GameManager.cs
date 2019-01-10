using System;

namespace DrawOrSurrender
{
    /// <summary>
    /// Manager a game and all its components.
    /// </summary>
    class GameManager
    {

        private Player _player = null;
        private PlayerController _playerController = null;
        private Story _story = null;

        private bool _storyStarted = false;

        /// <summary>
        /// Avoid creating GameManager without a story.
        /// </summary>
        private GameManager() { }

        /// <summary>
        /// Creates a GameManager for playing the given story.
        /// </summary>
        public GameManager(Story story)
        {
            _story = story;
            _playerController = new PlayerController();
        }

        /// <summary>
        /// Updates the game and UI.
        /// </summary>
        /// <returns>Returns true if the game continues, otherwise false.</returns>
        public bool Update()
        {
            // If the player hasn't been set yet
            if(_player == null)
            {
                MakePlayer();
                return true;
            }

            // If the story didn't start
            if(!_storyStarted)
            {
                _story.DisplayStoryInfos();
                _storyStarted = true;
                return true;
            }

            // If the player lost the game
            if (!_player.CanContinue())
            {
                Console.WriteLine($"{_player.name} can't continue the adventure...");
            }
            // If there's no remaining chapters in the story
            else if(_story.remainingChapters == 0)
            {
                Console.WriteLine($"{_player.name} has reach the end of the story!");
            }
            // If the player doesn't have any action to do
            else if(_playerController.actionsCount == 0)
            {
                Console.WriteLine($"{_player.name} can't do anything now...");
            }
            // If the player can continue the game
            else
            {
                RunTurn();
                return true;
            }

            // Display Game Over screen
            Console.WriteLine("");
            Console.WriteLine("----- GAME OVER! -----");
            Console.WriteLine("");

            _player.DisplayPlayerInfos();
            Console.WriteLine("");

            Console.WriteLine("STORY STATE");
            Console.WriteLine($"{_story.remainingChapters} chapters left, completed at {_story.completionPercentage}%");
            Console.ReadKey();

            return false;
        }

        /// <summary>
        /// Requires the user action, and run a game turn.
        /// </summary>
        private void RunTurn()
        {
            int tries = 0;

            ConsoleKeyInfo keyInfo;
            do
            {
                _player.DisplayPlayerInfos();
                Console.WriteLine("");

                _playerController.DisplayPlayerActions(this);
                Console.WriteLine("");

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("Press the key of the action you want to execute.");
                Console.WriteLine("");

                if(tries > 0)
                {
                    Console.WriteLine("Impossible to execute the required action...");
                }

                keyInfo = Console.ReadKey();
                Console.Clear();
                tries++;
            }
            while (!_playerController.ExecuteAction(keyInfo.Key, this));
        }

        /// <summary>
        /// Asks player to enter a name, and create its character.
        /// </summary>
        private void MakePlayer()
        {
            Console.WriteLine("Name your player: ");
            _player = new Player();
            _player.name = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine($"You are {_player.name}!");
        }

        public PlayerController playerController
        {
            get { return _playerController; }
        }

        public Player player
        {
            get { return _player; }
        }

        public Story story
        {
            get { return _story; }
        }

    }
}
