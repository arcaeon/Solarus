namespace Solarus.Mvvm
{
    public abstract class ViewModelBase : ObservableObject
    {
        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }
    }
}
