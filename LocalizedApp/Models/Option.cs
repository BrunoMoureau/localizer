using System.Windows.Input;
using LocalizedApp.Helpers;

namespace LocalizedApp.Models
{
    public class Option<T> : ObservableObject
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        
        private T _value;
        public T Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public Option(bool isSelected,T value, string title, string description = null)
        {
            _isSelected = isSelected;
            _value = value;
            _title = title;
            _description = description;
        }
    }
}
