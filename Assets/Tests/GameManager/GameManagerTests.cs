using NUnit.Framework;

[TestFixture]
public class GameManagerTests {
    [Test]
    public void GameManagerListensForOnPerformMoveEventFromHumanPlayer() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        GameManager gameManager = new GameManager(humanPlayerHandler);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        gameManager.OnValidMove += (nx, ny, nplayerMark) => {
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