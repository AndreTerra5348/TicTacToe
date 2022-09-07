using TicTacToe.Core;
using TicTacToe.Core.Board;
using TicTacToe.Core.Board.Rules;
using TicTacToe.Core.GameOver.Draw;
using TicTacToe.Core.GameOver.Victory;
using TicTacToe.Core.Validator;
using TicTacToe.MAUI.Converters;
using TicTacToe.MAUI.Services;
using TicTacToe.MAUI.ViewModels;
using TicTacToe.MAUI.Views;
using Grid = TicTacToe.Core.Board.Grid;

namespace TicTacToe.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services
                .AddTransient<IEnumerable<IVictoryCondition>>(_ => VictoryConditionsFactory.Create())
                .AddTransient<IEnumerable<IDrawCondition>>(_ => DrawConditionsFactory.Create())
                .AddTransient<IEnumerable<IGridRule>>(s => GridRulesFactory.Create(s.GetService<IGrid>()));

            builder.Services
                .AddTransient<IAlertService, AlertService>()
                .AddTransient<IIndexValidator, IndexValidator>()
                .AddScoped<IGrid, Grid>()
                .AddScoped<IGame, Game>();

            builder.Services
                .AddTransient<AppShell>()
                .AddTransient<CellToStringConverter>()
                .AddTransient<GridPage>()
                .AddTransient<GridViewModel>();

            return builder.Build();
        }
    }
}