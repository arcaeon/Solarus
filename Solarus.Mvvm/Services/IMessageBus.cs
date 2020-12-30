using System;

namespace Solarus.Mvvm.Services
{
    public interface IMessageBus
    {
        void Subscribe<TMessage>(Action<TMessage> action);
        void Unsubscribe<TMessage>(Action<TMessage> action);
        void Publish<TMessage>(TMessage message);
    }
}
