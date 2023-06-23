using System;

public class GameManager {
    private readonly HumanPlayerHandler _humanPlayerHandler;
    private readonly BoardHandler _boardHandler;
    private PlayerMark _currentPlayer;
    public event Action<int, int, PlayerMark> OnValidMove;
    public event Action<PlayerMark> OnCurrentPlayer;
    public GameManager(HumanPlayerHandler humanPlayerHandler, BoardHandler boardHandler) {
        _humanPlayerHandler = humanPlayerHandler;
        _boardHandler = boardHandler;
        _humanPlayerHandler.OnPerformMove += OnPlayerPerformMove;
    }

    private void OnPlayerPerformMove(int x, int y, PlayerMark playerMark) {
        if (!_boardHandler.IsCellEmpty(x, y)) {
            return;
        }
        _boardHandler.PerformMove(x, y, playerMark);
        switchCurrentPlayer();
        OnValidMove?.Invoke(x, y, playerMark);
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