using UnityEngine;

public enum CellState {
    Empty,
    X,
    O
}

public class BoardHandler {
    private CellState[,] _board = new CellState[3, 3];
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
    }

    private bool isCoordinatesValid(int x, int y) {
        return x >= 0 && x < 3 && y >= 0 && y < 3;
    }
}