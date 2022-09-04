using Autofac;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToe.Core;
using TicTacToe.Core.Board;
using TicTacToe.Core.Board.Rules;
using TicTacToe.Core.GameOver.Draw;
using TicTacToe.Core.GameOver.Victory;
using TicTacToe.Core.Validator;
using TicTacToe.WinForms.Presenter;
using TicTacToe.WinForms.Views;

namespace TicTacToe.WinForms
{
    internal static class Program
    {
        private static IContainer Container { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Container = SetupContainer();
            using var scope = Container.BeginLifetimeScope();
            var gamePresenter = scope.Resolve<IGamePresenter>();

            Application.Run(gamePresenter.View as GameWindow);
        }

        static IContainer SetupContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(_ => VictoryConditionsFactory.Create())
                .As<IEnumerable<IVictoryCondition>>()
                .InstancePerLifetimeScope();

            builder.Register(_ => DrawConditionsFactory.Create())
                .As<IEnumerable<IDrawCondition>>()
                .InstancePerLifetimeScope();

            builder.Register(c => GridRulesFactory.Create(c.Resolve<IGrid>()))
                .As<IEnumerable<IGridRule>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<IndexValidator>()
                .As<IIndexValidator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Game>()
                .As<IGame>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GameWindow>()
                .As<IGameWindow>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Grid>()
                .As<IGrid>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GamePresenter>()
                .As<IGamePresenter>()
                .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
