using System;

public class GameManager {
    private readonly HumanPlayerHandler _humanPlayerHandler;
    private readonly BoardHandler _boardHandler;
    public event Action<int, int, PlayerMark> OnValidMove;
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
        OnValidMove?.Invoke(x, y, playerMark);
    }
}