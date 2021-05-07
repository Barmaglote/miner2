namespace EDU.Miner.Core.Model.FieldBuilder
{
    /// <summary>
    /// Создание игрового поля
    /// </summary>
    public interface IFieldBuilder
    {
        void BuildField(int width, int height, int bombs);
        IField GetField();
    }
}
