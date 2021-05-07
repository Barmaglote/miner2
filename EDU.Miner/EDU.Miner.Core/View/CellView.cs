using System.Windows.Controls;

namespace EDU.Miner.Core.View
{
    internal class CellView: Button, ICellView
    {

        public (int x, int y) GetPosition() 
        {
            return (_x, _y);
        }

        public CellView(int x, int y): base()
        {
            this.AddText(x.ToString());
            _x = x;
            _y = y;
        }

        private int _x;
        private int _y;
    }
}
