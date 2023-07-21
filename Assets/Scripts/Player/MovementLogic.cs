using UnityEngine;
public interface IMovementLogic {
    public (int, int) SelectCellToMove(BoardHandler boardHandler);
}

public class RandomMovementLogic : IMovementLogic {
    public (int, int) SelectCellToMove(BoardHandler boardHandler) {
        var allFreeCells = boardHandler.GetAllFreeCells();
        if (allFreeCells.Count == 0) {
            throw new System.Exception("No free cells to move to.");
        }
        var randomIndex = Random.Range(0, allFreeCells.Count);
        return allFreeCells[randomIndex];
    }
}

public class FreeEmptyCellMovementLogic : IMovementLogic {
    public (int, int) SelectCellToMove(BoardHandler boardHandler) {
        return boardHandler.GetFirstEmptyCell();
    }
}