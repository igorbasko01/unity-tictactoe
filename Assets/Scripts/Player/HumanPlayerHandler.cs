using System;
public class HumanPlayerHandler {
    public event Action<int, int, PlayerMark> OnPerformMove;
    public HumanPlayerHandler(BoardUIEventsHandler boardUIEventsHandler) {
        boardUIEventsHandler.OnCellClicked += OnCellClicked;
    }

    public void OnCellClicked(int x, int y) {
        OnPerformMove?.Invoke(x, y, PlayerMark.X);
    }
}

public enum PlayerMark {
    X,
    O
}