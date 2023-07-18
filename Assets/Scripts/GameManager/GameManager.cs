using System;

public class GameManager {
    private readonly GameManagerEvents _gameEvents;
    private readonly HumanPlayerHandler _humanPlayerHandler;
    private readonly BoardHandler _boardHandler;
    private PlayerMark _currentPlayer;
    public GameManager(HumanPlayerHandler humanPlayerHandler, BoardHandler boardHandler, GameManagerEvents gameEvents) {
        _humanPlayerHandler = humanPlayerHandler;
        _boardHandler = boardHandler;
        _humanPlayerHandler.OnPerformMove += OnPlayerPerformMove;
        _gameEvents = gameEvents;
    }

    private void OnPlayerPerformMove(int x, int y, PlayerMark playerMark) {
        if (playerMark != _currentPlayer || !_boardHandler.IsCellEmpty(x, y)) {
            return;
        }
        _boardHandler.PerformMove(x, y, playerMark);
        _gameEvents?.InvokeOnValidMove(x, y, playerMark);
        switchCurrentPlayer();
    }

    private void switchCurrentPlayer() {
        _currentPlayer = _currentPlayer == PlayerMark.X ? PlayerMark.O : PlayerMark.X;
        _gameEvents?.InvokeOnCurrentPlayer(_currentPlayer);
    }

    public void StartGame() {
        _currentPlayer = PlayerMark.X;
        _gameEvents?.InvokeOnCurrentPlayer(_currentPlayer);
    }
}