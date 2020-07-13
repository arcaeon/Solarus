using System;

namespace Solarus.Mvvm
{
    public interface ICloseable
    {
        event EventHandler CloseRequested;
    }
}
