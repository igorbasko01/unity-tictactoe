using System;

public class GameManager {
    private readonly HumanPlayerHandler _humanPlayerHandler;
    private readonly BoardHandler _boardHandler;
    private PlayerMark _currentPlayer;
    /**
     * This event is fired when a player performs a valid move.
     * The first parameter is the x coordinate of the move.
     * The second parameter is the y coordinate of the move.
     * The third parameter is the mark of the player who performed the move.
     */
    public event Action<int, int, PlayerMark> OnValidMove;
    /**
     * This event is fired when the current player changes.
     * The parameter is the mark of the new current player.
     */
    public event Action<PlayerMark> OnCurrentPlayer;
    public GameManager(HumanPlayerHandler humanPlayerHandler, BoardHandler boardHandler) {
        _humanPlayerHandler = humanPlayerHandler;
        _boardHandler = boardHandler;
        _humanPlayerHandler.OnPerformMove += OnPlayerPerformMove;
    }

    private void OnPlayerPerformMove(int x, int y, PlayerMark playerMark) {
        if (playerMark != _currentPlayer || !_boardHandler.IsCellEmpty(x, y)) {
            return;
        }
        _boardHandler.PerformMove(x, y, playerMark);
        OnValidMove?.Invoke(x, y, playerMark);
        switchCurrentPlayer();
    }

    private void switchCurrentPlayer() {
        _currentPlayer = _currentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
        OnCurrentPlayer?.Invoke(_currentPlayer);
    }

    public void StartGame() {
        _currentPlayer = PlayerMark.X;
        OnCurrentPlayer?.Invoke(_currentPlayer);
    }
}