using System;
using System.Collections.Generic;

namespace Solarus.Mvvm.Services
{
    public sealed class MessageBus : IMessageBus
    {
        private readonly Dictionary<Type, List<object>> _subscribers = 
            new Dictionary<Type, List<object>>();

        private readonly object _lock = new object();

        static MessageBus() { }

        private MessageBus() { }

        public static MessageBus Instance { get; } = new MessageBus();

        public void Publish<TMessage>(TMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Type messageType = typeof(TMessage);
            lock (_lock)
            {
                if (_subscribers.ContainsKey(messageType))
                {
                    List<object> subscriptions = _subscribers[messageType];
                    foreach (object subscription in subscriptions)
                    {
                        ((Action<TMessage>)subscription).Invoke(message);
                    }
                }
            }
        }

        public void Subscribe<TMessage>(Action<TMessage> action)
        {
            Type messageType = typeof(TMessage);
            lock (_lock)
            {
                if (_subscribers.ContainsKey(messageType))
                {
                    List<object> subscriptions = _subscribers[messageType];
                    subscriptions.Add(action);
                }
                else
                {
                    var subscriptions = new List<object> { action };
                    _subscribers[messageType] = subscriptions;
                }
            }
        }

        public void Unsubscribe<TMessage>(Action<TMessage> action)
        {
            Type messageType = typeof(TMessage);
            lock (_lock)
            {
                if (_subscribers.ContainsKey(messageType))
                {
                    List<object> subscriptions = _subscribers[messageType];
                    subscriptions.Remove(action);

                    if (subscriptions.Count == 0)
                    {
                        _subscribers.Remove(messageType);
                    }
                }
            }
        }
    }
}
