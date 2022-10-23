using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    // Host => Managers (try to handle your task) (GameDev Team)
    public enum Task
    {
        Draw,
        Program,
        CreateMusic,
    }
    public abstract class ManagerHandler
    {
        public bool isEnable = true;
        public abstract Task TaskPattern { get; }
        public ManagerHandler Successor { get; set; }
        protected abstract void Solve(Task task) ;
        public void HandlerRequest(Task task)
        {
            if (task == this.TaskPattern && this.isEnable)
            {
                this.isEnable = false;
                Solve(task);
            }
            else
            {
                if (Successor != null) Successor.HandlerRequest(task);
            }
        }
    }
    public class Designer : ManagerHandler
    {
        private static Task _taskPattern = Task.Draw;
        public override Task TaskPattern => _taskPattern;

        protected override void Solve(Task task)
        {
            Console.WriteLine("Resolve Design issue");
        }
    }
    public class Programer : ManagerHandler
    {
        private static Task _taskPattern = Task.Program;
        public override Task TaskPattern => _taskPattern;
        protected override void Solve(Task task)
        {
            Console.WriteLine("program task is completed");
        }
    }
    public class OrganizationManager
    {
        public static Queue<Task> _Tasks;
        public OrganizationManager(Queue<Task> tasks)
        {
            _Tasks = tasks;
        }
    }
    public class TeamChain
    {
        private List<ManagerHandler> _managers;
        public TeamChain(List<ManagerHandler> managers)
        {
            _managers = managers;
            for (int i = 0; i < _managers.Count - 1; i++)
            {
                _managers[i].Successor = _managers[i + 1];
            }
        }
        public void Work()
        { 
            if(_managers != null)
            _managers[0].HandlerRequest(OrganizationManager._Tasks.Dequeue());
        }
    }
}
