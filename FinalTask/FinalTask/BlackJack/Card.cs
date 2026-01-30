namespace FinalTask.BlackJack
{
    public struct Card
    {
        public readonly CardSizes Size;

        public readonly CardSuits Suit;

        public Card(CardSizes size, CardSuits suit)
        {
            Size = size;
            Suit = suit;
        }
    }
}
