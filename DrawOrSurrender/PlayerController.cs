using System;
using System.Collections.Generic;

namespace DrawOrSurrender
{
    /// <summary>
    /// Lists the available player actions in the game and display informations about them.
    /// </summary>
    class PlayerController
    {

        private List<PlayerAction> _playerActions = new List<PlayerAction>();

        /// <summary>
        /// Makes a PlayerController with default actions: draw and surrender.
        /// </summary>
        public PlayerController()
        {
            //AddAction(new PlayerAction_Draw());
            //AddAction(new PlayerAction_Surrender());
        }

        /// <summary>
        /// Executes the first found action that uses the given key.
        /// </summary>
        /// <returns>Returns true if the action can be executed, otherwise false.</returns>
        public bool ExecuteAction(ConsoleKey key, GameManager gameManager)
        {
            foreach(PlayerAction action in _playerActions)
            {
                if (action.key == key && action.CanDoAction(gameManager))
                {
                    action.OnExecuteAction(gameManager);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Displays all the actions in standard output.
        /// </summary>
        public void DisplayPlayerActions(GameManager gameManager)
        {
            Console.WriteLine("ACTIONS:");
            foreach(PlayerAction action in _playerActions)
            {
                action.DisplayActionInfos(gameManager);
            }
        }

        /// <summary>
        /// Adds an action to the controller.
        /// </summary>
        /// <param name="newAction">The action to add.</param>
        /// <returns>Returns true if the operation is successful, otherwise false.</returns>
        public bool AddAction(PlayerAction newAction)
        {
            foreach(PlayerAction playerAction in _playerActions)
            {
                if(playerAction.name == newAction.name)
                {
                    return false;
                }
            }

            _playerActions.Add(newAction);
            return true;
        }

        /// <summary>
        /// Removes an action from the controller.
        /// </summary>
        /// <param name="actionName">The name of the action to remove.</param>
        /// <returns>Returns true if the operation is successful, otherwise false.</returns>
        public bool RemoveAction(string actionName)
        {
            int index = -1;
            for(int i = 0; i < _playerActions.Count; i++)
            {
                if(_playerActions[i].name == actionName)
                {
                    index = i;
                    break;
                }
            }

            if(index != -1)
            {
                _playerActions.RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Counts available actions for the player.
        /// </summary>
        public int actionsCount
        {
            get { return _playerActions.Count; }
        }

    }
}
