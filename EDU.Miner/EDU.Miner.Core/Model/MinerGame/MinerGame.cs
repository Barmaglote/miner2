using EDU.Miner.Core.Controller;
using EDU.Miner.Core.View;

namespace EDU.Miner.Core.Model.MinerGame
{
    internal class MinerGame : IMinerGame
    {
        public MinerGame(IFieldView fieldView, IGameController controller)
        {
            _fieldView = fieldView;
        }    
    
        public void Start()
        {
            _fieldView.DrawOpenedField();
        }

        private IFieldView _fieldView;
    }
}
