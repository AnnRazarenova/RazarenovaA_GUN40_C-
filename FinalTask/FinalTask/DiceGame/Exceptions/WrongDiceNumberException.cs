namespace FinalTask.DiceGame.Exceptions
{
    public sealed class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int min, int max, int number) : base($"Invalid value of number: {number}. The range is: {min} - {max}") { }
    }
}
