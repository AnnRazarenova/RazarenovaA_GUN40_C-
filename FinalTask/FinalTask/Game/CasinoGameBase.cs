namespace FinalTask.Game
{
    public abstract class CasinoGameBase
    {
        public delegate void GameResultHandler(string message);

        public event GameResultHandler OnWin;
        public event GameResultHandler Onlose;
        public event GameResultHandler OnDraw;
        public CasinoGameBase() 
        {
            FactoryMethod();
        }

        public abstract void PlayGame();

        protected void OnWinInvoke() => OnWin?.Invoke($"Congratulations! You win!!!");
        protected void OnLoseInvoke() => Onlose?.Invoke($"Sorry! You loose!!!");
        protected void OnDrawInvoke() => OnDraw?.Invoke("Opa! You have a draw!!!");

        protected abstract void FactoryMethod();

    }
}
