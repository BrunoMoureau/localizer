using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalizedApp.Templates.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckboxCell
    {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected),
            typeof(bool),
            typeof(CheckboxCell));

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(CheckboxCell));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(
            nameof(Description),
            typeof(string),
            typeof(CheckboxCell));

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(
            nameof(Padding),
            typeof(Thickness),
            typeof(CheckboxCell), 
            new Thickness(20, 10));

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create(
            nameof(TappedCommand),
            typeof(ICommand),
            typeof(CheckboxCell));
        
        public ICommand TappedCommand
        {
            get => (ICommand)GetValue(TappedCommandProperty);
            set => SetValue(TappedCommandProperty, value);
        }

        public static readonly BindableProperty TappedCommandParameterProperty = BindableProperty.Create(
            nameof(TappedCommandParameter),
            typeof(object),
            typeof(CheckboxCell));
        
        public object TappedCommandParameter
        {
            get => GetValue(TappedCommandParameterProperty);
            set => SetValue(TappedCommandParameterProperty, value);
        }

        public CheckboxCell()
        {
            InitializeComponent();
        }

        private void OnCellTapped(object sender, EventArgs e)
        {
            if (TappedCommand == null) return;

            if (TappedCommand.CanExecute(TappedCommandParameter))
            {
                TappedCommand.Execute(TappedCommandParameter);
            }
        }
    }
}