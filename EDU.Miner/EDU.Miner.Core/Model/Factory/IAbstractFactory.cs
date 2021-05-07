using EDU.Miner.Core.Controller;
using EDU.Miner.Core.Model.Cells;
using EDU.Miner.Core.Model.FieldBuilder;
using EDU.Miner.Core.Model.MinerGame;
using EDU.Miner.Core.View;
using System.Windows.Controls.Primitives;

namespace EDU.Miner.Core.Model.Factory
{
    public interface IAbstractFactory
    {
        ICell CreateCell(bool withBomb);
        ICellView CreateCellView(int x, int y);
        IGameController CreateGameController();
        IFieldBuilder CreateFieldBuilder();
        IField CreateField(IFieldBuilder builder, int width, int height, int bombs);
        IFieldView CreateFieldView(UniformGrid grid, int x, int y);
        IMinerGame CreateMinerGame(IFieldView fieldView, IGameController controller);
    }
}
