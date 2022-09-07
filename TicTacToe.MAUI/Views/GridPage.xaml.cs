using TicTacToe.MAUI.Converters;
using TicTacToe.MAUI.ViewModels;

namespace TicTacToe.MAUI.Views;

public partial class GridPage : ContentPage
{
	public GridPage(GridViewModel vm, CellToStringConverter cellToStringConverter)
	{
        InitializeComponent();
		BindingContext = vm;

        _resetButton.Command = vm.ResetCommand;
        _exittButton.Command = vm.ExitCommand;

        for (int i = 0; i < Core.Board.Grid.Size; i++)
		{
            var button = new Button();
            button.SetBinding(Button.TextProperty, "Cells[" + i + "]", converter: cellToStringConverter);
            button.Command = vm.PlayCommand;
            button.CommandParameter = i.ToString();
            button.FontSize = 50;
            _grid.Add(button, i % 3, i / 3);
        }

	}
}