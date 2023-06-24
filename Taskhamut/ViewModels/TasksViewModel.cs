using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Taskhamut.Core.Models;
using SelectionChangedEventArgs = Microsoft.UI.Xaml.Controls.SelectionChangedEventArgs;

namespace Taskhamut.ViewModels;

public partial class TasksViewModel : ObservableRecipient {

    public MyDbContext DbContext {
        get; set;
    } = new();

    public ObservableTaskEntity DetailTaskHolder {
        get; set;
    }
    public TaskEntity? SelectedTask {
        get; set;
    }

    private TaskEntity NoSelectedTask {
        get;
    } = new() {
        TaskName = "(no task selected)"
    };

    public ObservableCollection<TaskEntity> Tasks { get; private set; } = new();

    public TasksViewModel() {

#if DEBUG
        //TODO: remove when no longer useful
        //seed the tasks table if empty
        if (DbContext.Tasks.Count() == 0) {
            var sampleData = TaskEntity.GenerateSampleData();
            foreach (var row in sampleData) {
                DbContext.Tasks.Add(row);
            }
            DbContext.SaveChanges();
        }
#endif

        foreach (var row in DbContext.Tasks) {
            Tasks.Add(row); //WOW: accidentally tried to use "Tasks.Append(row);" and it does not change Tasks, merely returns a modified copy of the list
        }

        DetailTaskHolder = new ObservableTaskEntity(NoSelectedTask);
    }

    public void TaskSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        DbContext.SaveChanges(); //save changes, if any, from old selected task
        SetDetailSection();
    }

    private void SetDetailSection() {
        if (SelectedTask != null) {
            //SaveTaskIfNeeded(DetailTaskHolder);
            DetailTaskHolder.Model = SelectedTask; //this is a bindable wrapper around the selected task
        } else {
            DetailTaskHolder.Model = NoSelectedTask;
        }
        DetailTaskHolder.RaiseAllModified(); //push the new selection's values to the view
    }

    public string TaskCount() {
        return Tasks.Count.ToString() + " Tasks";
    }

    public void AddRandomTask() {
        var newTaskId = 1;
        if (Tasks.Count > 0) {
            newTaskId += Tasks.Max(t => t.TaskId);
        }
        // Potential issue: different EF db providers may expect 0 or null values for IDs of new rows?
        // For example, normally MSSQL disallows identity insert values iirc.
        // SQLite tolerates a new unique id value
        DbContext.Tasks.Add(
            new TaskEntity() {
                TaskId = newTaskId,
                TaskName = $"Some new task # {newTaskId}",
                Summary = "",
                Detail = "",
                Completed = false
            });
        DbContext.SaveChanges();
    }


    public void BtnDevAddTask_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) {
        AddRandomTask();
    }

    ~TasksViewModel() {
        //    DbContext.SaveChanges();  // <-- did not work???
        //    Put a SaveChanges in view codebehind's OnNavigationFrom() event handler
        //    I don't really like leaving this non-functional, there may be other ways to miss
        //    saving (for example by closing the app or powering down the system)
        DbContext.Dispose();
    }

}
