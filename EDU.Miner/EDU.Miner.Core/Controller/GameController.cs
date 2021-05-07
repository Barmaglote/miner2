namespace EDU.Miner.Core.Controller
{
    internal class GameController: IGameController
    {
        public void CellClickedEvent() 
        { 

        }

        public static IGameController CreateInstance()
        {
            if (__UniqueInstance == null)
            {
                __UniqueInstance = new GameController();
            }

            return __UniqueInstance;
        }

        private static IGameController __UniqueInstance = null;
    }
}
