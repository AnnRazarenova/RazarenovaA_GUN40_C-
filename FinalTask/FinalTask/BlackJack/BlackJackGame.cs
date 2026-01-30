using FinalTask.Game;

namespace FinalTask.BlackJack
{
    internal class BlackJackGame : CasinoGameBase
    {
        private Queue<Card> _deck;

        private List<Card> _playerCards = new List<Card>();
        private List<Card> _computerCards = new List<Card>();

        private int _playerScore = 0;
        private int _computerScore = 0;

        private int _countCards;

        private bool gameEnd = false;
        public BlackJackGame(int countCards)
        {
            if (countCards <= 0)
                throw new ArgumentException("Wrong cards count");

            _countCards = countCards;
        }

        protected override void FactoryMethod() => _deck = new Queue<Card>(_countCards);

        public override void PlayGame()
        {
            //FactoryMethod();
            //тут тоже что-то надо (конструктор БлекДжека, иначе в шафл не сделается(кол-ва карт не будет))
            CreateCards();

            GameStart();

            while(gameEnd == false)
            {
                CalculateScore();

                CheckWhoWin();
            }
            //идёт процесс игры и условия на блекджек и т.п.
        }

        private void CheckWhoWin()
        {
            if (_playerScore == _computerScore && _playerScore < 21)
            {
                _playerCards.Add(DrawCard());
                _computerCards.Add(DrawCard());
            }
            else
                if(_playerScore <= 21 && (_computerScore > 21 || _computerScore < _playerScore))
            {
                OnWinInvoke();
            }
            else
                if(_computerScore <= 21 && (_playerScore > 21 || _playerScore < _computerScore))
            {
                OnLoseInvoke();
            }
            else
            if(_playerScore >= 21 && _computerScore >= 21)
            {
                OnDrawInvoke();
            }
        }

        private void CalculateScore()
        {
            for (int i = 0; i < _playerCards.Count; i++)
            {
                _playerScore += GetValue(_playerCards[i].Size, _playerScore);
                _computerScore += GetValue(_computerCards[i].Size, _computerScore);
            }
        }

        private void CreateCards()
        {
            List<Card> deckList = new List<Card>();
            foreach (CardSizes cardSize in Enum.GetValues(typeof(CardSizes)))
            {
                foreach (CardSuits cardSuit in Enum.GetValues(typeof(CardSuits)))
                {
                    deckList.Add(new Card(cardSize, cardSuit));
                }
            }

            Shuffle(deckList);
        }

        private int GetValue(CardSizes cardSize, int score)
        {
            return cardSize switch
            {
                CardSizes.Six => 6,
                CardSizes.Seven => 7,
                CardSizes.Eight => 8,
                CardSizes.Nine => 9,
                CardSizes.Ten or CardSizes.Jack or CardSizes.Queen or CardSizes.King => 10,
                CardSizes.Ace => score == 20 ? 11 : 1,
                _ => 0,
            };
        }

        private void Shuffle(List<Card> cards)
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }

            for (int i = 0; i < _countCards; i++)
            {
                _deck.Enqueue(cards[i]);
            }
        }

        private Card DrawCard()
        {
            //проверка на пустоту в дэк
            if (_deck == null || _deck.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty");
            }

            return _deck.Dequeue();
        }

        private void GameStart()
        {
            _playerCards.Add(DrawCard());
            _playerCards.Add(DrawCard());

            _computerCards.Add(DrawCard());
            _computerCards.Add(DrawCard());
        }
    }
}
