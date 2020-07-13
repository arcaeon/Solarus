using System.ComponentModel;

namespace Solarus.Mvvm
{
    public interface IViewModel : INotifyPropertyChanged
    {
        bool IsLoading { get; set; }
        string Title { get; set; }
    }
}
