namespace FinalTask.Game
{
    public abstract class CasinoGameBase
    {
        public delegate void GameResultHandler(string message);

        public event GameResultHandler OnWin;
        public event GameResultHandler Onloose;
        public event GameResultHandler OnDraw;
        public CasinoGameBase() 
        {
            FactoryMethod();
        }

        public abstract void PlayGame();

        protected void OnWinInvoke(string playerName, int money) => OnWin?.Invoke($"Congratulations! {playerName} win!!! {playerName}'s money = {money}");
        protected void OnLooseInvoke(string playerName, int money) => Onloose?.Invoke($"Sorry! {playerName} loose!!! {playerName}'s money = {money}");
        protected void OnDrawInvoke() => OnDraw?.Invoke("Continue game");

        protected abstract void FactoryMethod();

    }
}
