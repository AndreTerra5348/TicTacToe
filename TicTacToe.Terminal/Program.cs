using Autofac;
using System;
using System.Collections.Generic;
using TicTacToe.Core;
using TicTacToe.Core.Board;
using TicTacToe.Core.Board.Rules;
using TicTacToe.Core.GameOver.Draw;
using TicTacToe.Core.GameOver.Victory;
using TicTacToe.Terminal.Presenter;
using TicTacToe.Terminal.Views;

namespace TicTacToe.Terminal
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
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

            builder.RegisterType<Game>()
                .As<IGame>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GameView>()
                .As<IGameView>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Grid>()
                .As<IGrid>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GridView>()
                .As<IGridView>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GamePresenter>()
                .As<IGamePresenter>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Worker>()
                .InstancePerLifetimeScope();

            Container = builder.Build();

            using var scope = Container.BeginLifetimeScope();
            var worker = scope.Resolve<Worker>();
            worker.Run();
        }
    }
}
