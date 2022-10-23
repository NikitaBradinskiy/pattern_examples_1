using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    // Transport => TeplateMethod (Recover)
    public abstract class RecoverAssistant
    {
        public void Recover()
        {
            Repair();
            FillFuel();
            ChangeWeels();
        }
        protected abstract void Repair();
        protected abstract void FillFuel();
        protected abstract void ChangeWeels();
    }
    public class Car : RecoverAssistant
    {
        protected override void ChangeWeels()
        {
            Console.WriteLine("New car weels");
        }

        protected override void FillFuel()
        {
            Console.WriteLine("New car fuel");
        }

        protected override void Repair()
        {
            Console.WriteLine("New car engine");
        }
    }
  
}
