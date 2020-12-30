using System;
using System.Collections.Generic;

namespace Solarus.Mvvm.Services
{
    public sealed class MessageBus : IMessageBus
    {
        private readonly Dictionary<Type, List<object>> _subscriptions = 
            new Dictionary<Type, List<object>>();

        private readonly object _subscriptionsLock = new object();

        static MessageBus() { }

        private MessageBus() { }

        public static MessageBus Instance { get; } = new MessageBus();

        public void Subscribe<TMessage>(Action<TMessage> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            Type messageType = typeof(TMessage);
            lock (_subscriptionsLock)
            {
                if (_subscriptions.ContainsKey(messageType))
                {
                    List<object> subscriptions = _subscriptions[messageType];
                    subscriptions.Add(action);
                }
                else
                {
                    var subscriptions = new List<object> { action };
                    _subscriptions[messageType] = subscriptions;
                }
            }
        }

        public void Unsubscribe<TMessage>(Action<TMessage> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            Type messageType = typeof(TMessage);
            lock (_subscriptionsLock)
            {
                if (!_subscriptions.ContainsKey(messageType))
                    return;

                List<object> subscriptions = _subscriptions[messageType];
                subscriptions.Remove(action);

                if (subscriptions.Count == 0)
                    _subscriptions.Remove(messageType);
            }
        }

        public void Publish<TMessage>(TMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            Type messageType = typeof(TMessage);
            lock (_subscriptionsLock)
            {
                if (!_subscriptions.ContainsKey(messageType))
                    return;

                List<object> subscriptions = _subscriptions[messageType];
                foreach (object subscription in subscriptions)
                {
                    ((Action<TMessage>)subscription).Invoke(message);
                }
            }
        }
    }
}
