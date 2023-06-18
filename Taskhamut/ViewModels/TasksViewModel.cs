using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Taskhamut.Core.Models;
using Windows.Data.Xml.Dom;
using SelectionChangedEventArgs = Microsoft.UI.Xaml.Controls.SelectionChangedEventArgs;

namespace Taskhamut.ViewModels;

public partial class TasksViewModel : ObservableRecipient
{

    public ObservableTaskEntity DetailTaskHolder { get; set; }
    public TaskEntity? SelectedTask
    {
        get; set;
    }

    private TaskEntity NoSelectedTask
    {
        get; 
    } = new()
    {
        TaskName="(no task selected)"
    };

    public ObservableCollection<TaskEntity> Tasks { get; private set; } = new();

    public TasksViewModel()
    {
        //TODO: move this to a generate-on-demand method instead of always creating and holding in memory when not needed?  Sort of irrelevant,
        //as it will be deleted or disabled eventually.
        Tasks.Clear();
        var sampleData = TaskEntity.GenerateSampleData();
        foreach (var row in sampleData)
        {
            Tasks.Add(row); //WOW: accidentally tried to use "Tasks.Append(row);" and it does not change Tasks, merely returns a modified copy of the list
        }

        DetailTaskHolder = new ObservableTaskEntity(NoSelectedTask);
        SelectedTask = null;

        //register observer to react when listview selection changes
        //var observable = (IObservable<TaskEntity>?)SelectedTask;
        //observable.Subscribe();
        //PropertyChanged += TasksViewModel_PropertyChanged;

    }

    public void TaskSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        SetDetailSection();
    }

    private void SetDetailSection()
    {
        if (SelectedTask != null)
        {
            DetailTaskHolder.Model = SelectedTask;
            DetailTaskHolder.RaiseAllModified();
            //SaveTaskIfNeeded(DetailTaskHolder);
            //DetailTaskHolder.TaskId = SelectedTask!.TaskId;
            //DetailTaskHolder.TaskName = SelectedTask!.TaskName;
            //DetailTaskHolder.Summary = SelectedTask!.Summary;
            //DetailTaskHolder.Detail = SelectedTask!.Detail;
            //DetailTaskHolder.Completed = SelectedTask!.Completed;
            //DetailTaskHolder.Categories = SelectedTask!.Categories;
        } else { 
            DetailTaskHolder.Model = NoSelectedTask;
            DetailTaskHolder.RaiseAllModified();
            //DetailTaskHolder.TaskId = 0;
            //DetailTaskHolder.TaskName = "<new>";
            //DetailTaskHolder.Summary = "";
            //DetailTaskHolder.Detail = "";
            //DetailTaskHolder.Completed = false;
            //DetailTaskHolder.Categories = new List<CategoryEntity>();
        }
    }

    public string TaskCount()
    {
        return Tasks.Count.ToString() + " Tasks";
    }

    public void AddRandomTask()
    {
        Tasks.Add(new TaskEntity() { TaskId = Tasks.Count + 1, TaskName = "Play GT7", Summary = "", Detail = "", Completed = false });
    }


}
