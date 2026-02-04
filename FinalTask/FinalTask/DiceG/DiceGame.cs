using FinalTask.Game;

namespace FinalTask.DiceG
{
    internal class DiceGame : CasinoGameBase
    {
        private int _computerScore = 0;
        private int _playerScore = 0;

        private List<Dice> _playerDices;
        private List<Dice> _computerDices;

        private int _diceCount;
        private int _minValue;
        private int _maxValue;

        public DiceGame(int diceCount, int minValue, int maxValue) 
        {
            if (diceCount <= 0)
                throw new ArgumentException("Dices count must be greater than 0");
            if (minValue <= 0)
                throw new ArgumentException("Min value must be greater than 0");
            if (maxValue <= 0)
                throw new ArgumentException("Max value must be greater than 0");

            _diceCount = diceCount;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override void PlayGame()
        {
            CreateDices();

            CalculateScore();

            CheckWhoWin();
        }

        protected override void FactoryMethod()
        {
            _playerDices = new List<Dice>(_diceCount);
            _computerDices = new List<Dice>(_diceCount);
        }

        private void CreateDices()
        {
            for (int i = 0; i < _diceCount; i++)
            {
                _playerDices.Add(new Dice(_minValue, _maxValue));
                _computerDices.Add(new Dice(_minValue, _maxValue));
            }
        }

        private void CalculateScore()
        {
            for (int i = 0; i < _playerDices.Count; i++)
            {
                _playerScore += _playerDices[i].Number;
                _computerScore += _computerDices[i].Number;
            }
        }

        private void CheckWhoWin()
        {
            if (_playerScore > _computerScore)
            {
                OnWinInvoke();
                ShowDices();
            }
            else
            if (_playerScore < _computerScore)
            {
                OnLoseInvoke();
                ShowDices();
            }
            else
            if (_playerScore == _computerScore)
            {
                OnDrawInvoke();
                ShowDices();
            }
        }

        private void ShowDices()
        {
            Console.WriteLine("Player's dices:");
            for (int i = 0; i < _playerDices.Count; i++)
            {
                Console.WriteLine($"{_playerDices[i].Number}");
            }

            Console.WriteLine();

            Console.WriteLine($"Player's score: {_playerScore}");

            Console.WriteLine();

            Console.WriteLine("Dealer's dices:");
            for (int i = 0; i < _computerDices.Count; i++)
            {
                Console.WriteLine($"{_computerDices[i].Number}");
            }

            Console.WriteLine();
            
            Console.WriteLine($"Dealer's score: {_computerScore}");
        }
    }
}
