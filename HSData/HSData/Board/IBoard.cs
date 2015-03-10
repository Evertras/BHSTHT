namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic board that manages state changes
    /// </summary>
    public interface IBoard
    {
        BoardState CurrentState { get; }

        void ApplyEvent(IGameEvent gameEvent);
    }
}