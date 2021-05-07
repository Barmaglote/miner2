using EDU.Miner.Core.Model.Factory;
using System.Linq;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace EDU.Miner.Core.View
{
    internal class FieldView : IFieldView
    {
        public FieldView(UniformGrid grid, int x, int y)
        {
            _Grid = grid;
            _X = x;
            _Y = y;

            _Items = new List<ICellView>();
        }

        public void DrawClosedField()
        {
            //throw new NotImplementedException();
        }

        public void DrawOpenedField()
        {
            _Grid.Columns = _X;
            _Grid.Rows = _Y;

            var itemCollection = new UIElementCollection(_Grid, _Grid);

            for (int k = 0; k < _Y; k++)
            {
                for (int i = 0; i < _X; i++)
                {
                    var button = _AbstractFactory.CreateCellView(i, k);
                    _Items.Append(button);
                    itemCollection.Add(button);
                    //_Grid.Children.Add((UIElement)button);
                }
            }

            

            

            _Grid.
                //= _Items.Select(x => (UIElement)x);
        }

        private IEnumerable<ICellView> _Items;
        private UniformGrid _Grid;
        private int _X;
        private int _Y;
        private IAbstractFactory _AbstractFactory => ConcreteFactory.CreateInstance();
    }
}
