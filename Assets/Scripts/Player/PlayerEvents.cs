using System;
public class PlayerEvents {
    /**
     * This event is fired when the player clicks on a cell.
     * The first parameter is the x coordinate of the cell.
     * The second parameter is the y coordinate of the cell.
     * The third parameter is the mark of the player.
     */
    private event Action<int, int, PlayerMark> _onPerformMove;

    public event Action<int, int, PlayerMark> OnPerformMove {
        add => _onPerformMove += value;
        remove => _onPerformMove -= value;
    }

    public void InvokeOnPerformMove(int x, int y, PlayerMark playerMark) {
        _onPerformMove?.Invoke(x, y, playerMark);
    }

}