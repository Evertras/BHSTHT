namespace HSData
{
    /// <summary>
    /// Interface for a generic board state
    /// </summary>
    public interface IBoardState
    {
        BoardState.PlayerTurn ActivePlayer { get; }
        PlayerState PlayerOne { get; }
        PlayerState PlayerTwo { get; }

        BoardState AlterPlayerOne(PlayerState alteredPlayerOne);
        BoardState AlterPlayerTwo(PlayerState alteredPlayerTwo);
    }
}