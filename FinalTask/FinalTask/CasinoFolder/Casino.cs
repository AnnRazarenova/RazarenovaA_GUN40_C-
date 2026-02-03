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
        private int playerBet;

        private CasinoGameBase chosenGame;
        private int CasinoBank { get; set; } = 100000;

        private string CasinoName { get; }

        private FileSystemSaveLoadService<PlayerProfile> service;

        public Casino(string name) 
        {
            CasinoName = name;
        }

        public void StartGame()
        {
            Console.WriteLine($"WELCOME TO THE CASINO {CasinoName}!");

            service = new FileSystemSaveLoadService<PlayerProfile>(FILE_PATH);

            CheckProfile();

            Console.WriteLine($"Your bank is: {player.Bank}");

            Console.WriteLine($"Choose your game: " +
                $"{ListOfGames.BlackJack} - {(int)ListOfGames.BlackJack}, " +
                $"{ListOfGames.Dice} - {(int)ListOfGames.Dice}");

            CreateGame();

            SubscribeToGameEvents();

            PlayerPlaceBet();

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

                Console.WriteLine($"Welcome back {player.Name}");
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

        private void PlayerPlaceBet()
        {
            Console.WriteLine("Place your bet:");

            if(int.TryParse(Console.ReadLine(), out var bet))
            {
                if (bet > player.Bank)
                    throw new ArgumentOutOfRangeException("Your bet should be lower then your bank");
                
                playerBet = bet;
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

            player.Bank += playerBet;

            service.SaveData(player, FILE_NAME);
        }

        private void HandleLose(string message)
        {
            Console.WriteLine(message);

            player.Bank -= playerBet;

            service.SaveData(player, FILE_NAME);
        }

        private void HandleDraw(string message)
        {
            Console.WriteLine(message);

            service.SaveData(player, FILE_NAME);
        }

        private void CheckCasinoBank()
        {

        }
    }
}
