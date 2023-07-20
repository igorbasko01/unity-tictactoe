public class AIPlayerHandler {
    private readonly PlayerMark _playerMark = PlayerMark.O;
    private readonly BoardHandler _boardHandler;
    private readonly PlayerEvents _playerEvents;
    public AIPlayerHandler(GameManagerEvents gameManagerEvents, BoardHandler boardHandler, PlayerEvents playerEvents) {
        _boardHandler = boardHandler;
        _playerEvents = playerEvents;
        gameManagerEvents.OnCurrentPlayer += OnCurrentPlayer;
    }

    private void OnCurrentPlayer(PlayerMark playerMark) {
        if (playerMark != _playerMark) {
            return;
        }
        
        var (x, y) = _boardHandler.GetFirstEmptyCell();
        _playerEvents?.InvokeOnPerformMove(x, y, _playerMark);
    }
}