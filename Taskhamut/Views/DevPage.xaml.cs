using Microsoft.UI.Xaml.Controls;

using Taskhamut.ViewModels;

namespace Taskhamut.Views;

public sealed partial class DevPage : Page
{
    public DevViewModel ViewModel
    {
        get;
    }

    public DevPage()
    {
        ViewModel = App.GetService<DevViewModel>();
        InitializeComponent();
    }
}
