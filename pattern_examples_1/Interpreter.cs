using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTime3
{
    // Name => set
    public class NumberDataExpression
    {
        private Dictionary<string, int> _takeValue = new Dictionary<string, int>();
        public int this[string name]
        {
            get
            {
                if (_takeValue.ContainsKey(name))
                    return GetNumberValue(name);
                else throw new Exception("Not found key");
            }
            set
            {
                if (_takeValue.ContainsKey(name))
                    _takeValue[name] = value;
                else SetNumberKeyPair(name, value);
            }
        }
        private void SetNumberKeyPair(string numName, int numValue) => _takeValue.Add(numName, numValue);
        private int GetNumberValue(string name) => _takeValue[name];
    }
    public interface INumberExpression
    {
        int Interprete(NumberDataExpression data);
    }
    public class AddExpression : INumberExpression
    {
        protected INumberExpression _right;
        protected INumberExpression _left;
        public AddExpression(INumberExpression left, INumberExpression right)
        {
            _right = right;
            _left = left;
        }
        public int Interprete(NumberDataExpression data)
        {
            return _left.Interprete(data) + _right.Interprete(data);
        }
    }
    public class SubtractExpression : INumberExpression
    {
        protected INumberExpression _right;
        protected INumberExpression _left;
        public SubtractExpression(INumberExpression left, INumberExpression right) 
        {
            _right = right;
            _left = left;
        }
        public int Interprete(NumberDataExpression data)
        {
            return _left.Interprete(data) - _right.Interprete(data);
        }
    }
    public class Number : INumberExpression
    {
        private string _name;
        public Number(string name) 
        {
            _name = name;
        }
        public int Interprete(NumberDataExpression data)
        {
            return data[_name];
        }
    }
}
