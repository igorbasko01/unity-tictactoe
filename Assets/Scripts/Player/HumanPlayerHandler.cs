using System;
public class HumanPlayerHandler {
    private PlayerEvents _playerEvents;

    public HumanPlayerHandler(BoardUIEventsHandler boardUIEventsHandler, PlayerEvents playerEvents) {
        _playerEvents = playerEvents;
        boardUIEventsHandler.OnCellClicked += OnCellClicked;
    }

    private void OnCellClicked(int x, int y) {
        _playerEvents?.InvokeOnPerformMove(x, y, PlayerMark.X);
    }
}

public enum PlayerMark {
    X,
    O
}