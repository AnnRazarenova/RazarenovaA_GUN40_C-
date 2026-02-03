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

        private bool _gameEnd = false;

        public DiceGame(int diceCount, int minValue, int maxValue) 
        {
            _diceCount = diceCount;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override void PlayGame()
        {
            //FactoryMethod();
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
                _gameEnd = true;
            }
            else
            if (_playerScore < _computerScore)
            {
                OnLoseInvoke();
                ShowDices();
                _gameEnd = true;
            }
            else
            if (_playerScore == _computerScore)
            {
                OnDrawInvoke();
                ShowDices();
                _gameEnd = true;
            }
        }

        private void ShowDices()
        {

        }
    }
}
