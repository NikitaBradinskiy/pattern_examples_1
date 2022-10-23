using System;

namespace PracticeTime3
{
    public interface IClonable
    {
        object Clone();
    }
    public class PlayerData : IClonable
    { 
        public int patrons { get; set; } // кол-во патронов
        public int lives { get; set; } // кол-во жизней
        public PlayerData(int patrons, int lives)
        {
            this.patrons = patrons;
            this.lives = lives;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
   public class HeroPlayer
    {
        private PlayerData _playerData;
        public HeroPlayer(PlayerData playerData)
        {
            _playerData = playerData;
        }
        public void Shoot()
        {
            if (_playerData.patrons > 0)
            {
                _playerData.patrons--;
                Console.WriteLine("Производим выстрел. Осталось {0} патронов", _playerData.patrons);
            }
            else
                Console.WriteLine("Патронов больше нет");
        }
        // сохранение состояния
        public void SaveState()
        {
            Console.WriteLine("Сохранение игры. Параметры: {0} патронов, {1} жизней", _playerData.patrons, _playerData.lives);
            StrategyMediator.Instance.PlayerSave(_playerData, this);
        }

        // восстановление состояния
        public void RestoreState()
        {
            StrategyMediator.Instance.PlayerRestore(ref _playerData, this);
            Console.WriteLine("Восстановление игры. Параметры: {0} патронов, {1} жизней", _playerData.patrons, _playerData.lives);
        }
    }
    // Memento
    public class HeroMemento
    {
        private readonly PlayerData _PlayerData;
        public PlayerData GetData() => _PlayerData;

        public HeroMemento(PlayerData playerData)
        {
            _PlayerData = playerData;
        }
    }

    // Caretaker
   public class GameHistory
   {
        public HeroMemento LastCheckPoint { get; set; }
        public GameHistory()
        {
            LastCheckPoint = null;
        }
   }
    public interface IGameMediator
    {
        void PlayerSave(PlayerData playerData, object sendler);
        void PlayerRestore(ref PlayerData playerData, object sendler);
    }
    public class StrategyMediator : IGameMediator
    {
        private GameHistory _gameHistory;
        private HeroPlayer _player;

        public static StrategyMediator Instance = new StrategyMediator();
        private StrategyMediator() { }
        public void Init(GameHistory gameHistory, HeroPlayer player)
        {
            _gameHistory = gameHistory;
            _player = player;
        }
        public void PlayerRestore(ref PlayerData playerData, object sendler)
        {
            if (sendler is HeroPlayer)
            {
                playerData = _gameHistory.LastCheckPoint.GetData();
            }
        }
        public void PlayerSave(PlayerData playerData, object sendler)
        {
             if(sendler is HeroPlayer)
             {
                _gameHistory.LastCheckPoint = new HeroMemento((PlayerData)playerData.Clone());
             }
        }
    }

}
