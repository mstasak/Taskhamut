using Microsoft.UI.Xaml.Controls;

using Taskhamut.ViewModels;

namespace Taskhamut.Views;

public sealed partial class TasksPage : Page
{
    public TasksViewModel ViewModel
    {
        get;
    }

    public TasksPage()
    {
        ViewModel = App.GetService<TasksViewModel>();
        InitializeComponent();
    }
}
