using NUnit.Framework;

public class HumanPlayerHandlerTests {
    [Test]
    public void HumanPlayerInvokePerformMoveEvent() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        PlayerMark playerMark = default;
        int x = -1;
        int y = -1;
        humanPlayerHandler.OnPerformMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
    }
}