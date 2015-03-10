using System;

namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic board that manages state changes
    /// </summary>
    public interface IBoard
    {
        IBoardState CurrentState { get; }

        void ApplyEvent(IGameEvent gameEvent);

        event Action<IBoard, EventArgs> StateChanged;
    }
}