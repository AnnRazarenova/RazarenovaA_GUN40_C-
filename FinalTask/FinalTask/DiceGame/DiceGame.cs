using FinalTask.Game;

namespace FinalTask.DiceGame
{
    internal class DiceGame : CasinoGameBase
    {
        private int computerScore = 0;
        private int playerScore = 0;

        private List<Dice> dices;

        private int DiceCount;
        private int MinValue;
        private int MaxValue;

        public DiceGame(int diceCount, int minValue, int maxValue) 
        {
            DiceCount = diceCount;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public override void PlayGame()
        {
            //FactoryMethod();


        }

        protected override void FactoryMethod()
        {
            dices = new List<Dice>(DiceCount);
            for (int i = 0; i < DiceCount; i++)
            {
                dices.Add(new Dice(MinValue, MaxValue));
            }
        }
    }
}
