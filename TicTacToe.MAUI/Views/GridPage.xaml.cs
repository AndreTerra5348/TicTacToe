using TicTacToe.MAUI.Converters;
using TicTacToe.MAUI.ViewModels;

namespace TicTacToe.MAUI.Views;

public partial class GridPage : ContentPage
{
    public GridViewModel ViewModel { get; set; }
    public GridPage(GridViewModel viewModel)
	{
        ViewModel = viewModel;
        InitializeComponent();
	}
}