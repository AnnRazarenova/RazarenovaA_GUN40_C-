using FinalTask.BlackJack;
using FinalTask.DiceGame;
using FinalTask.Game;
using FinalTask.Interface;
using FinalTask.Player;

namespace FinalTask.Casino
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
                        chosenGame = new DiceGame();
                        break;
                }

            }
        }
    }
}
