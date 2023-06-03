using Microsoft.UI.Xaml.Controls;

using Taskhamut.ViewModels;

namespace Taskhamut.Views;

public sealed partial class AboutPage : Page
{
    public AboutViewModel ViewModel
    {
        get;
    }

    public AboutPage()
    {
        ViewModel = App.GetService<AboutViewModel>();
        InitializeComponent();
    }
}
