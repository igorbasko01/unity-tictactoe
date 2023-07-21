using UnityEngine;
public class AIPlayerHandler {
    private readonly PlayerMark _playerMark = PlayerMark.O;
    private readonly BoardHandler _boardHandler;
    private readonly PlayerEvents _playerEvents;
    private readonly IMovementLogic _movementLogic;
    public AIPlayerHandler(
        GameManagerEvents gameManagerEvents, 
        BoardHandler boardHandler, 
        PlayerEvents playerEvents, 
        IMovementLogic movementLogic) {
        _boardHandler = boardHandler;
        _playerEvents = playerEvents;
        _movementLogic = movementLogic;
        gameManagerEvents.OnCurrentPlayer += OnCurrentPlayer;
    }

    private void OnCurrentPlayer(PlayerMark playerMark) {
        if (playerMark != _playerMark) {
            return;
        }
        
        var (x, y) = _movementLogic.SelectCellToMove(_boardHandler);
        _playerEvents?.InvokeOnPerformMove(x, y, _playerMark);
    }
}