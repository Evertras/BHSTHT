namespace HSData
{
    /// <summary>
    /// Defines the base interface for a generic card effect
    /// </summary>
    public interface ICardEffect
    {
        bool RequiresTarget { get; }

        IGameEvent GenerateEvent();

        IGameEvent GenerateEvent(IBoardEntity target);
    }
}