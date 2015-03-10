namespace HSData
{
    /// <summary>
    /// Interface for a generic board state
    /// </summary>
    public interface IBoardState
    {
        /// <summary>
        /// Denotes whose turn it is
        /// </summary>
        BoardState.PlayerTurn ActivePlayer { get; }

        IPlayerState ActivePlayerState { get; }

        IPlayerState InactivePlayerState { get; }

        IPlayerState PlayerOne { get; }

        IPlayerState PlayerTwo { get; }

        IBoardState AlterPlayerOne(IPlayerState alteredPlayerOne);

        IBoardState AlterPlayerTwo(IPlayerState alteredPlayerTwo);

        IBoardState AlterActivePlayer(IPlayerState alteredActivePlayer);

        IBoardState AlterInactivePlayer(IPlayerState alteredInactivePlayer);

        /// <summary>
        /// Ends the current turn and begins the turn for the other player
        /// </summary>
        IBoardState EndTurn();
    }
}