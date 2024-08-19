using System;
using Reactive.Field;

namespace Editor.TestTool.Utilities.ReactiveField
{
    public class NonCheckReactiveField<T> : IReactiveField<T>
    {
        public event Action<T, T> OnChanged;

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                var oldValue = _value;

                _value = value;
                OnChanged?.Invoke(_value, oldValue);
            }
        }

        public NonCheckReactiveField() : this(default)
        {
            _value = default;
        }

        public NonCheckReactiveField(T initialValue)
        {
            _value = initialValue;
        }
    }
}