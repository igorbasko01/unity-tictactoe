using NUnit.Framework;

[TestFixture]
public class BoardHandlerTests {
    [Test]
    public void ReturnCellIsEmptyWhenCellIsEmpty() {
        var boardHandler = new BoardHandler();
        Assert.IsTrue(boardHandler.IsCellEmpty(0, 0));
    }

    [Test]
    public void ReturnCellIsNotEmptyWhenCellIsOccupiedByPlayerX() {
        var boardHandler = new BoardHandler();
        boardHandler.PerformMove(0, 0, PlayerMark.X);
        Assert.IsFalse(boardHandler.IsCellEmpty(0, 0));
    }

    [Test]
    public void ReturnCellIsNotEmptyWhenCellIsOccupiedByPlayerO() {
        var boardHandler = new BoardHandler();
        boardHandler.PerformMove(0, 0, PlayerMark.O);
        Assert.IsFalse(boardHandler.IsCellEmpty(0, 0));
    }

    [Test]
    public void InvalidCoordinatesReturnCellIsNotEmpty() {
        var boardHandler = new BoardHandler();
        Assert.IsFalse(boardHandler.IsCellEmpty(-1, 0));
        Assert.IsFalse(boardHandler.IsCellEmpty(0, -1));
        Assert.IsFalse(boardHandler.IsCellEmpty(3, 0));
        Assert.IsFalse(boardHandler.IsCellEmpty(0, 3));
    }

    [Test]
    public void PerformMoveDoesntThrowAnExceptionIfCoordinatesAreInvalid() {
        var boardHandler = new BoardHandler();
        boardHandler.PerformMove(-1, 0, PlayerMark.X);
        boardHandler.PerformMove(0, -1, PlayerMark.X);
        boardHandler.PerformMove(3, 0, PlayerMark.X);
        boardHandler.PerformMove(0, 3, PlayerMark.X);
    }

    [Test]
    public void PerformMoveInvokesOnCellStateChangedEvent() {
        var boardHandler = new BoardHandler();
        var numberOfInvocations = 0;
        boardHandler.OnCellStateChanged += (x, y, playerMark) => { numberOfInvocations++; };
        boardHandler.PerformMove(0, 0, PlayerMark.X);
        Assert.AreEqual(1, numberOfInvocations);
    }

    [Test]
    public void PerformMoveDoesntInvokeOnCellStateChangedEventIfInvalidCoordinates() {
        var boardHandler = new BoardHandler();
        var numberOfInvocations = 0;
        boardHandler.OnCellStateChanged += (x, y, playerMark) => { numberOfInvocations++; };
        boardHandler.PerformMove(-1, 0, PlayerMark.X);
        boardHandler.PerformMove(0, -1, PlayerMark.X);
        boardHandler.PerformMove(3, 0, PlayerMark.X);
        boardHandler.PerformMove(0, 3, PlayerMark.X);
        Assert.AreEqual(0, numberOfInvocations);
    }
}