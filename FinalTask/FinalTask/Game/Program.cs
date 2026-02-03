using FinalTask.CasinoFolder;

namespace FinalTask.Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Casino casino = new Casino("Las Vegas"); 
            casino.StartGame();
        }
    }
}
