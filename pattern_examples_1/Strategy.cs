using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    //Stone, Cut, Paper

    public abstract class HandState : IBeatable
    {
        public bool isAlive = true;
        public abstract void Beat<T>(T enemy) where T : HandState;
    }
    public interface IBeatable 
    {
        void Beat<T>(T enemy) where T : HandState;
    }
    public sealed class Stone : HandState
    {
        public override void Beat<T>(T enemy)
        {
            if (enemy is Stone) return;
            if (enemy is Scissors) enemy.isAlive = false;
            if (enemy is Paper) this.isAlive = false;
        }
    }
    public sealed class Scissors : HandState
    {
        public override void Beat<T>(T enemy)
        {
            if (enemy is Stone) this.isAlive = false; 
            if (enemy is Scissors) return; 
            if (enemy is Paper) enemy.isAlive = false;
        }
    }
    public sealed class Paper: HandState
    {
        public override void Beat<T>(T enemy)
        {
            if (enemy is Stone) enemy.isAlive = false; 
            if (enemy is Scissors) this.isAlive = false;
            if (enemy is Paper) return;
        }
    }
    public class PlayerSSP
    {
        private HandState _handState;
        public HandState PlayerHandState
        {
            get => _handState;
            set => _handState = value;
        }
        public PlayerSSP(HandState _handState)
        {
            this._handState = _handState;
        }
        public virtual void FightWith(PlayerSSP _anotherPlayer)
        {
            _handState.Beat<HandState>(_anotherPlayer.PlayerHandState);
        }
    }
}
