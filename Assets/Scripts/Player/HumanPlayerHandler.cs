using System;
public class HumanPlayerHandler {
    /**
     * This event is fired when the player clicks on a cell.
     * The first parameter is the x coordinate of the cell.
     * The second parameter is the y coordinate of the cell.
     * The third parameter is the mark of the player.
     */
    public event Action<int, int, PlayerMark> OnPerformMove;

    
    public HumanPlayerHandler(BoardUIEventsHandler boardUIEventsHandler) {
        boardUIEventsHandler.OnCellClicked += OnCellClicked;
    }

    private void OnCellClicked(int x, int y) {
        OnPerformMove?.Invoke(x, y, PlayerMark.X);
    }
}

public enum PlayerMark {
    X,
    O
}