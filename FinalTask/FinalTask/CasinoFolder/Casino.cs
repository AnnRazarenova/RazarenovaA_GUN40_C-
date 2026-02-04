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

        private const int MAX_PLAYER_BANK = 10000;

        private PlayerProfile _player;
        private int _playerBet;

        private CasinoGameBase _chosenGame;
        //private int _casinoBank { get; set; } = 100000;

        private FileSystemSaveLoadService<PlayerProfile> _service;

        public Casino() 
        {

        }

        public void StartGame()
        {
            Console.WriteLine($"WELCOME TO THE CASINO!");

            Console.WriteLine();

            _service = new FileSystemSaveLoadService<PlayerProfile>(FILE_PATH);

            CheckProfile();

            Console.WriteLine($"Your bank is: {_player.Bank}");
            Console.WriteLine();

            CreateGame();

            Console.WriteLine();

            SubscribeToGameEvents();

            PlayerPlaceBet();

            Console.WriteLine();

            _chosenGame.PlayGame();

            Console.WriteLine($"GoodBye {_player.Name}!");

            UnSubscribeToGameEvents();

            EndGame();
        }

        private void CheckProfile()
        {
            if (_service.PlayerHasProfile(FILE_NAME))
            {
                PlayerProfile profileData = _service.LoadData(FILE_NAME);

                _player = new PlayerProfile(profileData.Name, profileData.Bank);

                Console.WriteLine($"Welcome back {_player.Name}");
            }
            else
            {
                Console.WriteLine("Write your name:");
                _player = new PlayerProfile(Console.ReadLine(), MAX_PLAYER_BANK);
            }
        }

        private void CreateGame()
        {
            do
            {
                Console.WriteLine($"Choose your game: " +
                $"{ListOfGames.BlackJack} - {(int)ListOfGames.BlackJack}, " +
                $"{ListOfGames.Dice} - {(int)ListOfGames.Dice}");

                if (Enum.TryParse<ListOfGames>(Console.ReadLine(), out var game))
                {
                    switch (game)
                    {
                        case ListOfGames.BlackJack:
                            _chosenGame = new BlackJackGame(COUNT_CARDS_FOR_BLACKJACK);
                            return;
                        case ListOfGames.Dice:
                            _chosenGame = new DiceGame(COUNT_DICES_FOR_DICE, MIN_DICE_NUMBER, MAX_DICE_NUMBER);
                            return;
                    }
                }
            } while (true);
        }

        private void PlayerPlaceBet()
        {
            Console.WriteLine("Place your bet:");

            if(int.TryParse(Console.ReadLine(), out var bet))
            {
                if (bet > _player.Bank)
                    throw new ArgumentOutOfRangeException("Your bet should be lower then your bank");
                
                _playerBet = bet;
            }
        }

        private void SubscribeToGameEvents()
        {
            if (_chosenGame == null) 
                return;

            _chosenGame.OnWin += HandleWin;
            _chosenGame.Onlose += HandleLose;
            _chosenGame.OnDraw += HandleDraw;
        }

        private void UnSubscribeToGameEvents()
        {
            if (_chosenGame == null) 
                return;

            _chosenGame.OnWin -= HandleWin;
            _chosenGame.Onlose -= HandleLose;
            _chosenGame.OnDraw -= HandleDraw;
        }

        private void HandleWin(string message)
        {
            Console.WriteLine(message);

            Console.WriteLine();

            _player.Bank += _playerBet;

            CheckPlayerBank();
        }

        private void HandleLose(string message)
        {
            Console.WriteLine(message);

            Console.WriteLine();

            _player.Bank -= _playerBet;

            CheckPlayerBank();
        }

        private void HandleDraw(string message)
        {
            Console.WriteLine(message);
        }

        private void CheckPlayerBank()
        {
            if(_player.Bank > MAX_PLAYER_BANK)
            {
                _player.Bank = MAX_PLAYER_BANK;
                Console.WriteLine("You have ruined the casino and a new one will be built in its place.");
            }
            else
            if(_player.Bank < 0)
            {
                _player.Bank = MAX_PLAYER_BANK;
                Console.WriteLine("No money? Kicked!");
            }
        }

        private void EndGame()
        {
            _service.SaveData(_player, FILE_NAME);
        }
    }
}
