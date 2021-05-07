using System.Windows;

namespace EDU.Miner.Core.View
{
    public interface ICellView
    {
        (int x, int y) GetPosition();
    }
}
