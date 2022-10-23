using System;

namespace PracticeTime3
{
    /// <summary>
    /// UI Mediator
    /// Button1 => TextBox
    /// Button2 => TextBox
    /// TextBox => TextField
    /// </summary>

    public sealed class UIData
    {
        private string _text;
        public string Text => _text;
        public UIData(string text)
        {
            _text = text;
        }
    }
    public abstract class UIElement
    {
        private IMediator mediator;
        public UIElement(IMediator mediator)
        {
            this.mediator = mediator;
        }
        protected void ThrowData(UIData data) => mediator.SendData(data, this);
        public abstract void RecieveData(UIData data); // do smth
    }
    public interface IMediator
    {
        public void SendData(UIData data, UIElement element);
    }
    public class UIMediator : IMediator
    {
        private Button1 _button1;
        private Button2 _button2;
        private TextBox _textBox;
        private TextField _textField;

        public static UIMediator Instance = new UIMediator();
        private UIMediator() { }
        public void InitElements(Button1 button1, Button2 button2, TextBox textBox, TextField textField)
        {
            _button1 = button1;
            _button2 = button2;
            _textBox = textBox;
            _textField = textField;
        }
        public void SendData(UIData data, UIElement element)
        {
            if (element == _button1) _textBox.RecieveData(data);
            if (element == _button2) _textBox.RecieveData(data);
            if (element == _textBox) _textField.RecieveData(data);
        }
    }
    public abstract class Button : UIElement
    {
        public Button(IMediator mediator) : base(mediator)
        { 

        }
        public void Click(UIData data) => ThrowData(data);
        public override void RecieveData(UIData data)
        {
            
        }
    }
    public sealed class Button1 : Button
    {
        public Button1(IMediator mediator) : base(mediator)
        {

        }
    }
    public sealed class Button2 : Button
    {
        public Button2(IMediator mediator) : base(mediator)
        {

        }
    }
    public class TextBox : UIElement
    {
        private UIData TextBoxData;
        public TextBox(IMediator mediator): base(mediator)
        {

        }
        public void PrintData() => ThrowData(TextBoxData);
        public override void RecieveData(UIData data)
        {
            TextBoxData = data;
        }
    }
    public class TextField : UIElement
    {
        public TextField(IMediator mediator) : base(mediator)
        {

        }
        public override void RecieveData(UIData data)
        {
            Console.WriteLine(data.Text);
        }
    }
}
