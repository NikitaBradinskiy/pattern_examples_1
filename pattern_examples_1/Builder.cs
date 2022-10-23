using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    // CarBuilder => BMW => Client => Developer

    public interface IBuilder
    {
        void SetPartA();
        void SetPartB();
        Sendwitch GetResult();
    }
    public class Sendwitch 
    {
        public List<object> partsSendwitch;
        public Sendwitch()
        {
            partsSendwitch = new List<object>();
        }
        public void AddPart(object part) => partsSendwitch.Add(part);
    }
    public class SendwitchBuilder : IBuilder
    {
        Sendwitch _sendwitch = new Sendwitch();
        public readonly PartA A;
        public readonly PartB B;
        public SendwitchBuilder(PartA APart, PartB BPart)
        {
            A = APart;
            B = BPart;
        }
        public Sendwitch GetResult()
        {
            return _sendwitch;
        }
        public void SetPartA()
        {
            _sendwitch.AddPart(A);
        }
        public void SetPartB()
        {
            _sendwitch.AddPart(B);
        }
    }
    public class Developer
    {
        private SendwitchBuilder sendwitchBuilder;
        public Developer(SendwitchBuilder sendwitchBuilder)
        {
            this.sendwitchBuilder = sendwitchBuilder;
        }
        public void Construct()
        {
            sendwitchBuilder.SetPartA();
            sendwitchBuilder.SetPartB();
        }
    }
    public sealed class PartA
    {

    }
    public sealed class PartB
    {

    }
}
