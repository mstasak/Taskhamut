using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Taskhamut.Core.Models;
using Windows.Data.Xml.Dom;
using SelectionChangedEventArgs = Microsoft.UI.Xaml.Controls.SelectionChangedEventArgs;

namespace Taskhamut.ViewModels;

public partial class TasksViewModel : ObservableRecipient
{

    public MyDbContext DbContext {
        get; set; } = new();

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

    //TODO: implement change detection
    public bool TasksUpdated => true;

    //TODO: implement autosave setting
    public bool PromptingRequired => true;

    public TasksViewModel()
    {
        //TODO: move this to a generate-on-demand method instead of always creating and holding in memory when not needed?  Sort of irrelevant,
        //as it will be deleted or disabled eventually.
        Tasks.Clear();
        ////var sampleData = TaskEntity.GenerateSampleData(); for early dev
        //var sampleData = DbContext.Tasks;
        //foreach (var row in sampleData)
        //{
        //    Tasks.Add(row); //WOW: accidentally tried to use "Tasks.Append(row);" and it does not change Tasks, merely returns a modified copy of the list
        //}

        //seed the tasks table if empty
        //TODO: remove
        if (DbContext.Tasks.Count() == 0) {
            var sampleData = TaskEntity.GenerateSampleData();
            foreach (var row in sampleData) {
                DbContext.Tasks.Add(row); //WOW: accidentally tried to use "Tasks.Append(row);" and it does not change Tasks, merely returns a modified copy of the list
            }
            DbContext.SaveChanges();
        }

        foreach (var row in DbContext.Tasks)
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
        DbContext.SaveChanges();
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
        var newTaskId = 1;
        if (Tasks.Count > 0) {
            newTaskId += Tasks.Max(t => t.TaskId);
        }
        DbContext.Tasks.Add(new TaskEntity() { TaskId = newTaskId, TaskName = $"Some new task # {newTaskId}", Summary = "", Detail = "", Completed = false });
        DbContext.SaveChanges();
    }

    
    public void BtnDevAddTask_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) {
        AddRandomTask();
    }

    //~TasksViewModel() {
    //    DbContext.SaveChanges();  // <-- did not work???
    //}

}
