namespace HSData
{
    /// <summary>
    /// Interface for a generic board state
    /// </summary>
    public interface IBoardState
    {
        BoardState.PlayerTurn ActivePlayer { get; }

        IPlayerState PlayerOne { get; }

        IPlayerState PlayerTwo { get; }

        IBoardState AlterPlayerOne(IPlayerState alteredPlayerOne);

        IBoardState AlterPlayerTwo(IPlayerState alteredPlayerTwo);
    }
}