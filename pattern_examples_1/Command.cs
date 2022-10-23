using System;
using System.Collections.Generic;


namespace PracticeTime3
{
    // King => command to Army
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class MacroCommand : ICommand
    {
        public List<ICommand> _entireCommands;
        public MacroCommand(List<ICommand> entireCommands)
        {
            _entireCommands = entireCommands;
        }
        public void Execute()
        {
            foreach(var command in _entireCommands)
            {
                command.Execute();
            }
        }
        public void Undo()
        { 
            
        }
    }
    public abstract class KingCommand : ICommand
    {
        public abstract ArmyOrder CurrentOrder { get; set; }
        public void Execute()
        {
            CurrentOrder.ExecuteOrder();
        }

        public void Undo()
        {
          
        }
    }

    public sealed class NullCommand : ICommand
    {
        public void Execute() { }
        public void Undo() { }
    }

    public class King
    {
        ICommand _kingCommand = new NullCommand();
        public void SetCommand(ICommand _kingCommand) => this._kingCommand = _kingCommand;
        public void PlayCommand() => _kingCommand.Execute();
        public void Cancel() => _kingCommand.Undo();
    }
    public abstract class ArmyOrder
    {
        public ArmyOrder() => InitializeEvent();

        protected event Action ExecutingOrder;
        protected abstract void InitializeEvent();
        public void ExecuteOrder() => ExecutingOrder?.Invoke();
    }
    public sealed class RunArmy : ArmyOrder
    {
        protected override void InitializeEvent()
        {
            ExecutingOrder += PrintRun;
        }
        private void PrintRun()
        {
            Console.WriteLine("Run");
        }
    }
    public sealed class StayArmy : ArmyOrder
    {
        protected override void InitializeEvent()
        {
            ExecutingOrder += PrintStay;
        }
        private void PrintStay() => Console.WriteLine("Stay!!");
    }
}
