using NUnit.Framework;

[TestFixture]
public class BoardUIEventsHandlerTests {
    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        };
        boardUIEventsHandler.CellClick(0);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates1() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(1, x);
            Assert.AreEqual(0, y);
        };
        boardUIEventsHandler.CellClick(1);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates2() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(2, x);
            Assert.AreEqual(0, y);
        };
        boardUIEventsHandler.CellClick(2);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates3() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(0, x);
            Assert.AreEqual(1, y);
        };
        boardUIEventsHandler.CellClick(3);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates4() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(1, x);
            Assert.AreEqual(1, y);
        };
        boardUIEventsHandler.CellClick(4);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates5() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(2, x);
            Assert.AreEqual(1, y);
        };
        boardUIEventsHandler.CellClick(5);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates6() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(0, x);
            Assert.AreEqual(2, y);
        };
        boardUIEventsHandler.CellClick(6);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates7() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(1, x);
            Assert.AreEqual(2, y);
        };
        boardUIEventsHandler.CellClick(7);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates8() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            Assert.AreEqual(2, x);
            Assert.AreEqual(2, y);
        };
        boardUIEventsHandler.CellClick(8);
    }

    [Test]
    public void CellClickEventHighIndexDoesntInvoke_OnCellClicked() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        bool onCellClickedInvoked = false;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            onCellClickedInvoked = true;
        };
        boardUIEventsHandler.CellClick(9);
        Assert.IsFalse(onCellClickedInvoked);
    }

    [Test]
    public void CellClickEventNegativeIndexDoesntInvoke_OnCellClicked() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        bool onCellClickedInvoked = false;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            onCellClickedInvoked = true;
        };
        boardUIEventsHandler.CellClick(-1);
        Assert.IsFalse(onCellClickedInvoked);
    }
}