using Microsoft.UI.Xaml.Controls;

using Taskhamut.ViewModels;

namespace Taskhamut.Views;

public sealed partial class OptionsPage : Page
{
    public OptionsViewModel ViewModel
    {
        get;
    }

    public OptionsPage()
    {
        ViewModel = App.GetService<OptionsViewModel>();
        InitializeComponent();
    }
}
