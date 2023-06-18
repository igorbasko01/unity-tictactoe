using NUnit.Framework;

[TestFixture]
public class BoardUIEventsHandlerTests {
    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int x = -1;
        int y = -1;
        boardUIEventsHandler.OnCellClicked += (nx, ny) => {
            x = nx;
            y = ny;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates1() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int x = -1;
        int y = -1;
        boardUIEventsHandler.OnCellClicked += (nx, ny) => {
            x = nx;
            y = ny;    
        };
        boardUIEventsHandler.CellClick(1);
        Assert.AreEqual(1, x);
        Assert.AreEqual(0, y);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates2() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int ax = -1;
        int ay = -1;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            ax = x;
            ay = y;
        };
        boardUIEventsHandler.CellClick(2);
        Assert.AreEqual(2, ax);
        Assert.AreEqual(0, ay);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates3() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int ax = -1;
        int ay = -1;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            ax = x;
            ay = y;
        };
        boardUIEventsHandler.CellClick(3);
        Assert.AreEqual(0, ax);
        Assert.AreEqual(1, ay);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates4() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int ax = -1;
        int ay = -1;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            ax = x;
            ay = y;
        };
        boardUIEventsHandler.CellClick(4);
        Assert.AreEqual(1, ax);
        Assert.AreEqual(1, ay);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates5() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int ax = -1;
        int ay = -1;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            ax = x;
            ay = y;
        };
        boardUIEventsHandler.CellClick(5);
        Assert.AreEqual(2, ax);
        Assert.AreEqual(1, ay);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates6() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int ax = -1;
        int ay = -1;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            ax = x;
            ay = y;
        };
        boardUIEventsHandler.CellClick(6);
        Assert.AreEqual(0, ax);
        Assert.AreEqual(2, ay);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates7() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int ax = -1;
        int ay = -1;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            ax = x;
            ay = y;
        };
        boardUIEventsHandler.CellClick(7);
        Assert.AreEqual(1, ax);
        Assert.AreEqual(2, ay);
    }

    [Test]
    public void CellClickEventTranslatesToBoardXYCoordinates8() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        int ax = -1;
        int ay = -1;
        boardUIEventsHandler.OnCellClicked += (x, y) => {
            ax = x;
            ay = y;
        };
        boardUIEventsHandler.CellClick(8);
        Assert.AreEqual(2, ax);
        Assert.AreEqual(2, ay);
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