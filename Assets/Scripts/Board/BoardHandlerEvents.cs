using System;
public class BoardHandlerEvents {
    private event Action<int, int, PlayerMark> _onCellStateChanged;
    public event Action<int, int, PlayerMark> OnCellStateChanged {
        add => _onCellStateChanged += value;
        remove => _onCellStateChanged -= value;
    }

    public void InvokeOnCellStateChanged(int x, int y, PlayerMark playerMark) {
        _onCellStateChanged?.Invoke(x, y, playerMark);
    }

}