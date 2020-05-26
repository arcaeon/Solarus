namespace Solarus.Mvvm.Services
{
    public interface IViewModelFactory
    {
        T Create<T>(params object[] args);
    }
}
