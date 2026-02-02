using FinalTask.DiceG.Exceptions;

namespace FinalTask.DiceG
{
    public struct Dice
    {
        public readonly int Number => new Random().Next(_min, _max + 1);

        private int _min;
        private int _max;

        public Dice(int min, int max)
        {
            if (min < 1 || min > max)
                throw new WrongDiceNumberException(1, int.MaxValue, min);
            else if (max > int.MaxValue)
                throw new WrongDiceNumberException(1, int.MaxValue, max);
            else if (min > max)
                throw new WrongDiceNumberException(1, max, min);

            _min = min;
            _max = max;
        }
    }
}
