using UnityEngine;
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
        
        var (x, y) = SelectCellToMove();
        _playerEvents?.InvokeOnPerformMove(x, y, _playerMark);
    }

    private (int, int) SelectCellToMove() {
        var allFreeCells = _boardHandler.GetAllFreeCells();
        if (allFreeCells.Count == 0) {
            throw new System.Exception("No free cells to move to.");
        }
        var randomIndex = Random.Range(0, allFreeCells.Count);
        return allFreeCells[randomIndex];
    }
}