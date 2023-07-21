using System;
using System.Collections.Generic;

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

    public List<(int, int)> GetAllFreeCells() {
        var freeCells = new List<(int, int)>();
        for (var x = 0; x < 3; x++) {
            for (var y = 0; y < 3; y++) {
                if (_board[x, y] == CellState.Empty) {
                    freeCells.Add((x, y));
                }
            }
        }
        return freeCells;
    }

    public bool IsDraw() {
        return GetAllFreeCells().Count == 0;
    }

    public bool IsWin() {
        return IsWinForPlayer(PlayerMark.X) || IsWinForPlayer(PlayerMark.O);
    }

    private bool IsWinForPlayer(PlayerMark playerMark) {
        return IsWinForPlayerInRow(playerMark) || IsWinForPlayerInColumn(playerMark) || IsWinForPlayerInDiagonal(playerMark);
    }

    private bool IsWinForPlayerInRow(PlayerMark playerMark) {
        for (var x = 0; x < 3; x++) {
            if (_board[x, 0] == _board[x, 1] && _board[x, 1] == _board[x, 2] && _board[x, 2] == (playerMark == PlayerMark.X ? CellState.X : CellState.O)) {
                return true;
            }
        }
        return false;
    }

    private bool IsWinForPlayerInColumn(PlayerMark playerMark) {
        for (var y = 0; y < 3; y++) {
            if (_board[0, y] == _board[1, y] && _board[1, y] == _board[2, y] && _board[2, y] == (playerMark == PlayerMark.X ? CellState.X : CellState.O)) {
                return true;
            }
        }
        return false;
    }

    private bool IsWinForPlayerInDiagonal(PlayerMark playerMark) {
        if (_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[2, 2] == (playerMark == PlayerMark.X ? CellState.X : CellState.O)) {
            return true;
        }
        if (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0] && _board[2, 0] == (playerMark == PlayerMark.X ? CellState.X : CellState.O)) {
            return true;
        }
        return false;
    }
}