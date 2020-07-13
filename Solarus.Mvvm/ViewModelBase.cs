namespace Solarus.Mvvm
{
    public abstract class ViewModelBase : ObservableObject, IViewModel
    {
        private bool _isLoading;
        private string _title;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
