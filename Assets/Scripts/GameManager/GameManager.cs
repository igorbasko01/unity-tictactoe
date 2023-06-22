using System;

public class GameManager {
    private readonly HumanPlayerHandler humanPlayerHandler;
    public event Action<int, int, PlayerMark> OnValidMove;
    public GameManager(HumanPlayerHandler humanPlayerHandler) {
        this.humanPlayerHandler = humanPlayerHandler;
        humanPlayerHandler.OnPerformMove += OnPlayerPerformMove;
    }

    private void OnPlayerPerformMove(int x, int y, PlayerMark playerMark) {
        OnValidMove?.Invoke(x, y, playerMark);
    }
}