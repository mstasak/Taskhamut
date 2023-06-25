using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Taskhamut.Core.Models;

namespace Taskhamut.ViewModels;

/// <summary>
/// Wrap Model's TaskEntity class provides a shell of accessors supporting observation, for binding to UI.
/// </summary>
/// <remarks>Derived from MS docs for ObservableObject.SetProperty (which are buggy right now - for example, they
/// use 'Set()' instead of 'SetProperty()' and Model's declaration contains no 'Person' type).</remarks>
/// <see href="https://learn.microsoft.com/en-us/dotnet/api/communitytoolkit.mvvm.componentmodel.observableobject.setproperty?view=win-comm-toolkit-dotnet-7.0">Microsoft Documentation</see>
public class ObservableTaskEntity : ObservableObject {

    public TaskEntity Model {
        get;
        set;
    }

    public ObservableTaskEntity(TaskEntity model) {
        Model = model;
    }

    public int TaskId {
        get => Model.TaskId;
        set => SetProperty(Model.TaskId, value, Model, (model, taskId) => model.TaskId = taskId);
    }

    public string TaskName {
        get => Model.TaskName;
        set => SetProperty(Model.TaskName, value, Model, (model, taskName) => model.TaskName = taskName);
    }

    public string? Summary {
        get => Model.Summary;
        set => SetProperty(Model.Summary, value, Model, (model, Summary) => model.Summary = Summary);
    }

    public string? Detail {
        get => Model.Detail;
        set => SetProperty(Model.Detail, value, Model, (model, Detail) => model.Detail = Detail);
    }

    public bool Completed {
        get => Model.Completed;
        set => SetProperty(Model.Completed, value, Model, (model, Completed) => model.Completed = Completed);
    }

    public ObservableCollection<CategoryEntity> Categories {
        //Haven't tested this yet...
        get => (ObservableCollection<CategoryEntity>)Model.Categories;
        set => SetProperty(Model.Categories, value, Model, (model, Categories) => model.Categories = Categories);
    }

    public void RaiseAllModified() {
        //used by viewmodel to force new binding values into UI following selection of a task
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(TaskId)));
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(TaskName)));
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(Summary)));
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(Detail)));
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(Completed)));
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(Categories)));
    }
}