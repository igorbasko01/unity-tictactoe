using NUnit.Framework;

[TestFixture]
public class BoardHandlerTests {
    [Test]
    public void ReturnCellIsEmptyWhenCellIsEmpty() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        Assert.IsTrue(boardHandler.IsCellEmpty(0, 0));
    }

    [Test]
    public void ReturnCellIsNotEmptyWhenCellIsOccupiedByPlayerX() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        boardHandler.PerformMove(0, 0, PlayerMark.X);
        Assert.IsFalse(boardHandler.IsCellEmpty(0, 0));
    }

    [Test]
    public void ReturnCellIsNotEmptyWhenCellIsOccupiedByPlayerO() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        boardHandler.PerformMove(0, 0, PlayerMark.O);
        Assert.IsFalse(boardHandler.IsCellEmpty(0, 0));
    }

    [Test]
    public void InvalidCoordinatesReturnCellIsNotEmpty() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        Assert.IsFalse(boardHandler.IsCellEmpty(-1, 0));
        Assert.IsFalse(boardHandler.IsCellEmpty(0, -1));
        Assert.IsFalse(boardHandler.IsCellEmpty(3, 0));
        Assert.IsFalse(boardHandler.IsCellEmpty(0, 3));
    }

    [Test]
    public void PerformMoveDoesntThrowAnExceptionIfCoordinatesAreInvalid() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        boardHandler.PerformMove(-1, 0, PlayerMark.X);
        boardHandler.PerformMove(0, -1, PlayerMark.X);
        boardHandler.PerformMove(3, 0, PlayerMark.X);
        boardHandler.PerformMove(0, 3, PlayerMark.X);
    }

    [Test]
    public void PerformMoveInvokesOnCellStateChangedEvent() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        var numberOfInvocations = 0;
        boardHandlerEvents.OnCellStateChanged += (x, y, playerMark) => { numberOfInvocations++; };
        boardHandler.PerformMove(0, 0, PlayerMark.X);
        Assert.AreEqual(1, numberOfInvocations);
    }

    [Test]
    public void PerformMoveDoesntInvokeOnCellStateChangedEventIfInvalidCoordinates() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        var numberOfInvocations = 0;
        boardHandlerEvents.OnCellStateChanged += (x, y, playerMark) => { numberOfInvocations++; };
        boardHandler.PerformMove(-1, 0, PlayerMark.X);
        boardHandler.PerformMove(0, -1, PlayerMark.X);
        boardHandler.PerformMove(3, 0, PlayerMark.X);
        boardHandler.PerformMove(0, 3, PlayerMark.X);
        Assert.AreEqual(0, numberOfInvocations);
    }

    [Test]
    public void GetAllFreeCellsReturnsAllCellsWhenBoardIsEmpty() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        var freeCells = boardHandler.GetAllFreeCells();
        Assert.AreEqual(9, freeCells.Count);
    }

    [Test]
    public void GetAllFreeCellsReturnsSomeCellsWhenBoardHasSomeCellsOccupied() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        boardHandler.PerformMove(0, 0, PlayerMark.X);
        boardHandler.PerformMove(1, 1, PlayerMark.O);
        boardHandler.PerformMove(2, 2, PlayerMark.X);
        var freeCells = boardHandler.GetAllFreeCells();
        Assert.AreEqual(6, freeCells.Count);
    }

    [Test]
    public void IsDrawReturnsTrueWhenBoardIsFull() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        boardHandler.PerformMove(0, 0, PlayerMark.X);
        boardHandler.PerformMove(0, 1, PlayerMark.O);
        boardHandler.PerformMove(0, 2, PlayerMark.X);
        boardHandler.PerformMove(1, 0, PlayerMark.O);
        boardHandler.PerformMove(1, 1, PlayerMark.X);
        boardHandler.PerformMove(1, 2, PlayerMark.O);
        boardHandler.PerformMove(2, 0, PlayerMark.X);
        boardHandler.PerformMove(2, 1, PlayerMark.O);
        boardHandler.PerformMove(2, 2, PlayerMark.X);
        Assert.IsTrue(boardHandler.IsDraw());
    }

    [Test]
    public void BoardClearsAllCellsOnBoardClear() {
        var boardHandlerEvents = new BoardHandlerEvents();
        var boardHandler = new BoardHandler(boardHandlerEvents);
        boardHandler.PerformMove(0, 0, PlayerMark.X);
        boardHandler.PerformMove(0, 1, PlayerMark.O);
        boardHandler.PerformMove(0, 2, PlayerMark.X);
        boardHandler.PerformMove(1, 0, PlayerMark.O);
        boardHandler.PerformMove(1, 1, PlayerMark.X);
        boardHandler.PerformMove(1, 2, PlayerMark.O);
        boardHandler.ClearBoard();
        Assert.IsTrue(boardHandler.GetAllFreeCells().Count == 9);
    }
}