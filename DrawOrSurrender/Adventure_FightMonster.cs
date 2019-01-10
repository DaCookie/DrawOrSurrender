using System;

namespace DrawOrSurrender
{
    class Adventure_FightMonster : Adventure
    {

        private string _monsterName = string.Empty;
        private int _insanityGain = 1;

        public Adventure_FightMonster(string monsterName, int insanityGain)
        {
            _monsterName = monsterName;
            _insanityGain = insanityGain;
        }

        public override void ApplyEffect(GameManager gameManager)
        {
            gameManager.player.insanity += _insanityGain;
        }

        public override void DisplayAdventureInfos(GameManager gameManager)
        {
            Console.WriteLine($"{gameManager.player.name} is trapped by {_monsterName}. He gains +{_insanityGain} of insanity.");
        }

    }
}
