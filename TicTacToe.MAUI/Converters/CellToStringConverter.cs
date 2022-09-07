using System.Globalization;
using Cell = TicTacToe.Core.Board.Cell;

namespace TicTacToe.MAUI.Converters
{
    public class CellToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                Cell.Empty => String.Empty,
                Cell.P1 => "X",
                Cell.P2 => "O",
                _ => throw new InvalidDataException(),
            };

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
