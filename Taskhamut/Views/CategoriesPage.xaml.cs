using Microsoft.UI.Xaml.Controls;

using Taskhamut.ViewModels;

namespace Taskhamut.Views;

public sealed partial class CategoriesPage : Page
{
    public CategoriesViewModel ViewModel
    {
        get;
    }

    public CategoriesPage()
    {
        ViewModel = App.GetService<CategoriesViewModel>();
        InitializeComponent();
    }
}
