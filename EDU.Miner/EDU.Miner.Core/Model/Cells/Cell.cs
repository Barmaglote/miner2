namespace EDU.Miner.Core.Model.Cells
{
    internal class Cell: ICell
    {
        public Cell(bool withBomb)
        {
            _WithBomb = withBomb;
        }

        public void Open()
        {
            throw new System.NotImplementedException();
        }

        private bool _WithBomb = false;
    }
}
