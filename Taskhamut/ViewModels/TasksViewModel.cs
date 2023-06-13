using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Taskhamut.Core.Models;

namespace Taskhamut.ViewModels;

public partial class TasksViewModel : ObservableRecipient
{
    public TaskEntity? SelectedTask { get; private set; }
    public ObservableCollection<TaskEntity> Tasks { get; private set; } = new();

    public TasksViewModel()
    {
    }

}
