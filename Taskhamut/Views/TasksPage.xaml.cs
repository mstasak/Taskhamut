using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Taskhamut.ViewModels;
using Windows.Devices.PointOfService;

namespace Taskhamut.Views;

public sealed partial class TasksPage : Page {
    public TasksViewModel ViewModel {
        get;
    }

    public TasksPage() {
        ViewModel = App.GetService<TasksViewModel>();
        InitializeComponent();
        //Loaded += TasksPage_Loaded; //present in Learn WINUI 3.0; causes error here; maybe handled by framework now?
    }


    ////TODO:: relocate logic to viewmodel
    //protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
    //    // are there unsaved changes? is prompting enabled? prompt and save or discard as requested; if save failed, show error and cancel navigation
    //    Debug.WriteLine($"Enter OnNavigatingFrom()");
    //    bool saveNeeded = false;
    //    if (ViewModel.TasksUpdated) {
    //        if (ViewModel.PromptingRequired) {
    //            //TODO: implement a save/discard/cancel dialog
    //            //use: WinUI2 ContentDialog?

    //            //ContentDialog dialog = new SavePromptDialog();
    //            ContentDialog dialog = new ContentDialog();
    //            dialog.Title = "Task has been edited.  Save your changes?";
    //            dialog.PrimaryButtonText = "Save Changes";
    //            dialog.SecondaryButtonText = "Discard Changes";
    //            dialog.CloseButtonText = "Cancel";
    //            dialog.DefaultButton = ContentDialogButton.Primary;
    //            //dialog.Content = new SavePromptDialogContent();
    //            dialog.XamlRoot = this.XamlRoot;
    //            var result = await dialog.ShowAsync();
    //            Debug.WriteLine($"Save changes result = {result}");
    //            switch (result) {
    //                case ContentDialogResult.Primary:
    //                    saveNeeded = true;
    //                    break;
    //                case ContentDialogResult.Secondary:
    //                    break;
    //                default:
    //                    e.Cancel = true;
    //                    break;
    //            }
    //        }
    //        else {
    //            saveNeeded = true;
    //        }
    //    }
    //    if (saveNeeded && !e.Cancel) {
    //        string saveErrorMessage;
    //        if (SaveChanges(out saveErrorMessage)) {
    //            Debug.WriteLine($"Save successful");
    //        } else {
    //            //display error
    //            Debug.WriteLine($"Save error: {saveErrorMessage}");
    //            //cancel navigation
    //            e.Cancel = true;
    //        }
    //    }
    //    base.OnNavigatingFrom(e);
    //}

    //private bool SaveChanges(out string saveErrorMessage) {
    //    saveErrorMessage = "Artificial error!";
    //    return false;
    //}

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
        ViewModel.DbContext.SaveChanges();
        base.OnNavigatingFrom(e);
    }

}

