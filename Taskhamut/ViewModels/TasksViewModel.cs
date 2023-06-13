using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Taskhamut.Core.Models;

namespace Taskhamut.ViewModels;

public partial class TasksViewModel : ObservableRecipient
{
    public TaskEntity? SelectedTask
    {
        get; private set;
    }
    public ObservableCollection<TaskEntity> Tasks { get; private set; } = new();

    public TasksViewModel()
    {
        //TODO: move this to a generate-on-demand method instead of always creating and holding in memory when not needed?
        Tasks.Clear();
        var sampleData = TaskEntity.GenerateSampleData();
        foreach (var row in sampleData)
        {
            Tasks.Add(row);
        }
    }

}
