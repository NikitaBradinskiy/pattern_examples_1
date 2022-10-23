using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    public abstract class TransferMoneyHandler 
    {
        public TransferMoneyHandler Successor;
        public abstract void SolveRequest();
        public void HandleTransferRequest(TransferMoneyHandler platform)
        {
            if(this.GetType() == platform.GetType())
            {
                SolveRequest();
            }
            else
            {
                if (Successor != null)
                {
                    Successor.HandleTransferRequest(platform);
                }
            }
           
        }
    }
    public sealed class KiwiManager: TransferMoneyHandler
    {
        public static KiwiManager Instance = new KiwiManager();
        private KiwiManager() { }
        public override void SolveRequest()
        {
            Console.WriteLine("Completed by KiwiWallet");
        }
    }
    public sealed class PayPalManager : TransferMoneyHandler
    {
        public static PayPalManager Instance = new PayPalManager();
        private PayPalManager() { }
        public override void SolveRequest()
        {
            Console.WriteLine("Completed by PayPalWallet");
        }
    }
    public sealed class KyivstarManager : TransferMoneyHandler
    {
        public static KyivstarManager Instance = new KyivstarManager();
        private KyivstarManager() { }
        public override void SolveRequest()
        {
            Console.WriteLine("Completed by KyivstarWallet");
        }
    }
}
