using Microsoft.UI.Xaml.Controls;

using Taskhamut.ViewModels;

namespace Taskhamut.Views;

public sealed partial class UsersPage : Page
{
    public UsersViewModel ViewModel
    {
        get;
    }

    public UsersPage()
    {
        ViewModel = App.GetService<UsersViewModel>();
        InitializeComponent();
    }
}
