using System;

namespace Game.Common
{
    public class Parameter<T>
    {
        public event Action<T, T> OnChanged;

        public string Name { get; }
        public T Value => _currentValue;
        public T PreviousValue => _previousValue;

        private T _initValue;
        private T _currentValue;
        private T _previousValue;

        public Parameter(string name) : this(name, default, default)
        { }

        public Parameter(string name, T initValue) : this(name, initValue, default)
        { }

        public Parameter(string name, T initValue, T currentValue)
        { 
            Name = name;
            _initValue = initValue;
            _currentValue = currentValue;
            _previousValue = default;
        }

        public void SetValue(T value)
        {
            if (_currentValue.Equals(value)) 
                return;

            _previousValue = _currentValue;
            _currentValue = value;
            OnChanged?.Invoke(_previousValue, _currentValue);
        }

        public void ReInit(T initValue)
        {
            ReInit(initValue, initValue);
        }

        public void ReInit(T initValue, T value)
        {
            _initValue = initValue;
            _currentValue = value;

            var temp = _previousValue;
            _previousValue = default;

            OnChanged?.Invoke(temp, _currentValue);
        }

        public void Reset()
        {
            SetValue(_initValue);
        }
    }
}