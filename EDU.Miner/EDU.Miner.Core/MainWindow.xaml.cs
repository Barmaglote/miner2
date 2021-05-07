using EDU.Miner.Core.Model.Factory;
using System.Windows;

namespace EDU.Miner.Core
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var width = 10;
            var height = 10;
            var bombs = 10;

            var factory = ConcreteFactory.CreateInstance();
            var fieldBuilder = factory.CreateFieldBuilder();

            var field = factory.CreateField(fieldBuilder, width, height, bombs);
            var fieldView = factory.CreateFieldView(PlayGrid, width, height);
            var controller = factory.CreateGameController();
            var game = factory.CreateMinerGame(fieldView, controller);
            game.Start();
        }
    }
}
