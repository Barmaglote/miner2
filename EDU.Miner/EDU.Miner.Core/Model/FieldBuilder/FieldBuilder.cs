using EDU.Miner.Core.Model.Factory;
using System;

namespace EDU.Miner.Core.Model.FieldBuilder
{
    internal class FieldBuilder : IFieldBuilder
    {
        public void BuildField(int width, int height, int bombs)
        {
            _Width = width;
            _Height = height;
            _Bombs = bombs;
            _Field = new Field();
        }

        public IField GetField()
        {
            return _Field;
        }

        private IField _Field = null;
        private int _Width;
        private int _Height;
        private int _Bombs;
    }
}
