using System;

public enum CellState {
    Empty,
    X,
    O
}

public class BoardHandler {
    private CellState[,] _board = new CellState[3, 3];
    private BoardHandlerEvents _boardHandlerEvents;

    public BoardHandler(BoardHandlerEvents boardHandlerEvents) {
        _boardHandlerEvents = boardHandlerEvents;
    }
    public bool IsCellEmpty(int x, int y) {
        if (!isCoordinatesValid(x, y)) {
            return false;
        }
        return _board[x, y] == CellState.Empty;
    }

    public void PerformMove(int x, int y, PlayerMark playerMark) {
        if (!isCoordinatesValid(x, y)) {
            return;
        }
        _board[x, y] = playerMark == PlayerMark.X ? CellState.X : CellState.O;
        _boardHandlerEvents?.InvokeOnCellStateChanged(x, y, playerMark);
    }

    private bool isCoordinatesValid(int x, int y) {
        return x >= 0 && x < 3 && y >= 0 && y < 3;
    }

    public (int, int) GetFirstEmptyCell() {
        for (var x = 0; x < 3; x++) {
            for (var y = 0; y < 3; y++) {
                if (_board[x, y] == CellState.Empty) {
                    return (x, y);
                }
            }
        }
        throw new ArgumentException("Board is full");
    }
}