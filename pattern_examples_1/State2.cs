using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    //public enum PlayerState // How to replace??
    //{
    //    Eat,
    //    Work,
    //    Sleep
    //}
    public interface IStateChangable
    {
        void ChangeState(PlayerState playerState);
    }
    public abstract class PlayerState 
    {
        public void Change(PlayerSIMS player, PlayerState playerState) => player._PlayerState = playerState;
    }
    public class PlayerSIMS : IStateChangable
    {
        private PlayerState _playerState;
        public PlayerState _PlayerState
        {
            get => _playerState;
            set => _playerState = value;
        }
        public PlayerSIMS(PlayerState idleState)
        {
            _playerState = idleState;
        }
        public void ChangeState(PlayerState playerState)
        {
            _playerState.Change(this, playerState);
        }
    }
    public sealed class EatState : PlayerState
    {
       
    }
    public sealed class WorkState : PlayerState
    {
        
    }
    public sealed class SleepState : PlayerState
    {

    }

}
