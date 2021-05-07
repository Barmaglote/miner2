using EDU.Miner.Core.Controller;
using EDU.Miner.Core.Model.Cells;
using EDU.Miner.Core.Model.FieldBuilder;
using EDU.Miner.Core.Model.MinerGame;
using EDU.Miner.Core.View;
using System.Windows.Controls.Primitives;

namespace EDU.Miner.Core.Model.Factory
{
    public class ConcreteFactory : IAbstractFactory
    {
        public ICell CreateCell(bool withBomb)
        {
            return new Cell(withBomb);
        }

        public ICellView CreateCellView(int x, int y)
        {
            return new CellView(x, y);
        }
        public IGameController CreateGameController()
        {
            return GameController.CreateInstance();
        }

        public IFieldBuilder CreateFieldBuilder()
        {
            return new FieldBuilder.FieldBuilder();
        }

        public IField CreateField(IFieldBuilder builder, int width, int height, int bombs)
        {
            builder.BuildField(width, height, bombs);
            return builder.GetField();
        }

        public IFieldView CreateFieldView(UniformGrid grid, int x, int y)
        {
            return new FieldView(grid, x, y);
        }

        public static IAbstractFactory CreateInstance()
        {
            if (__UniqueInstance == null) {
                __UniqueInstance = new ConcreteFactory();
            }

            return __UniqueInstance;
        }

        public IMinerGame CreateMinerGame(IFieldView fieldView, IGameController controller)
        {
            return new MinerGame.MinerGame(fieldView, controller);
        }

        private static IAbstractFactory __UniqueInstance = null;
    }
}
