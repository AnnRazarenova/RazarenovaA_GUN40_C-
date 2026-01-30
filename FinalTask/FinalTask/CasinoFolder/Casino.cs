using FinalTask.BlackJack;
using FinalTask.DiceG;
using FinalTask.Game;
using FinalTask.Interface;
using FinalTask.Player;

namespace FinalTask.CasinoFolder
{
    public class Casino : IGame
    {
        private const string FILE_NAME = "PlayerProfile";
        private const string FILE_PATH = "Saves";

        private const int COUNT_CARDS_FOR_BLACKJACK = 36;
        private const int COUNT_DICES_FOR_DICE = 5;
        private const int MIN_DICE_NUMBER = 1;
        private const int MAX_DICE_NUMBER = 6;

        private PlayerProfile player;

        private CasinoGameBase chosenGame;
        private int Bank { get; set; }

        private FileSystemSaveLoadService<PlayerProfile> service;

        public Casino() 
        {
            
        }

        public void StartGame()
        {
            Console.WriteLine("WELCOME TO THE CASINO!");

            service = new FileSystemSaveLoadService<PlayerProfile>(FILE_PATH);

            CheckProfile();

            Console.WriteLine($"Your bank is: {player.Bank}");

            Console.WriteLine($"Choose your game: " +
                $"{ListOfGames.BlackJack} - {(int)ListOfGames.BlackJack}, " +
                $"{ListOfGames.Dice} - {(int)ListOfGames.Dice}");

            CreateGame();

            SubscribeToGameEvents();

            chosenGame.PlayGame();
                //сам процесс казино
                //выбор игры, вызов нужного конструктора, и вызов метода плейгейм

        }

        private void CheckProfile()
        {
            if (service.PlayerHasProfile(FILE_NAME))
            {
                PlayerProfile profileData = service.LoadData(FILE_NAME);

                player = new PlayerProfile(profileData.Name, profileData.Bank);
            }
            else
            {
                Console.WriteLine("Write your name:");
                player = new PlayerProfile(Console.ReadLine(), 10000);
            }
        }

        private void CreateGame()
        {
            if (Enum.TryParse<ListOfGames>(Console.ReadLine(), out var game))
            {
                switch (game)
                {
                    case ListOfGames.BlackJack:
                        chosenGame = new BlackJackGame(COUNT_CARDS_FOR_BLACKJACK);
                        break;
                    case ListOfGames.Dice:
                        chosenGame = new DiceGame(COUNT_DICES_FOR_DICE, MIN_DICE_NUMBER, MAX_DICE_NUMBER);
                        break;
                }
            }
        }

        private void SubscribeToGameEvents()
        {
            if (chosenGame == null) return;

            chosenGame.OnWin += HandleWin;
            chosenGame.Onlose += HandleLose;  // Обратите внимание на опечатку: "Onloose" (две 'o')
            chosenGame.OnDraw += HandleDraw;
        }

        private void HandleWin(string message)
        {
            Console.WriteLine(message);

            //начислить деньги

            service.SaveData(player, player.Name);
        }

        private void HandleLose(string message)
        {
            Console.WriteLine(message);

            //вычесть деньги

            service.SaveData(player, player.Name);
        }

        private void HandleDraw(string message)
        {
            Console.WriteLine(message);

            service.SaveData(player, player.Name);
        }
    }
}
