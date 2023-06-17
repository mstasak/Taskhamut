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
        //Loaded += TasksPage_Loaded; //present in Learn WINUI 3.0; causes error here; maybe handled by framework now?
    }

    private void btnDevAddTask_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.AddRandomTask();
    }
}
